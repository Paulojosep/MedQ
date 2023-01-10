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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly IRepositorioGenerico<Medico> _repositorio;

        public MedicoRepository(IRepositorioGenerico<Medico> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Medico> GetByIDAsync(int id)
        {
            return await _repositorio.Obter(x => x.Id == id).FirstAsync();
        }

        public async Task<IEnumerable<Medico>> GetByEstabelecimentoAsync(int estabelecimentoId)
        {
            return await _repositorio.AdicionarInclusoes(
                x => x.Especialidade).Where(x => x.EspecialidadeId == estabelecimentoId).ToListAsync();
        }

        public async Task<Medico> CreateAsync(Medico medico)
        {
            try
            {
                _repositorio.Adicionar(medico);
                await _repositorio.SalvarAsync();
                return medico;
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException("Erro ao incluir", ex);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }

        public async Task<Medico> UpdateAsync(Medico medico)
        {
            try
            {
                _repositorio.Editar(medico);
                await _repositorio.SalvarAsync();
                return medico;
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

        public async Task DeleteAync(Medico medico)
        {
            try
            {
                _repositorio.Deletar(medico);
                await _repositorio.SalvarAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Erro ao deletar", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }
    }
}
