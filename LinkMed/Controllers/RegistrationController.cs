using LinkMed.IServices;
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
        public IActionResult Register([FromBody] IUserRegistrationService model)
        {
            if(model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { message = "Password do notmatch." });
            }

            if(_userRegistrationService.UserExists(model.Username, model.Email))
            {
                return Conflict(new { message = "Username or Email already exists." });
            }

            var userCreated = _userRegistrationService.CreateUser(model.Email, model.Username, model.Password);
            if (userCreated)
            {
                return Ok(new { message = "User Registered Successfully." });
            }
            return BadRequest(new { message = "Failed to Create User." });
        }
    }
}
