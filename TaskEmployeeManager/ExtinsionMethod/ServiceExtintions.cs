using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskEmployeeManager.ExtinsionMethod
{
    public static class ServiceExtintions
    {
        public static void sqlconfigration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataBaseContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("TaskEmployeeManager"));
            });
        }

        //public static void RepositoryMgrConfig(this IServiceCollection services) =>
        //                services.AddScoped<IRepositoryManager, RepositoryManager>();

        //public static void ServicerConfig(this IServiceCollection services)
        //{
        //    services.AddScoped<IDepertmentService, DepertmentService>();
        //    // services.AddScoped<IEmployeeService , DepertmentService>();
        //}
    }
}