using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IRepositorioGenerico<T> : IConsultaGenerico<T> where T : class
    {
        Task<T[]> SelecionarTodos();
        Task<T> ObterPorCodigoAsync(int id);
        T AdicionarAsync(T entity);
        T EditarAsync(T entity);
        void DeletarAsync(T entity);
        Task<bool> SalvarAsync();
    }

    public interface IConsultaGenerico<T> where T : class
    {
        IQueryable<T> IQueryable();
    }
}
