using System.ComponentModel.DataAnnotations;

namespace UsersManagement.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required, MaxLength(35)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
