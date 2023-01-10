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
            var resultado = _mapper.Map<IEnumerable<SocioDTO>>(socioEntity);
            return resultado;
        }

        public async Task<SocioDTO> GetBySocioAsync(int id, string cpf)
        {
            if (id > 0 && String.IsNullOrEmpty(cpf)) throw new Exception("Parametro deve ser informado");
            return _mapper.Map<SocioDTO>(await _repository.GetBySocioAsync(id, cpf));
        }

        public async Task<SocioDTO> CreateAsync(SocioDTO socioDTO)
        {
            var socioEntity = _mapper.Map<Socio>(socioDTO);
            return _mapper.Map<SocioDTO>(await _repository.CreateAsync(socioEntity));
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
            await _repository.DaleteAsync(await _repository.GetBySocioAsync(id, ""));
        }
    }
}
