using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IFilaService
    {
        Task<IEnumerable<FilaDTO>> GetByEstabelecimentoAsync(int estabelecimentoId);
        Task<IEnumerable<FilaDTO>> GetByTipoAtendimentoAsync(int tipoAtendimentiId, int estabelecimentoId);
        Task<FilaDTO> CreateAsync(FilaDTO fila);
    }
}
