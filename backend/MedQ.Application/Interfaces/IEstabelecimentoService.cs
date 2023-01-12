using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IEstabelecimentoService
    {
        Task<IEnumerable<EstabelecimentoDTO>> GetAll();
        Task<EstabelecimentoDTO> GetEstabelecimento(int id, string nome);
        Task<IEnumerable<EstabelecimentoDTO>> GetBySocio(int socioId);
        Task<bool> Create(EstabelecimentoDTO Estabelecimento);
        Task<bool> Update(EstabelecimentoDTO Estabelecimento);
        Task Delete(EstabelecimentoDTO Estabelecimento);
    }
}
