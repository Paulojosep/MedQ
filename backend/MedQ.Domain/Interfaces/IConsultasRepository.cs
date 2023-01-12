using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IConsultasRepository
    {
        Task<IEnumerable<Consultas>> GetInfosAsync(int id);
        Task<Consultas> GetInfosForConsultationAsync(int id);

    }
}
