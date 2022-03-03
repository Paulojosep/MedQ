using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class ConsultaRepository : IConsultasRepository
    {
        private ApplicationDbContext _consultasContext;

        public ConsultaRepository(ApplicationDbContext context)
        {
            _consultasContext = context;
        }

        public async Task<Consultas> GetByIdAsync(int id)
        {
            return await _consultasContext.Consultas.FindAsync(id);
        }

        public async Task<IEnumerable<Consultas>> GetBySocioAsync(int socioId)
        {
            var consultas = from c in _consultasContext.Consultas
                                join a in _consultasContext.AgendamentoDisponiveis on c.AgendamentoId equals a.Id
                                join m in _consultasContext.Medico on a.MedicoId equals m.Id
                                join e in _consultasContext.Especialidade on m.EspecialidadeId equals e.Id
                                where c.SocioId == socioId
                                select c;

            return await consultas.ToListAsync();
        }

        public async Task<Consultas> CreateAsync(Consultas consultas)
        {
            _consultasContext.Add(consultas);
            await _consultasContext.SaveChangesAsync();
            return consultas;
        }

        public async Task<Consultas> UpdateAsync(Consultas consultas)
        {
            _consultasContext.Update(consultas);
            await _consultasContext.SaveChangesAsync();
            return consultas;
        }

        public async Task DeleteAsync(Consultas consultas)
        {
            _consultasContext.Remove(consultas);
            await _consultasContext.SaveChangesAsync();
        }
    }
}
