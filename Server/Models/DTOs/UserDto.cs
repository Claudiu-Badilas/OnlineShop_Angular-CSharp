namespace Server.Models {
    public class UserDto {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }

        public UserDto() { }

        public UserDto(AppUser user, string token) {
            Id = user.Id;
            Username = user.UserName;
            EmailAddress = user.EmailAddress;
            FirstName = user.FirstName;
            LastName = user.LastName;
            JoinDate = user.JoinDate;
            LastLogin = user.LastLogin;
            IsActive = user.IsActive;
            Role = user.Role;
            Token = token;
        }
    }
}
