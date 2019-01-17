using System;

namespace LearningHub.Domain.Infrastructure
{
    public class LoggedBaseEntity : BaseEntity
    {
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
    }
}