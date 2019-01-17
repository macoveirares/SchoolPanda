using LearningHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Data.Context
{
    public class SchoolPandaContext : DbContext
    {
        public DbSet<Questions> Marks { get; set; }

        public SchoolPandaContext(DbContextOptions<SchoolPandaContext> options) : base(options) { }
    }
}
