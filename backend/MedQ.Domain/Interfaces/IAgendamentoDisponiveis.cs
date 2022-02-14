using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IAgendamentoDisponiveis
    {
        Task<IEnumerable<AgendamentoDisponiveis>> GetAgendamentoDisponiveisAsync();
        Task<AgendamentoDisponiveis> GetBbyIdAsync(int id);
        Task<AgendamentoDisponiveis> GetBbyStatusAsync(int id);
        Task<AgendamentoDisponiveis> GetBbyEstabelecimentoAsync(int id);
        Task<AgendamentoDisponiveis> CreateAsync(AgendamentoDisponiveis agendamentoDisponiveis);
        Task<AgendamentoDisponiveis> UpdateAsync(int id, AgendamentoDisponiveis agendamentoDisponiveis);
        Task DeleteAsync(int id);
    }
}
