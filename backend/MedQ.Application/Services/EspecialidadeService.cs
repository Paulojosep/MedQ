using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IRepositorioGenerico<Especialidade> _repository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IMapper _mapper;

        public EspecialidadeService(IRepositorioGenerico<Especialidade> repository, IEspecialidadeRepository especialidadeRepository, IMapper mapper)
        {
            _repository = repository;
            _especialidadeRepository = especialidadeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EspecialidadeDTO>>(await _repository.SelecionarTodos());
        }

        public async Task<EspecialidadeDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<EspecialidadeDTO>(await _repository.Obter(x => x.Id ==id).FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetByEstabelecimentoAsync(int idEstabelecimento)
        {
            var resultado = _mapper.Map<IEnumerable<EspecialidadeDTO>>(await _especialidadeRepository.GetByEstabelecimentoAsync(idEstabelecimento));
            return resultado;
        }
    }
}
