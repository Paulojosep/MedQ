using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IMedicoService
    {
        Task<MedicoDTO> GetByID(int id);
        Task<IEnumerable<MedicoDTO>> GetByEstabelecimento(int estabelecimentoId);
        Task<bool> Create(MedicoDTO medico);
        Task<bool> Update(MedicoDTO medico);
        Task Delete(MedicoDTO medico);
    }
}
