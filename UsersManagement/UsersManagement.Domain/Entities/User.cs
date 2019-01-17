using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Domain.Entities
{
    public class User : LoggedBaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Group { get; set; }

        [Required]
        public int Year { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public ICollection<UserToCourse> Courses { get; set; }
        public ICollection<Mark> Marks { get; set; }
        public ICollection<Attendance> StudentAttendances { get; set; }
    }
}
