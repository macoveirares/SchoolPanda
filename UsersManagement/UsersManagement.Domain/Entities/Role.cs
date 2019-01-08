using System.ComponentModel.DataAnnotations;
using UsersManagement.Domain.Infrastructure;

namespace UsersManagement.Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
