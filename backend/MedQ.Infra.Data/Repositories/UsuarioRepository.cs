using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MedQContext _context;

        public UsuarioRepository(MedQContext context)
        {
            _context = context;
        }

        public Task<Socio> Logar(string usuario, string senha)
        {
            return _context.Socio.Where(x => x.Email == usuario && x.Senha == senha).FirstOrDefaultAsync();
        }
    }
}
