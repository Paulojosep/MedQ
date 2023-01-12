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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly IRepositorioGenerico<Telefone> _repository;
        private readonly IMapper _mapper;

        public TelefoneService(IRepositorioGenerico<Telefone> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TelefoneDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TelefoneDTO>>(await _repository.AdicionarInclusoes<Telefone, object>(
                x => x.Estabelecimento,
                x => x.Socio).ToListAsync());
        }

        public async Task<TelefoneDTO> GetByIdAsync(int id)
        {
            try
            {
                return _mapper.Map<TelefoneDTO>(await _repository.AdicionarInclusoes<Telefone, object>(
                x => x.Estabelecimento,
                x => x.Socio).Where(x => x.Id == id).FirstAsync());
            }
            catch (ArgumentException ex)
            {
                throw new MedQException("Parametro não pode ser nulo", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new MedQException("Valor não econtrado");
            }
        }

        public async Task<bool> CreateAsync(TelefoneDTO obj)
        {
            try
            {
                var telefoneEntity = _mapper.Map<Telefone>(obj);
                _repository.Adicionar(telefoneEntity);
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

        public async Task<bool> UpdateAsync(TelefoneDTO obj)
        {
            try
            {
                var telefoneEntity = _mapper.Map<Telefone>(obj);
                _repository.Editar(telefoneEntity);
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
    }
}
