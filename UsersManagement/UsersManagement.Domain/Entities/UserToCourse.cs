using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Domain.Entities
{
    public class UserToCourse : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
