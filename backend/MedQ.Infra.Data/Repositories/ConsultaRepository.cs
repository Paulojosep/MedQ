using MedQ.Application.IO;
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
            _consultasContext.Database.ExecuteSqlRaw($@"UPDATE `medq`.`tb_consultas` SET `status` = '{consultas.Status}' WHERE (`id` = '{consultas.Id}')");
            await _consultasContext.SaveChangesAsync();
            return consultas;
        }

        public async Task DeleteAsync(Consultas consultas)
        {
            _consultasContext.Remove(consultas);
            await _consultasContext.SaveChangesAsync();
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
