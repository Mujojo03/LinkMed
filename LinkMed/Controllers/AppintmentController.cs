using LinkMed.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppintmentController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;

        // Inject the service via the constructor
        public UserController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("bookAppointment")]
        public IActionResult BookAppointment([FromBody] AppointmentRequest model)
        {
            if (!_userRegistrationService.IsUserLoggedIn())
            {
                return Unauthorized(new { message = "You must be logged in to book an appointment." });
            }

            var appointmentCreated = _userRegistrationService.BookAppointment(model.AppointmentDate, model.Facility);
            if (appointmentCreated)
            {
                return Ok(new { message = $"Appointment booked successfully for {model.AppointmentDate} at {model.Facility}." });
            }

            return BadRequest(new { message = "Failed to book appointment." });
        }

    }
}
}
