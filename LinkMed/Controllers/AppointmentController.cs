using LinkMed.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LinkMed.Models;

namespace LinkMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserRegistrationService _userRegistrationService;

        // Inject the service via the constructor
        public AppointmentController(IAppointmentService appointmentService, IUserRegistrationService userRegistrationService)
        {
            _appointmentService = appointmentService;
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("bookAppointment")]
        public IActionResult BookAppointment([FromBody] AppointmentRequest model)
        {
            if (!_userRegistrationService.IsUserLoggedIn())
            {
                return Unauthorized(new { message = "You must be logged in to book an appointment." });
            }

            // Get the logged-in user's username
            var username = _userRegistrationService.GetLoggedInUsername();

            // Try to book the appointment
            var success = _appointmentService.BookAppointment(username, model.AppointmentDate, model.Facility);

            if (success)
            {
                return Ok(new { message = $"Appointment booked successfully for {model.AppointmentDate} at {model.Facility}." });
            }

            return Conflict(new { message = "You already have an appointment booked." });
        }

        // Endpoint for retrieving the current user's appointment
        [HttpGet("myAppointment")]
        public IActionResult GetMyAppointment()
        {
            // Check if a user is logged in
            if (!_userRegistrationService.IsUserLoggedIn())
            {
                return Unauthorized(new { message = "You must be logged in to view your appointment." });
            }

            // Get the logged-in user's username
            var username = _userRegistrationService.GetLoggedInUsername();

            // Retrieve the appointment
            var appointment = _appointmentService.GetAppointment(username);
            if (appointment != null)
            {
                return Ok(appointment);
            }

            return NotFound(new { message = "No appointment found for the current user." });
        }

    }
}
