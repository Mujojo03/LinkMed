using LinkMed.IServices;
using LinkMed.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using LinkMed.Models;

namespace LinkMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;
        public RegistrationController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistration model)
        {
            //check if passwords match
            if(model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { message = "Password do notmatch." });
            }

            //check if username or email aready exists
            if(_userRegistrationService.UserExists(model.Username, model.Email))
            {
                return Conflict(new { message = "Username or Email already exists." });
            }

            //check if user is a doctor
            if (model.IsDoctor)
            {
                //validate that a specialty is provided for doctors
                if (string.IsNullOrEmpty(model.Specialty))
                {
                    return BadRequest(new { message = "Specialty is required for doctor registration." });
                }

                string department = Department.GetDepartmentBySpecialty(model.Specialty);

                var doctorCreated = _userRegistrationService.CreateDoctor(model.Username, model.Specialty, model.Email, model.Password, department);
                if (doctorCreated)
                {
                    return Ok(new { message = $"Doctor Registered Successfully in the {department} department." });
                }
                return BadRequest(new { message = "Failed to Create Doctor." });
            }
            else
            {
                //Regular user registration
                var userCreated = _userRegistrationService.CreateUser(model.Email, model.Username, model.Password);
                if (userCreated)
                {
                    return Ok(new { message = "User Registered Successfully." });
                }
                return BadRequest(new { message = "Failed to Create User." });
            }

        }
    }
}
