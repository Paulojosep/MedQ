using MedQ.Application.DTOs;
using MedQ.Application.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IMinhasConsultaService
    {
        Task<IEnumerable<MinhasConsultaDTO>> GetAll();
        Task<string> GetFinishedMensagens(int socioId);
        Task<bool> CreateMyConsultation(MinhasConsultaInput minhasConsulta);
        Task<bool> UpdateMyConsultation(MinhasConsultaDTO minhasConsulta);
        Task DeleteMyConsultation(int id);
    }
}
