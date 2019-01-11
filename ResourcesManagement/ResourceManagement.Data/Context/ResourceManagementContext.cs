using Microsoft.EntityFrameworkCore;
using ResourceManagement.Domain.Entities;

namespace ResourceManagement.Data.Context
{
    public class ResourceManagementContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }

        public ResourceManagementContext(DbContextOptions<ResourceManagementContext> options) : base(options) { }
    }
}