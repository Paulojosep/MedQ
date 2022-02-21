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
    public class TelefoneService : ITelefoneService
    {
        private ITelefoneRepository _repository;
        private readonly IMapper _mapper;

        public TelefoneService(ITelefoneRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TelefoneDTO>> GetAllAsync()
        {
            var telefoneEntity = await _repository.GetAllTelefoneAsync();
            return _mapper.Map<IEnumerable<TelefoneDTO>>(telefoneEntity);
        }

        public async Task<TelefoneDTO> GetByIdAsync(int id)
        {
            var telefoneEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TelefoneDTO>(telefoneEntity);
        }

        public async Task<TelefoneDTO> CreateAsync(TelefoneDTO obj)
        {
            var telefoneEntity = _mapper.Map<Telefone>(obj);
            await _repository.CreateTelefoneAsync(telefoneEntity);
            var resultado = _mapper.Map<TelefoneDTO>(telefoneEntity);
            return resultado;
        }

        public async Task<TelefoneDTO> UpdateAsync(TelefoneDTO obj)
        {
            var telefoneEntity = _mapper.Map<Telefone>(obj);
            await _repository.UpdateTelefoneAsync(telefoneEntity);
            var resultado = _mapper.Map<TelefoneDTO>(telefoneEntity);
            return resultado;
        }
    }
}
