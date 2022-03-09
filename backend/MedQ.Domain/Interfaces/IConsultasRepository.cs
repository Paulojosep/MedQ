using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IConsultasRepository
    {
        Task<Consultas> GetByIdAsync(int id);
        Task<IEnumerable<Consultas>> GetBySocioAsync(int socioId);
        Task<Consultas> CreateAsync(Consultas consultas);
        Task<Consultas> UpdateAsync(Consultas consultas);
        Task DeleteAsync(Consultas consultas);
        Task<IEnumerable<Consultas>> GetInfosAsync(int id);

    }
}
