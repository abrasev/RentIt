using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterIoCServices(this IServiceCollection services)
        {
            //Application layer
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IRenteeService, RenteeService>();

            //Domain.Interfaces > Infrastructures.Data.Repositories
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IRenteeRepository, RenteeRepository>();
        }
    }
}
