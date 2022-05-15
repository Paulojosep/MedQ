﻿using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IEstabelecimentoService
    {
        Task<IEnumerable<EstabelecimentoDTO>> GetAll();
        Task<EstabelecimentoDTO> GetById(int id);
        Task<IEnumerable<EstabelecimentoDTO>> GetBySocio(int socioId);
        Task<EstabelecimentoDTO> GetByNome(string nome);
        Task<EstabelecimentoDTO> Create(EstabelecimentoDTO Estabelecimento);
        Task<EstabelecimentoDTO> Update(EstabelecimentoDTO Estabelecimento);
        Task Delete(EstabelecimentoDTO Estabelecimento);
    }
}
