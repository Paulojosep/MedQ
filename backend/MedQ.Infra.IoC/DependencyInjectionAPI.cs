using MediatR;
using MedQ.Application.Interfaces;
using MedQ.Application.Mappings;
using MedQ.Application.Services;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using MedQ.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Services
            services.AddScoped<ISocioService, SocioService>();
            services.AddScoped<ITelefoneService, TelefoneService>();

            //Repositories
            services.AddScoped<ISocioRepository, SocioRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("MedQ.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
