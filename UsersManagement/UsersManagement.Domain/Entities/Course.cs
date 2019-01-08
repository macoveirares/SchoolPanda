using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Domain.Entities
{
    public class Course : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int Year { get; set; }
        public ICollection<UserToCourse> Users { get; set; }
    }
}
