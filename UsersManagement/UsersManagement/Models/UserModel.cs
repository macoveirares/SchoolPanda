using System.ComponentModel.DataAnnotations;

namespace UsersManagement.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, MaxLength(35)]
        public string Username { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        public string Group { get; set; }

        public int Year { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}