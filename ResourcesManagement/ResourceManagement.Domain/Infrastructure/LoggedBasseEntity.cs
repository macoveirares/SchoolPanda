using System;

namespace ResourceManagement.Domain.Infrastructure
{
    public class LoggedBaseEntity
    {
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
    }
}
