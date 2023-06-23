using MedQ.Infra.Data.Context;
using MedQ.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Teste.Comum
{
    public abstract class TesteBase
    {
        private static object Objeto = new object();
        private static MedQContext _context = default!;
        protected static MedQContext Context
        {
            get
            {
                lock(Objeto)
                {
                    if (_context == null)
                    {
                        return _context;
                    }
                    return CriarInstancia();
                }
            }
        }


        private static MedQContext CriarInstancia()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
             .AddJsonFile(path: "appsettings.json");
            IConfiguration _config = builder.Build();

            DbContextOptionsBuilder<MedQContext> dbContext = new DbContextOptionsBuilder<MedQContext>();
            dbContext.UseSqlite(_config.GetConnectionString("padrao"));
            _context = new MedQContext(dbContext.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            SEED.Popular(_context);
            return _context;
        }

    }
}
