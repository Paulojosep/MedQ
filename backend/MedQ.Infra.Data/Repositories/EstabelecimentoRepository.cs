using MedQ.Application.Interfaces;
using MedQ.Domain.Entities;
using MedQ.Domain.Interfaces;
using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data.Repositories
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly IRepositorioGenerico<Estabelecimento> _repositorio;

        public EstabelecimentoRepository(IRepositorioGenerico<Estabelecimento> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Estabelecimento>> GetAllAsync()
        {
            return await _repositorio.SelecionarTodos();
        }

        public async Task<IEnumerable<Estabelecimento>> GetBySocioAsync(int socioId)
        {
            return await _repositorio.Obter(x => x.SocioId == socioId).ToListAsync();
        }

        public async Task<Estabelecimento> GetEstabelecimentoAsync(int? id, string? nome)
        {
            if (String.IsNullOrEmpty(nome) && id.Equals(null)) throw new Exception("Parametros deve ser informados");

            var query = _repositorio.IQueryable();
            if (!String.IsNullOrEmpty(nome)) query = query.Where(x => x.Nome == nome);
            if(!id.Equals(null) || id > 0) query = query.Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Estabelecimento> CreateAsync(Estabelecimento estabelecimento)
        {
            try
            {
                _repositorio.Adicionar(estabelecimento);
                await _repositorio.SalvarAsync();
                return estabelecimento;
            }
            catch(DbUpdateException dbException)
            {
                throw new Exception("Erro ao fazer inclusao", dbException);
            }
        }

        public async Task<Estabelecimento> UpdateAsync(Estabelecimento estabelecimento)
        {
            try
            {
                _repositorio.Editar(estabelecimento);
                await _repositorio.SalvarAsync();
                return estabelecimento;
            }
            catch (DbUpdateException dbException)
            {
                throw new Exception("Erro ao Atualizar", dbException);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }

        public async Task DeleteAsync(Estabelecimento estabelecimento)
        {
            try
            {
                _repositorio.Deletar(estabelecimento);
                await _repositorio.SalvarAsync();
            }
            catch(DbUpdateException dbException)
            {
                throw new Exception("Erro ao deletar", dbException);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }
    }
}
