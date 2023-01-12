using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IRepositorioGenerico<T> : IConsultaGenerico<T> where T : class
    {
        Task<T[]> SelecionarTodos();
        Task<T> ObterPorCodigoAsync(int id);
        T Adicionar(T entity);
        T Editar(T entity);
        void Deletar(T entity);
        Task<bool> SalvarAsync();
    }

    public interface IConsultaGenerico<T> where T : class
    {
        IQueryable<T> IQueryable();
    }
}
