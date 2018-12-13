using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolPanda.Data.Context;
using SchoolPanda.Data.Infrastructure;

namespace SchoolPanda.Application.Infrastructure
{
    public class DependencyContainerMapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolPandaContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //register generic repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}