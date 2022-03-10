using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class FilaService : IFilaService
    {
        private IFilaRepository _repository;
        private readonly IMapper _mapper;

        public FilaService(IFilaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FilaDTO>> GetByEstabelecimentoAsync(int estabelecimentoId)
        {
            var filaEntity = await _repository.GetByEstabelecimentoAsync(estabelecimentoId);
            var resultado = _mapper.Map< IEnumerable<FilaDTO>>(filaEntity);
            return resultado;
        }

        public async Task<IEnumerable<FilaDTO>> GetByTipoAtendimentoAsync(int tipoAtendimentiId, int estabelecimentoId)
        {
            var filaEntity = await _repository.GetByTipoAtendimentoAsync(tipoAtendimentiId, estabelecimentoId);
            var resultado = _mapper.Map<IEnumerable<FilaDTO>>(filaEntity);
            return resultado;
        }

        public async Task<FilaDTO> CreateAsync(FilaDTO fila)
        {
            var filaEntity = _mapper.Map<Fila>(fila);
            await _repository.CreateAsync(filaEntity);
            var resultado = _mapper.Map<FilaDTO>(filaEntity);
            return resultado;
        }
    }
}
