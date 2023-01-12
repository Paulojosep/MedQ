using MediatR;
using MedQ.Application.Interfaces;
using MedQ.Application.Mapper;
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
            services.AddDbContext<MedQContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            b => b.MigrationsAssembly(typeof(MedQContext).Assembly.FullName)));

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
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IConsultasRepository, ConsultaRepository>();
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            services.AddAutoMapper(typeof(MedqMapping));

            var myhandlers = AppDomain.CurrentDomain.Load("MedQ.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
