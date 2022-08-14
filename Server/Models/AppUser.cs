﻿namespace Server.Models {
    public class AppUser {
        public int? Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }

    enum Role {
        SUPER_ADMIN = 1, 
        ADMIN = 2,
        USER = 3,
    }
}
