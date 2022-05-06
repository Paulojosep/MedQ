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
    public class MedicoRepository : IMedicoRepository
    {
        private ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Medico> GetByIDAsync(int id)
        {
            return await _context.Medico.FindAsync(id);
        }

        public async Task<IEnumerable<Medico>> GetByEstabelecimentoAsync(int estabelecimentoId)
        {
            var medico = _context.Medico
                .Where(x => x.EstabelecimentoId.Equals(estabelecimentoId));

            return await medico.ToListAsync();
        }

        public async Task<Medico> CreateAsync(Medico medico)
        {
            _context.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> UpdateAsync(Medico medico)
        {
            await _context.Database.ExecuteSqlRawAsync($@"UPDATE tb_medicos SET nome = '{medico.Nome}', cpf = '{medico.CPF}', fk_especialidade_id = {medico.EspecialidadeId} WHERE id={medico.Id}");
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task DeleteAync(Medico medico)
        {
            await _context.Database.ExecuteSqlRawAsync($@"DELETE FROM tb_medicos WHERE id = {medico.Id}");
            await _context.SaveChangesAsync();
        }
    }
}
