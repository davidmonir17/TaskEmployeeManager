using Domain.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.Implmntation;
using Repository.Interface;
using Services.Implmentation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static void RepositoryMgrConfig(this IServiceCollection services) =>
                        services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void autonticateConfigration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidIssuer = Configuration["JWT:Issuer"],
                       ValidAudience = Configuration["JWT:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                   };
               });
        }
    }
}