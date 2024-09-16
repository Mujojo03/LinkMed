using LinkMed.Models;

namespace LinkMed.IServices
{
    public interface IAppointmentService
    {
        bool BookAppointment(string username, DateTime appointmentDate, string facility);
        Appointment GetAppointment(string username);
    }
}
