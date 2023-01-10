using MedQ.Application.Interfaces;
using MedQ.Application.IO;
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
    public class MinhasConsultaRepository : IMinhasConsultaRepository
    {
        private readonly IRepositorioGenerico<MinhasConsulta> _repositorio;

        public MinhasConsultaRepository(IRepositorioGenerico<MinhasConsulta> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<MinhasConsulta>> GetAllAsyns()
        {
            return await _repositorio.SelecionarTodos();
        }

        public async Task<string> GetFinishedMensagensAsync(int socioId)
        {
            return await _repositorio.Obter(x => x.SocioId == socioId).Select(s => s.Finished).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateMyConsultationAsync(MinhasConsulta minhasConsulta)
        {
            try
            {
                _repositorio.Adicionar(minhasConsulta);
                return await _repositorio.SalvarAsync();
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

        public async Task<MinhasConsulta> UpdateMyConsultationAsync(MinhasConsulta minhasConsulta)
        {
            try
            {
                _repositorio.Editar(minhasConsulta);
                await _repositorio.SalvarAsync();
                return minhasConsulta;
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

        public async Task DeleteMyConsultationAsync(int id)
        {
            try
            {
                var minhasConsulta = await _repositorio.Obter(x => x.Id == id).FirstAsync();
                _repositorio.Adicionar(minhasConsulta);
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
