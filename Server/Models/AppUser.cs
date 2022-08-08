namespace Server.Models {
    public class AppUser {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }

    }
}
