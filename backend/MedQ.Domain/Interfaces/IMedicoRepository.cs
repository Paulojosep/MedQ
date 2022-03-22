using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IMedicoRepository
    {
        Task<Medico> GetByIDAsync(int id);
        Task<IEnumerable<Medico>> GetByEstabelecimentoAsync(int estabelecimentoId);
        Task<Medico> CreateAsync(Medico medico);
        Task<Medico> UpdateAsync(Medico medico);
        Task DeleteAync(Medico medico);
    }
}
