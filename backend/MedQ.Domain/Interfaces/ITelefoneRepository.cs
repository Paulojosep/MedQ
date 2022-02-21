using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> GetAllTelefoneAsync();
        Task<Telefone> GetByIdAsync(int id);
        Task<Telefone> CreateTelefoneAsync(Telefone telefone);
        Task<Telefone> UpdateTelefoneAsync(Telefone telefone);
    }
}
