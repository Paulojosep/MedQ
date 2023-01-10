using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly IRepositorioGenerico<Telefone> _repositorio;

        public TelefoneRepository(IRepositorioGenerico<Telefone> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Telefone>> GetAllTelefoneAsync()
        {
            return await _repositorio.SelecionarTodos();
        }

        public async Task<Telefone> GetByIdAsync(int id)
        {
            try
            {
                return await _repositorio.Obter(x => x.Id == id).FirstAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Parametro não pode ser nulo", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Valor não econtrado");
            }
        }

        public async Task<Telefone> CreateTelefoneAsync(Telefone telefone)
        {
            try
            {
                _repositorio.Adicionar(telefone);
                await _repositorio.SalvarAsync();
                return telefone;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Erro ao incluir", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }

        public async Task<Telefone> UpdateTelefoneAsync(Telefone telefone)
        {
            try
            {
                _repositorio.Editar(telefone);
                await _repositorio.SalvarAsync();
                return telefone;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Erro ao editar", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }
    }
}
