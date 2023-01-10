using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class SocioRepository : ISocioRepository
    {
        private readonly IRepositorioGenerico<Socio> _repositorio;

        public SocioRepository(IRepositorioGenerico<Socio> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<IEnumerable<Socio>> GetSocioAsync()
        {
            return await _repositorio.SelecionarTodos();
        }

        public async Task<Socio> GetBySocioAsync(int? id, string? cpf)
        {
            if (id > 0 && String.IsNullOrEmpty(cpf)) throw new Exception("Parametro deve ser informado");
            try
            {
                var socio = new Socio();
                if(id > 0)
                {
                    socio = await _repositorio.Obter(x => x.Id == id).FirstAsync();
                }
                if (!String.IsNullOrEmpty(cpf))
                {
                    socio = await _repositorio.Obter(x => x.CPF == cpf).FirstAsync();
                }
                return socio;
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException("Parametro não pode ser nulo", ex);
            }
            catch(InvalidOperationException ex)
            {
                throw new InvalidOperationException("Valor não econtrado");
            }
        }

        public async Task<Socio> CreateAsync(Socio socio)
        {
            try
            {
                _repositorio.Adicionar(socio);
                await _repositorio.SalvarAsync();
                return socio;
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

        public async Task<Socio> UpdateAsycn(Socio socio)
        {
            try
            {
                _repositorio.Editar(socio);
                await _repositorio.SalvarAsync();
                return socio;
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

        public async Task DaleteAsync(Socio socio)
        {
            try
            {
                _repositorio.Deletar(socio);
                await _repositorio.SalvarAsync();
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
