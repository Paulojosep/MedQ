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
    public class FilaRepository : IFilaRepository
    {
        private readonly IRepositorioGenerico<Fila> _repositorio;

        public FilaRepository(IRepositorioGenerico<Fila> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Fila>> GetByEstabelecimentoAsync(int estabelecimentoId)
        {
            return await _repositorio.AdicionarInclusoes<Fila, object>(
                x => x.Especialidade,
                x => x.Estabelecimento,
                x => x.TipoAtendimento).ToListAsync(); 
        }

        public async Task<IEnumerable<Fila>> GetByTipoAtendimentoAsync(int tipoAtendimentoId, int estabelecimentoId)
        {
            var filas = _repositorio.AdicionarInclusoes<Fila, object>(
                x => x.Estabelecimento,
                x => x.TipoAtendimento);

            if (tipoAtendimentoId > 0) filas = filas.Where(x => x.TipoAntendimentoId == tipoAtendimentoId);
            if(estabelecimentoId > 0) filas = filas.Where(x => x.EstabelecimentoId == estabelecimentoId);
            return await filas.ToListAsync();
        }

        public async Task<Fila> CreateAsync(Fila fila)
        {
            try
            {
                _repositorio.Adicionar(fila);
                await _repositorio.SalvarAsync();
                return fila;
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
    }
}
