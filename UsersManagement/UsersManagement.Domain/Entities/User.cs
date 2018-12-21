﻿using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Domain.Entities
{
    public class User : LoggedBaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
