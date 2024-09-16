using LinkMed.IServices;
using LinkMed.Models;

namespace LinkMed.Services
{
    //book an appointment for a user
    public class AppointmentService : IAppointmentService
    {
        private readonly List<Appointment> _appointments = new List<Appointment>();
        public bool BookAppointment(string username, DateTime appointmentDate, string facility)
        {
            if(_appointments.Any(a => a.Username == username))
            {
                return false;
            }
            var newAppointment = new Appointment()
            {
                Username = username,
                AppointmentDate = appointmentDate,
                Facility = facility
            };
            _appointments.Add(newAppointment);
            return false;
        }

        //getting appointment from a specific user
        public Appointment GetAppointment(string username)
        {
            return _appointments.FirstOrDefault(a => a.Username == username);
        }
    }
}
