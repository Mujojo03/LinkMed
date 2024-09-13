namespace LinkMed.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        //public Patient Patient { get; set; }
        
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Facility { get; set; }
    }
}
