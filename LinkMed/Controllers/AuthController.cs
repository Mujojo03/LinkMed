using LinkMed.IServices;
using LinkMed.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _authService.GetUsers();
            return Ok(users);
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLogin model)
        {
            if (_authService.ValidateUser(model.Username, model.Password, model.Email))
            {
                return Ok("Login Successful");
                //return Ok(new {message = "Login Successful."});
            }
            return Unauthorized("Invalid username or password");
            //return Unauthorised(new {mesage = "Invalid userrname or password."});
        }


        [HttpPut("users/{password}")]
        public IActionResult UpdateUserPassword(string username, string password, string newPassword, string confirmPassword)
        {
            var updated = _authService.UpdateUserPassword(username, password, newPassword, confirmPassword);

            if (updated)
            {
                return Ok(new { message = "Password Updated Successfully." });
            }
            return NotFound(new { message = "User Not Found." });
        }


        [HttpDelete("users/{username, password}")]
        public IActionResult DeleteUser(string username, string password)
        {
            var deleted = _authService.DeleteUser(username, password);
            

            if (deleted)
            {
                return Ok(new { message = "User deleted successfully." });
            }

            return NotFound(new { message = "User not found." });
        }

    }
}
