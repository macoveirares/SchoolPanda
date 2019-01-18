using System;

namespace SchoolPanda.Application.DTO
{
    public class AddMarkDto
    {
        public int UserId { get; set; }

        public int CourseId { get; set; }

        public double Points { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
