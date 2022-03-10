using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IFilaRepository
    {
        Task<IEnumerable<Fila>> GetByEstabelecimentoAsync(int estabelecimentoId);
        Task<IEnumerable<Fila>> GetByTipoAtendimentoAsync(int tipoAtendimentiId, int estabelecimentoId);
        Task<Fila> CreateAsync(Fila fila);
    }
}
