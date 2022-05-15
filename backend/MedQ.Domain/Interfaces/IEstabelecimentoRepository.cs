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
        Task<Estabelecimento> GetByIdAsync(int id);
        Task<IEnumerable<Estabelecimento>> GetBySocioAsync(int socioId);
        Task<Estabelecimento> GetByNomeAsync(string nome);
        Task<Estabelecimento> CreateAsync(Estabelecimento estabelecimento);
        Task<Estabelecimento> UpdateAsync(Estabelecimento estabelecimento);
        Task DeleteAsync(Estabelecimento estabelecimento);

    }
}
