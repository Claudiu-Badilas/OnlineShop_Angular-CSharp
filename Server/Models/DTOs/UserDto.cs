namespace Server.Models {
    public class UserDto {
        public string Username { get; set; }
        public string Token { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? IsActive { get; set; }
        public Role? Role { get; set; }
    }
}
