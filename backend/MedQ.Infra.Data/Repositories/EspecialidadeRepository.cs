using MedQ.Application.Interfaces;
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
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly IRepositorioGenerico<Especialidade> _repositorio;

        public EspecialidadeRepository(IRepositorioGenerico<Especialidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Especialidade>> GetEspecialidadeAsync()
        {
            return await _repositorio.SelecionarTodos();
        }

        public async Task<Especialidade> GetByIdAsync(int id)
        {
            return await _repositorio.Obter(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Especialidade>> GetByEstabelecimentoAsync(int idEstabelecimento)
        {
            using(var ctx = new MedQContext())
            {
                var especialidade = from e in ctx.Especialidade
                                    join f in ctx.Fila on e.Id equals f.EspecialidadeId
                                    where f.EstabelecimentoId == idEstabelecimento
                                    select e;

                return await especialidade.ToListAsync();
            }

            
        }
    }
}
