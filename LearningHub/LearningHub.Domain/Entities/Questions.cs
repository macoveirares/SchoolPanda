using LearningHub.Domain.Infrastructure;

namespace LearningHub.Domain.Entities
{
    public class Questions : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public int AddressedToUserId { get; set; }
    }
}