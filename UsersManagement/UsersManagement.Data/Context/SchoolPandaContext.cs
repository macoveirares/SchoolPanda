using Microsoft.EntityFrameworkCore;
using UsersManagement.Domain.Entities;

namespace UsersManagement.Data.Context
{
    public class SchoolPandaContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToCourse>()
                .HasKey(bc => new { bc.UserId, bc.CourseId });
            modelBuilder.Entity<UserToCourse>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Courses)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserToCourse>()
                .HasOne(bc => bc.Course)
                .WithMany(c => c.Users)
                .HasForeignKey(bc => bc.CourseId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserToCourse> UsersToCourses { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public SchoolPandaContext(DbContextOptions<SchoolPandaContext> options) : base(options) { }
    }
}