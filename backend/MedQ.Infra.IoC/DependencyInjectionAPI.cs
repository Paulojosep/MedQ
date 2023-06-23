using MediatR;
using MedQ.Application.Interfaces;
using MedQ.Application.Mapper;
using MedQ.Application.Services;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using MedQ.Infra.Data.EF;
using MedQ.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedQ.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {   
            services.RegistrarDependencias();
            services.ConectarConexao(configuration);
            services.IniciarBancoDados(configuration);
            services.AddAutoMapper(typeof(MedqMapping));

            var myhandlers = AppDomain.CurrentDomain.Load("MedQ.Application");
            services.AddMediatR(myhandlers);

            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            return services;
        }

        private static void IniciarBancoDados(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                DbContextOptionsBuilder<MedQContext> dbContextOptions = new DbContextOptionsBuilder<MedQContext>();
                var connectionString = ObterConnectionString(configuration);
                dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly(typeof(MedQContext).Assembly.FullName));
                MedQContext context = new MedQContext(dbContextOptions.Options);
                context.ChangeTracker
                   .Entries()
                   .ToList()
                   .ForEach(e => e.State = EntityState.Detached);

                if (configuration["medbconnection"] != null)
                {
                    context.Database.Migrate();
                    SEED.Popular(context);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static string ObterConnectionString(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MySqlConnection");
            if (!string.IsNullOrEmpty(config["medbconnection"]?.ToString()))
            {
                Console.WriteLine("Conection string: " + connectionString);
                connectionString = config["medbconnection"].ToString();
            }
            Console.WriteLine("Aguardar 10 segundos");
            Thread.Sleep(10000);
            Console.WriteLine("Conection string: " + connectionString);
            return connectionString;
        }

        private static void ConectarConexao(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = ObterConnectionString(config);

            services.AddDbContext<MedQContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly(typeof(MedQContext).Assembly.FullName)));
        }

        private static void RegistrarDependencias(this IServiceCollection services)
        {
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
        }
    }
}
