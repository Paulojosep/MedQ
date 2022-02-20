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
    public class SocioService : ISocioService
    {
        private ISocioRepository _repository;
        private readonly IMapper _mapper;

        public SocioService(ISocioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SocioDTO>> GetSocioAsync()
        {
            var socioEntity = await _repository.GetSocioAsync();
            return _mapper.Map<IEnumerable<SocioDTO>>(socioEntity);
        }

        public async Task<SocioDTO> GetByIdAsync(int id)
        {
            var socioEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SocioDTO>(socioEntity);
        }

        public async Task<SocioDTO> GetByCPFAsync(string cpf)
        {
            var socioEntity = await _repository.GetByCPFAsync(cpf);
            return _mapper.Map<SocioDTO>(socioEntity);
        }

        public async Task<SocioDTO> CreateAsync(SocioDTO socioDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<SocioDTO> UpdateAsycn(int id, SocioDTO socioDTO)
        {
            var socioEntity = _mapper.Map<Socio>(socioDTO);
            await _repository.UpdateAsycn(socioEntity);
            var resultado = _mapper.Map<SocioDTO>(socioEntity);
            return resultado;
        }

        public async Task DaleteAsync(int id)
        {
            var socioEntity = _repository.GetByIdAsync(id).Result;
            await _repository.DaleteAsync(socioEntity);
        }
    }
}
