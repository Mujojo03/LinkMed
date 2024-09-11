using System.ComponentModel.DataAnnotations;

namespace LinkMed.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(9)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        //public bool PasswordUpdated { get; set; }
    }
}
