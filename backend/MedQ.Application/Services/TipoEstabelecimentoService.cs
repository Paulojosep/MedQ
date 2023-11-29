using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class TipoEstabelecimentoService : ITipoEstabelecimentoService
    {
        private readonly IRepositorioGenerico<TipoEstabelecimento> _tipoEstabelecimentoRepository;
        private readonly IMapper _mapper;

        public TipoEstabelecimentoService(IRepositorioGenerico<TipoEstabelecimento> tipoEstabelecimentoRepository, IMapper mapper)
        {
            _tipoEstabelecimentoRepository = tipoEstabelecimentoRepository;
            _mapper = mapper;
        }

        public async Task<List<TipoEstabelecimentoDTO>> ListaTipoEstabelecimentos()
        {
            return _mapper.Map<List<TipoEstabelecimentoDTO>>(await _tipoEstabelecimentoRepository.SelecionarTodos());
        }

        public async Task<TipoEstabelecimentoDTO> TipoEstabelecimentoPorCodigo(int codigo)
        {
            return _mapper.Map<TipoEstabelecimentoDTO>(await _tipoEstabelecimentoRepository.AdicionarInclusoes<TipoEstabelecimento, object>(x =>
            x.Estabelecimentos).Where(x => x.Id.Equals(codigo)).FirstOrDefaultAsync());
        }
    }
}
