using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private MedQContext _telefoneContext;

        public TelefoneRepository(MedQContext context)
        {
            _telefoneContext = context;
        }

        public async Task<IEnumerable<Telefone>> GetAllTelefoneAsync()
        {
            return await _telefoneContext.Telefone.ToListAsync(); 
        }

        public async Task<Telefone> GetByIdAsync(int id)
        {
            return await _telefoneContext.Telefone.FindAsync(id);
        }

        public async Task<Telefone> CreateTelefoneAsync(Telefone telefone)
        {
            _telefoneContext.Database.ExecuteSqlRaw($@"
            INSERT INTO `tb_telefone` (`DDD`, `Numero`, `fk_estabelecimento_id`, `tb_socio_id`)
            VALUES 
            ({telefone.DDD},{telefone.Numero},{telefone.EstabelecimentoId},{telefone.SocioId});");
            await _telefoneContext.SaveChangesAsync();
            return telefone;
        }

        public async Task<Telefone> UpdateTelefoneAsync(Telefone telefone)
        {
            _telefoneContext.Database.ExecuteSqlRaw($@"
                UPDATE tb_telefone SET ddd = {telefone.DDD}, numero = {telefone.Numero}  WHERE tb_socio_id = {telefone.SocioId}
            ");
            await _telefoneContext.SaveChangesAsync();
            return telefone;
        }
    }
}
