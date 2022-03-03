using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultasDTO>> GetBySocioAsync(int socioId);
        Task<ConsultasDTO> CreateAsync(ConsultasDTO consultas);
        Task<ConsultasDTO> UpdateAsync(ConsultasDTO consultas);
        Task DeleteAsync(int id);
    }
}
