using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IAgendamentoDisponiveisRepository
    {
        Task<IEnumerable<AgendamentoDisponiveis>> GetAgendamentoDisponiveisAsync();
        Task<AgendamentoDisponiveis> GetBbyIdAsync(int id);
        Task<AgendamentoDisponiveis> GetBbyStatusAsync(string status);
        Task<AgendamentoDisponiveis> GetBbyEstabelecimentoAsync(int estabelecimentoId);
        Task<AgendamentoDisponiveis> CreateAsync(AgendamentoDisponiveis agendamentoDisponiveis);
        Task<AgendamentoDisponiveis> UpdateAsync(AgendamentoDisponiveis agendamentoDisponiveis);
        Task DeleteAsync(int id);
    }
}
