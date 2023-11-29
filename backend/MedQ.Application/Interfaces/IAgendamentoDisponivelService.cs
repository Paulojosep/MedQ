using MedQ.Application.DTOs;
using MedQ.Application.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IAgendamentoDisponivelService
    {
        Task<List<AgendamentoDisponiveisDTO>> GetAll();
        Task<AgendamentoDisponiveisDTO> GetById(int id);
        Task<List<AgendamentoDisponiveisDTO>> GetByEstabelecimento(int establelcimentoId);
        Task<List<AgendamentoDisponiveisDTO>> GetByStatus(int establelcimentoId);
        Task<List<AgendamentoDisponiveisDTO>> GetAgendamentoDisponivel(AgendamentoDisponivelInput input);
        Task<bool> updateDisponibilidade(AgendamentoDisponivelAtualizacaoDisponibilidadeInput input);
    }
}
