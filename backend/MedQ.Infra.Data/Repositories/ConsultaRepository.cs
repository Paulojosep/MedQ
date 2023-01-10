using MedQ.Application.Interfaces;
using MedQ.Application.IO;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class ConsultaRepository : IConsultasRepository
    {
        private MedQContext _consultasContext;
        private readonly IRepositorioGenerico<Consultas> _repositorie;

        public ConsultaRepository(MedQContext context, IRepositorioGenerico<Consultas> repositorie)
        {
            _consultasContext = context;
            _repositorie = repositorie;
        }

        public async Task<Consultas> GetByIdAsync(int id)
        {
            return await _repositorie.Obter(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Consultas>> GetBySocioAsync(int socioId)
        {
            var consultas = await _repositorie.AdicionarInclusoes<Consultas, object>(
                x => x.Agendamento,
                x => x.Socio,
                x => x.Estabelecimento).Where(x => x.SocioId == socioId).ToListAsync();
            return consultas;
        }

        public async Task<Consultas> CreateAsync(Consultas consultas)
        {
            _repositorie.Adicionar(consultas);
            await _repositorie.SalvarAsync();
            return consultas;
        }

        public async Task<Consultas> UpdateAsync(Consultas consultas)
        {
            _repositorie.Editar(consultas);
            await _repositorie.SalvarAsync();
            return consultas;
        }

        public async Task DeleteAsync(Consultas consultas)
        {
            _repositorie.Deletar(consultas);
            await _repositorie.SalvarAsync();
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
