using ResourceManagement.Domain.Infrastructure;

namespace ResourceManagement.Domain.Entities
{
    public class Resource : LoggedBaseEntity
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }
}