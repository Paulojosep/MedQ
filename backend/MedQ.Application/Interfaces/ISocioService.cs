using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface ISocioService
    {
        Task<IEnumerable<SocioDTO>> GetSocioAsync();
        Task<SocioDTO> GetBySocioAsync(int id, string cpf);
        Task<bool> CreateAsync(SocioDTO socio);
        Task<bool> UpdateAsycn(SocioDTO socio);
        Task DaleteAsync(int id);
    }
}
