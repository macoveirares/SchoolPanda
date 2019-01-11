using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceManagement.Data.Context;
using ResourceManagement.Data.Infrastructure;

namespace ResourceManagement.Application.Infrastructure
{
    public class DependencyContainerMapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResourceManagementContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}