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
    public class ConsultaService : IConsultaService
    {
        private IConsultasRepository _repository;
        private readonly IMapper _mapper;

        public ConsultaService(IConsultasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsultasDTO>> GetBySocioAsync(int socioId)
        {
            var consultaEntity = await _repository.GetBySocioAsync(socioId);
            var resultado = _mapper.Map<IEnumerable<ConsultasDTO>>(consultaEntity);
            return resultado;
        }

        public async Task<ConsultasDTO> CreateAsync(ConsultasDTO consultas)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsultasDTO> UpdateAsync(ConsultasDTO consultas)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
