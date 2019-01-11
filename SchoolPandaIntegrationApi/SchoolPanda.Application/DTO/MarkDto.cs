using System;

namespace SchoolPanda.Application.DTO
{
    public class MarkDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public double Points { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
