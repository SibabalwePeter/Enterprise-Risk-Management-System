using ERMS.DAL.Data;
using ERMS.services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERMS.services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesDI(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            service.AddScoped<IUserService, UserService>();
            return service;
        }
    }
}
