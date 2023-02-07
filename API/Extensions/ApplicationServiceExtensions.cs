using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
            IConfiguration config)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            services.AddDbContext<DataContext>(opt => 
            { 
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            //add CORS policy
            services.AddCors(options => 
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                    policy =>
                                    {
                                        policy.WithOrigins("https://localhost:4200");
                                    });
            });

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}