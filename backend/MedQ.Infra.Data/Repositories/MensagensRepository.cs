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
    public class MensagensRepository : IMensagensRepository
    {
        private ApplicationDbContext _context;

        public MensagensRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Mensagens> GetByIdAsync(int id)
        {
            var mensagens = await _context.Mensagens.FindAsync(id);
            return mensagens;
        }

        public async Task<Mensagens> GetMensagensAsync(int socioId)
        {
            var mensage = await _context.Mensagens.FirstOrDefaultAsync(mensage => mensage.SocioId.Equals(socioId));
            return mensage;
        }

        public async Task<Mensagens> GetViewdMensagensAsync(int socioId)
        {
            var mensage = await _context.Mensagens.FirstOrDefaultAsync(mensage => mensage.SocioId.Equals(socioId));
            return mensage;
        }

        public async Task<Mensagens> CreateAsync(Mensagens mensagens)
        {
            _context.Mensagens.Add(mensagens);
            await _context.SaveChangesAsync();
            return mensagens;
        }

        public async Task<Mensagens> SetViwedTrueAsync(Mensagens mensagens)
        {
            await _context.Database.ExecuteSqlRawAsync($@"UPDATE tb_mensagens SET viewed = 1 WHERE id = {mensagens.Id}");
            await _context.SaveChangesAsync();
            return mensagens;
        }
    }
}
