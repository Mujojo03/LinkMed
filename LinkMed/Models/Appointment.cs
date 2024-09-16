namespace LinkMed.Models
{
    public class Appointment
    {
        public string Username { get; set; }  // The user booking the appointment
        public DateTime AppointmentDate { get; set; }
        public string Facility { get; set; }
    }
}
