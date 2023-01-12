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
