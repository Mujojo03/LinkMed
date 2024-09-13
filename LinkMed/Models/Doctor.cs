namespace LinkMed.Models
{
    public class Doctor : UserRegistration
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Specialty { get; set; }
        public string Department { get; set; }
    }
}
