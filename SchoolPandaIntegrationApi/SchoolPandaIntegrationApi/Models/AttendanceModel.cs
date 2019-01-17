using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolPandaIntegrationAPI.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
    }
}
