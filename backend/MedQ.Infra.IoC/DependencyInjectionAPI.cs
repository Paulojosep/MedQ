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
            services.AddScoped<IEspecialidadeService, EspecialidadeService>();
            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<IConsultaService, ConsultaService>();
            services.AddScoped<IFilaService, FilaService>();
            services.AddScoped<IMensagensService, MensagensService>();
            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
            services.AddScoped<IMinhasConsultaService, MinhasConsultaService>();

            //Repositories
            services.AddScoped<ISocioRepository, SocioRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IConsultasRepository, ConsultaRepository>();
            services.AddScoped<IFilaRepository, FilaRepository>();
            services.AddScoped<IMensagensRepository, MensagensRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddScoped<IMinhasConsultaRepository, MinhasConsultaRepository>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("MedQ.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
