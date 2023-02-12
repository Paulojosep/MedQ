using MedQ.Domain.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class ConsultaRepository : IConsultasRepository
    {
        private readonly MedQContext _consultasContext;

        public ConsultaRepository(MedQContext consultasContext)
        {
            _consultasContext = consultasContext;
        }

        public async Task<IEnumerable<Consultas>> GetInfosAsync(int id)
        {
            var consultas = from c in _consultasContext.Consultas
                            join a in _consultasContext.AgendamentoDisponiveis on c.AgendamentoId equals a.Id
                            join m in _consultasContext.Medico on a.MedicoId equals m.Id
                            join p in _consultasContext.Especialidade on m.EspecialidadeId equals p.Id
                            join es in _consultasContext.Estabelecimento on m.EstabelecimentoId equals es.Id
                            where c.Id == id
                            select c;

            return await consultas.ToListAsync();
        }

        public async Task<Consultas> GetInfosForConsultationAsync(int id)
        {
            var consultas = from c in _consultasContext.Consultas
                            join a in _consultasContext.AgendamentoDisponiveis on c.AgendamentoId equals a.Id
                            join m in _consultasContext.Medico on a.MedicoId equals m.Id
                            join p in _consultasContext.Especialidade on m.EspecialidadeId equals p.Id
                            join es in _consultasContext.Estabelecimento on m.EstabelecimentoId equals es.Id
                            where c.Id == id
                            select c;

            return await consultas.FirstOrDefaultAsync();
        }
    }
}
