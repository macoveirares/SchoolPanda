using Microsoft.EntityFrameworkCore;
using SchoolPanda.Domain.Entities;

namespace SchoolPanda.Data.Context
{
    public class SchoolPandaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SchoolPandaContext(DbContextOptions<SchoolPandaContext> options) : base(options) { }
    }
}