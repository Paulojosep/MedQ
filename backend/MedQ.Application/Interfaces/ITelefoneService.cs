using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface ITelefoneService
    {
        Task<IEnumerable<TelefoneDTO>> GetAllAsync();
        Task<TelefoneDTO> GetByIdAsync(int id);
        Task<TelefoneDTO> CreateAsync(TelefoneDTO obj);
        Task<TelefoneDTO> UpdateAsync(TelefoneDTO obj);
    }
}
