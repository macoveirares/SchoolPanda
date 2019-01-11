using System.ComponentModel.DataAnnotations;

namespace SchoolPandaIntegrationAPI.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}