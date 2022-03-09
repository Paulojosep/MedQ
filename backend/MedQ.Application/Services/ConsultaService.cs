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
    public class ConsultaService : IConsultaService
    {
        private IConsultasRepository _repository;
        private readonly IMapper _mapper;

        public ConsultaService(IConsultasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ConsultasDTO> GetByIdAsync(int id)
        {
            var consultaEntity = await _repository.GetByIdAsync(id);
            var resultado = _mapper.Map<ConsultasDTO>(consultaEntity);
            return resultado;
        }

        public async Task<IEnumerable<ConsultasDTO>> GetBySocioAsync(int socioId)
        {
            var consultaEntity = await _repository.GetBySocioAsync(socioId);
            var resultado = _mapper.Map<IEnumerable<ConsultasDTO>>(consultaEntity);
            return resultado;
        }

        public async Task<ConsultasDTO> CreateAsync(ConsultasDTO consultas)
        {
            var consultaEntity = _mapper.Map<Consultas>(consultas);
            await _repository.CreateAsync(consultaEntity);
            var resultado = _mapper.Map<ConsultasDTO>(consultaEntity);
            return resultado;
        }

        public async Task<ConsultasDTO> UpdateAsync(ConsultasDTO consultas)
        {
            var consultaEntity = _mapper.Map<Consultas>(consultas);
            await _repository.UpdateAsync(consultaEntity);
            var resultado = _mapper.Map<ConsultasDTO>(consultaEntity);
            return resultado;
        }

        public async Task DeleteAsync(int id)
        {
            var consultaEntity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(consultaEntity);
        }
    }
}
