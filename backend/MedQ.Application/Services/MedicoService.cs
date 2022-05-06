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
    public class MedicoService : IMedicoService
    {
        private IMedicoRepository _repository;
        private readonly IMapper _mapper;

        public MedicoService(IMedicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MedicoDTO> GetByID(int id)
        {
            var medicoEntity = await _repository.GetByIDAsync(id);
            var resultado = _mapper.Map<MedicoDTO>(medicoEntity);
            return resultado;
        }

        public async Task<IEnumerable<MedicoDTO>> GetByEstabelecimento(int estabelecimentoId)
        {
            var medicoEntity = await _repository.GetByEstabelecimentoAsync(estabelecimentoId);
            var resultado = _mapper.Map<IEnumerable<MedicoDTO>>(medicoEntity);
            return resultado;
        }

        public async Task<MedicoDTO> Create(MedicoDTO medico)
        {
            var medicoEntity = _mapper.Map<Medico>(medico);
            await _repository.CreateAsync(medicoEntity);
            var resultado = _mapper.Map<MedicoDTO>(medicoEntity);
            return resultado;
        }

        public async Task<MedicoDTO> Update(MedicoDTO medico)
        {
            var medicoEntity = _mapper.Map<Medico>(medico);
            await _repository.UpdateAsync(medicoEntity);
            var resultado = _mapper.Map<MedicoDTO>(medicoEntity);
            return resultado;
        }

        public async Task Delete(MedicoDTO medico)
        {
            var medicoEntity = _mapper.Map<Medico>(medico);
            await _repository.DeleteAync(medicoEntity);
        }
    }
}
