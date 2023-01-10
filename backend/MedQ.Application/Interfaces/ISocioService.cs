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
        Task<SocioDTO> CreateAsync(SocioDTO socio);
        Task<SocioDTO> UpdateAsycn(int id, SocioDTO socio);
        Task DaleteAsync(int id);
    }
}
