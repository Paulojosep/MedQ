using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IMinhasConsultaRepository
    {
        Task<IEnumerable<MinhasConsulta>> GetAllAsyns();
        Task<string> GetFinishedMensagensAsync(int socioId);
        Task<bool> CreateMyConsultationAsync(MinhasConsulta minhasConsulta);
        Task<MinhasConsulta> UpdateMyConsultationAsync(MinhasConsulta minhasConsulta);
        Task DeleteMyConsultationAsync(int id);

    }
}
