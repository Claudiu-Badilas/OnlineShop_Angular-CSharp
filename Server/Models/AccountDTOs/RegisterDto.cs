using System.ComponentModel.DataAnnotations;

namespace Server.Models {
    public class RegisterDto {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
    }
}
