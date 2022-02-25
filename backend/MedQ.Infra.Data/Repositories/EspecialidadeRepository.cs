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
        private ApplicationDbContext _especialidadeContext;

        public EspecialidadeRepository(ApplicationDbContext context)
        {
            _especialidadeContext = context;
        }

        public async Task<IEnumerable<Especialidade>> GetEspecialidadeAsync()
        {
            var resultado = await _especialidadeContext.Especialidade.ToListAsync();
            return resultado;
        }

        public async Task<Especialidade> GetByIdAsync(int id)
        {
            var especialidade = await _especialidadeContext.Especialidade.FindAsync(id);
            return especialidade;
        }

        public async Task<IEnumerable<Especialidade>> GetByEstabelecimentoAsync(int idEstabelecimento)
        {
            var especialidade = await _especialidadeContext.Especialidade
                .Include(f => f.Filas.Where(x => x.EstabelecimentoId.Equals(idEstabelecimento)))
                .Where(x => x.Id.Equals(idEstabelecimento))
                .ToListAsync();
            return especialidade;
        }
    }
}
