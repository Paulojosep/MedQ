using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeDTO>> GetAllAsync();
        Task<EspecialidadeDTO> GetByIdAsync(int id);
        Task<IEnumerable<EspecialidadeDTO>> GetByEstabelecimentoAsync(int idEstabelecimento);
    }
}
