using AutoMapper;
using MedQ.Application.DTOs;
using MedQ.Application.Exceptions;
using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class SocioService : ISocioService
    {
        private readonly IRepositorioGenerico<Socio> _repository;
        private readonly IMapper _mapper;

        public SocioService(IRepositorioGenerico<Socio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SocioDTO>> GetSocioAsync()
        {
            return _mapper.Map<IEnumerable<SocioDTO>>(await _repository.SelecionarTodos());
        }

        public async Task<SocioDTO> GetBySocioAsync(int id, string cpf)
        {
            try
            {
                if (id.Equals(0) && String.IsNullOrEmpty(cpf)) throw new MedQException("Parametro deve ser informado");

                var socio = await _repository.Obter(x => x.Id == id && x.CPF == cpf).FirstOrDefaultAsync();

                if(socio.Equals(null)) throw new MedQException("Usuario não econtrado");
                
                return _mapper.Map<SocioDTO>(socio);
            }
            catch (ArgumentException ex)
            {
                throw new MedQException("Parametro não pode ser nulo", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new MedQException("Valor não econtrado");
            }
            catch(Exception ex)
            {
                throw new MedQException(ex.Message);
            }
        }

        public async Task<bool> CreateAsync(SocioDTO socioDTO)
        {
            try
            {
                var socioEntity = _mapper.Map<Socio>(socioDTO);
                _repository.Adicionar(socioEntity);
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

        public async Task<bool> UpdateAsycn(SocioDTO socioDTO)
        {
            try
            {
                var socioEntity = _mapper.Map<Socio>(socioDTO);
                _repository.Editar(socioEntity);
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

        public async Task DaleteAsync(int id)
        {
            try
            {
                var socioEntity = await _repository.Obter(x => x.Id == id).FirstOrDefaultAsync();
                if (socioEntity == null) throw new MedQException($@"Não foi possivel deletar ID: {id}, ela já foideletada");
                _repository.Deletar(socioEntity);
                await _repository.SalvarAsync();
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
    }
}
