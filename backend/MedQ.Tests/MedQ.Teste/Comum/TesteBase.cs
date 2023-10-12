using MedQ.Infra.Data.Context;
using MedQ.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Teste.Comum
{
    public class TesteBase
    {
        private static object Object = new object();
        private static MedQContext _context = default!;

        protected static MedQContext Context 
        { 
            get 
            {
                lock(Object)
                {
                    if(_context != null)
                    {
                        return _context;
                    }
                    return CriarInstancia();
                }
            } 
        }

        private static MedQContext CriarInstancia()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(path: "appsettings.json");
            IConfiguration configuration = builder.Build();

            DbContextOptionsBuilder<MedQContext> dbContext = new DbContextOptionsBuilder<MedQContext>();
            dbContext.UseMySql(configuration.GetConnectionString("padrao"), ServerVersion.AutoDetect(configuration.GetConnectionString("padrao")),
                    b => b.MigrationsAssembly(typeof(MedQContext).Assembly.FullName));

            _context = new MedQContext(dbContext.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            SEED.Popular(_context);
            return _context;
        }
    }
}
