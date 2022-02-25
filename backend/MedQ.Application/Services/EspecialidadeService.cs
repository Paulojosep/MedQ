using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Interfaces;
using MedQ.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private IEspecialidadeRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadeService(IEspecialidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetAllAsync()
        {
            var especialidadeEntity = await _repository.GetEspecialidadeAsync();
            var resultado = _mapper.Map<IEnumerable<EspecialidadeDTO>>(especialidadeEntity);
            return resultado;
        }

        public async Task<EspecialidadeDTO> GetByIdAsync(int id)
        {
            var especialidadeEntity = await _repository.GetByIdAsync(id);
            var resultado = _mapper.Map<EspecialidadeDTO>(especialidadeEntity);
            return resultado;
        }

        public async Task<IEnumerable<EspecialidadeDTO>> GetByEstabelecimentoAsync(int idEstabelecimento)
        {
            var especialidadeEntity = await _repository.GetByEstabelecimentoAsync(idEstabelecimento);
            var resultado = _mapper.Map<IEnumerable<EspecialidadeDTO>>(especialidadeEntity);
            return resultado;
        }
    }
}
