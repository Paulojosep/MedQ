using MedQ.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MedQ.Domain.Interfaces;

namespace MedQ.Infra.Data.Repositories
{
    public class RepositorioGenerico<T> : IConsultaGenerico<T>, IRepositorioGenerico<T> where T : class
    {
        private readonly MedQContext _medQContext;

        public Type ElementType => throw new NotImplementedException();
        public Expression Expression => throw new NotImplementedException();
        public IQueryProvider Provider => throw new NotImplementedException();

        public RepositorioGenerico(MedQContext medQContext)
        {
            _medQContext = medQContext;
        }

        public async Task<T[]> SelecionarTodos()
        {
            return await _medQContext.Set<T>().ToArrayAsync();
        }

        public Task<T> ObterPorCodigoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T Adicionar(T entity)
        {
            _medQContext.AddAsync(entity);
            return entity;
        }

        public T Editar(T entity)
        {
            _medQContext.Attach<T>(entity);
            _medQContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Deletar(T entity)
        {
            _medQContext.Set<T>().Remove(entity);
        }

        public async Task<bool> SalvarAsync()
        {
            return (await _medQContext.SaveChangesAsync()) > 0;
        }

        public IQueryable<T> IQueryable()
        {
            return _medQContext.Set<T>();
        }
    }
}
