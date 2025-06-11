using ERMS.core;
using ERMS.DAL;
using ERMS.services;
using ERMS.services.Users;

namespace ERMS.api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection service, IConfiguration config)
        {
            service
            .AddCoreDI()
            .AddDALDI(config);
            return service;
        }
    }
}
