using SchoolPanda.Domain.Infrastructure;

namespace SchoolPanda.Domain.Entities
{
    public class User : LoggedBaseEntity
    {
        public string Username { get; set; }
    }
}
