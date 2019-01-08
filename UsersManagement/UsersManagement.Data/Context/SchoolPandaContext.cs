using Microsoft.EntityFrameworkCore;
using UsersManagement.Domain.Entities;

namespace UsersManagement.Data.Context
{
    public class SchoolPandaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public SchoolPandaContext(DbContextOptions<SchoolPandaContext> options) : base(options) { }
    }
}