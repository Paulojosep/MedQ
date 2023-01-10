using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IEstabelecimentoRepository
    {
        Task<IEnumerable<Estabelecimento>> GetAllAsync();
        Task<Estabelecimento> GetEstabelecimentoAsync(int? id, string? nome);
        Task<IEnumerable<Estabelecimento>> GetBySocioAsync(int socioId);
        Task<Estabelecimento> CreateAsync(Estabelecimento estabelecimento);
        Task<Estabelecimento> UpdateAsync(Estabelecimento estabelecimento);
        Task DeleteAsync(Estabelecimento estabelecimento);

    }
}
