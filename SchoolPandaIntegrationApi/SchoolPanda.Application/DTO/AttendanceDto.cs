using System;

namespace SchoolPanda.Application.DTO
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}