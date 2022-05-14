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
        Task<MinhasConsulta> GetFinishedMensagensAsync(int socioId);
        Task<MinhasConsulta> CreateMyConsultationAsync(MinhasConsulta minhasConsulta);
        Task<MinhasConsulta> UpdateMyConsultationAsync(MinhasConsulta minhasConsulta);
        Task DeleteMyConsultationAsync(int id);

    }
}
