using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class SocioRepository : ISocioRepository
    {
        private ApplicationDbContext _socioContext;

        public SocioRepository(ApplicationDbContext context)
        {
            _socioContext = context;
        }
        public async Task<IEnumerable<Socio>> GetSocioAsync()
        {
            var resultado = await _socioContext.Socio.ToListAsync();
            return resultado;
        }

        public async Task<Socio> GetByIdAsync(int id)
        {
            return await _socioContext.Socio.FindAsync(id);
        }

        public async Task<Socio> GetByCPFAsync(string cpf)
        {
            return await _socioContext.Socio.FirstOrDefaultAsync(socio => socio.CPF.Equals(cpf));
        }

        public async Task<Socio> CreateAsync(Socio socio)
        {
            _socioContext.Add(socio);
            await _socioContext.SaveChangesAsync();
            return socio;
        }

        public async Task<Socio> UpdateAsycn(Socio socio)
        {
            _socioContext.Update(socio);
            await _socioContext.SaveChangesAsync();
            return socio;
        }

        public async Task DaleteAsync(Socio socio)
        {
            _socioContext.Remove(socio);
            await _socioContext.SaveChangesAsync();
        }
    }
}
