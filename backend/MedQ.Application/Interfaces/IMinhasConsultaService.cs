using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IMinhasConsultaService
    {
        Task<IEnumerable<MinhasConsultaDTO>> GetAll();
        Task<MinhasConsultaDTO> GetFinishedMensagens(int socioId);
        Task<MinhasConsultaDTO> CreateMyConsultation(MinhasConsultaDTO minhasConsulta);
        Task<MinhasConsultaDTO> UpdateMyConsultation(MinhasConsultaDTO minhasConsulta);
        Task DeleteMyConsultation(int id);
    }
}
