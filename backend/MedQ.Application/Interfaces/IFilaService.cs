using MedQ.Application.DTOs;
using MedQ.Application.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IFilaService
    {
        Task<IEnumerable<FilaByEstabelecimentoOutput>> GetByEstabelecimentoAsync(int estabelecimentoId);
        Task<IEnumerable<FilaByTipoAtendimentoOutput>> GetByTipoAtendimentoAsync(int tipoAtendimentiId, int estabelecimentoId);
        Task<bool> CreateAsync(FilaDTO fila);
    }
}
