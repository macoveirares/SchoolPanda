using System;
using System.ComponentModel.DataAnnotations;
using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Domain.Entities
{
    public class Mark : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Required]
        public double Points { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
    }
}
