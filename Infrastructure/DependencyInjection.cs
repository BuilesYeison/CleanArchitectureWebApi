﻿using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Services;
using Infrastructure.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Set database context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Inject repositories
            services.AddScoped<IFooRepository, FooRepository>();

            //Inject services
            services.AddTransient<IMessageService, AppMessageService>();

            return services;
        }
    }
}
