using System;
using System.ComponentModel.DataAnnotations;

namespace UsersManagement.Models
{
    public class MarkModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public double Points { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
    }
}
