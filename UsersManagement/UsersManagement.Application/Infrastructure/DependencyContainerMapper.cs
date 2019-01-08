using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersManagement.Application.Services;
using UsersManagement.Data.Context;
using UsersManagement.Data.Infrastructure;

namespace UsersManagement.Application.Infrastructure
{
    public static class DependencyContainerMapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolPandaContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}