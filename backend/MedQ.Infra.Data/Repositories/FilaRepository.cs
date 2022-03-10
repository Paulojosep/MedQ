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
    public class FilaRepository : IFilaRepository
    {
        private ApplicationDbContext _context;

        public FilaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fila>> GetByEstabelecimentoAsync(int estabelecimentoId)
        {
            /*var filas = _context.Fila
                .Include(x => x.TipoAtendimento)
                .Include(x => x.Especialidade)
                .Where(x => x.EstabelecimentoId == estabelecimentoId);*/

            var filas = from f in _context.Fila
                        join ta in _context.TipoAtendimento on f.TipoAntendimentoId equals ta.Id
                        join e in _context.Especialidade on f.EspecialidadeId equals e.Id
                        where f.EstabelecimentoId == estabelecimentoId
                        select f;

            return await filas.ToListAsync();
        }

        public async Task<IEnumerable<Fila>> GetByTipoAtendimentoAsync(int tipoAtendimentiId, int estabelecimentoId)
        {
            var filas = _context.Fila
                .Include(e => e.Especialidade)
                .Where(x => x.TipoAntendimentoId.Equals(tipoAtendimentiId))
                .Where(x => x.EstabelecimentoId.Equals(estabelecimentoId));

            return await filas.ToListAsync();
        }

        public async Task<Fila> CreateAsync(Fila fila)
        {
            _context.Add(fila);
            await _context.SaveChangesAsync();
            return fila;
        }
    }
}
