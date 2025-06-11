using ERMS.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERMS.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDALDI(this IServiceCollection service, Microsoft.Extensions.Configuration.IConfiguration config)
        {
            service.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=ERMS;Trusted_Connection=True;MultipleActiveResultSets=true;\r\n");
            });
            return service;
        }
    }
}
