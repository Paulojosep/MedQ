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
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private ApplicationDbContext _context;

        public EstabelecimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estabelecimento>> GetAllAsync()
        {
            var resultado = await _context.Estabelecimento.ToListAsync();
            return resultado;
        }

        public async Task<IEnumerable<Estabelecimento>> GetBySocioAsync(int socioId)
        {
            var medico = _context.Estabelecimento.Where(x => x.SocioId.Equals(socioId));
            return await medico.ToListAsync();
        }

        public async Task<Estabelecimento> GetByIdAsync(int id)
        {
            var resultado = await _context.Estabelecimento.FindAsync(id);
            return resultado;
        }

        public async Task<Estabelecimento> GetByNomeAsync(string nome)
        {
            var resultado = await _context.Estabelecimento.FindAsync(nome);
            return resultado;
        }

        public async Task<Estabelecimento> CreateAsync(Estabelecimento estabelecimento)
        {
            await _context.AddAsync(estabelecimento);
            await _context.SaveChangesAsync();
            return estabelecimento;
        }

        public async Task<Estabelecimento> UpdateAsync(Estabelecimento estabelecimento)
        {
            _context.Update(estabelecimento);
            await _context.SaveChangesAsync();
            return estabelecimento;
        }

        public async Task DeleteAsync(Estabelecimento estabelecimento)
        {
            _context.Remove(estabelecimento);
            await _context.SaveChangesAsync();
        }
    }
}
