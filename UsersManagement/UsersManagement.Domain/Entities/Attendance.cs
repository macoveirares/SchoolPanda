using System;
using System.ComponentModel.DataAnnotations;
using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        [Required]
        public int StudentId { get; set; }
        public virtual User Student { get; set; }
        public int TeacherId { get; set; }
        [Required]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
    }
}
