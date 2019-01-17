using System;

namespace UsersManagement.Application.DTO
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
