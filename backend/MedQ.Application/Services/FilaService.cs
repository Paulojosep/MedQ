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
    public class FilaService : IFilaService
    {
        private readonly IRepositorioGenerico<Fila> _repository;
        private readonly IMapper _mapper;

        public FilaService(IRepositorioGenerico<Fila> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FilaDTO>> GetByEstabelecimentoAsync(int estabelecimentoId)
        {
            return _mapper.Map<IEnumerable<FilaDTO>>(await _repository.AdicionarInclusoes<Fila, object>(
                x => x.Especialidade,
                x => x.Estabelecimento,
                x => x.TipoAtendimento).ToListAsync());
        }

        public async Task<IEnumerable<FilaDTO>> GetByTipoAtendimentoAsync(int tipoAtendimentoId, int estabelecimentoId)
        {
            var filas = _repository.AdicionarInclusoes<Fila, object>(
                x => x.Estabelecimento,
                x => x.TipoAtendimento);

            if (tipoAtendimentoId > 0) filas = filas.Where(x => x.TipoAntendimentoId == tipoAtendimentoId);
            if (estabelecimentoId > 0) filas = filas.Where(x => x.EstabelecimentoId == estabelecimentoId);
            return _mapper.Map<IEnumerable<FilaDTO>>( await filas.ToListAsync());
        }

        public async Task<bool> CreateAsync(FilaDTO fila)
        {
            try
            {
                var filaEntity = _mapper.Map<Fila>(fila);
                _repository.Adicionar(filaEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Erro ao incluir", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }
    }
}
