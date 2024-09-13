namespace LinkMed.Models
{
    public class UserRegistration
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //applicable for doctors.
        public bool IsDoctor { get; set; }
        public string Specialty { get; set; }
        public string Department { get; set; }
    }
}
