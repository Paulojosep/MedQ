using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Exceptions;
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
    public class MedicoService : IMedicoService
    {
        private readonly IRepositorioGenerico<Medico> _repository;
        private readonly IMapper _mapper;

        public MedicoService(IRepositorioGenerico<Medico> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MedicoDTO> GetByID(int id)
        {
            return _mapper.Map<MedicoDTO>(await _repository.Obter(x => x.Id == id).FirstAsync());
        }

        public async Task<IEnumerable<MedicoDTO>> GetByEstabelecimento(int estabelecimentoId)
        {
            return _mapper.Map< IEnumerable<MedicoDTO>>(await _repository.AdicionarInclusoes(
                x => x.Especialidade).Where(x => x.EspecialidadeId == estabelecimentoId).ToListAsync());
        }

        public async Task<bool> Create(MedicoDTO medico)
        {
            try
            {
                var medicoEntity = _mapper.Map<Medico>(medico);
                _repository.Adicionar(medicoEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new MedQException("Erro ao incluir", ex);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task<bool> Update(MedicoDTO medico)
        {
            try
            {
                var medicoEntity = _mapper.Map<Medico>(medico);
                _repository.Editar(medicoEntity);
                return await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new MedQException("Erro ao editar", ex);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }

        public async Task Delete(MedicoDTO medico)
        {
            try
            {
                var medicoEntity = _mapper.Map<Medico>(medico);
                _repository.Deletar(medicoEntity);
                await _repository.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new MedQException("Erro ao deletar", ex);
            }
            catch (Exception ex)
            {
                throw new MedQException("Erro", ex);
            }
        }
    }
}
