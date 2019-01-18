using System.Collections.Generic;

namespace ResourceManagement.Application.DTO
{
    public class ResourcesDetails
    {
        public List<ResourceDetails> Resources { get; set; }
    }

    public class ResourceDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}