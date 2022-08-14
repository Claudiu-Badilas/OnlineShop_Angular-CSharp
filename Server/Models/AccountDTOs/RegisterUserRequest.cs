using System.ComponentModel.DataAnnotations;

namespace Server.Models {
    public class RegisterUserRequest {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
