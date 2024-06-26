﻿using DateVoyage.Data;
using DateVoyage.Interfaces;
using DateVoyage.Services;
using Microsoft.EntityFrameworkCore;

namespace DateVoyage.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
           services.AddCors();
           services.AddScoped<ITokenService, TokenService>();
           return services;
        }

    }
}
