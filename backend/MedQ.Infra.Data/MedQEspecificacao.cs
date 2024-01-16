using MedQ.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Infra.Data
{
    public static class MedQEspecificacao
    {
        public static IQueryable<T> AdicionarInclusoes<T, TProperty>(this IConsultaGenerico<T> source, params Expression<Func<T, TProperty>>[] expressionIncludes) where T : class
        {
            var query = source.IQueryable();

            if(expressionIncludes != null)
            {
                foreach(var incluede in expressionIncludes)
                {
                    query = (query).Include(incluede);
                }
            }
            return query;
        }

        public static IQueryable<T> Obter<T>(this IConsultaGenerico<T> source, Expression<Func<T, bool>> parametroConsulta) where T : class
        {
            var query = source.IQueryable();
            return query.Where(parametroConsulta);
        }

        public static async Task<ListaPaginada<T>> PaginarAsync<T>(this IQueryable<T> query, ParametroPaginacao<T> filtro)
        {
            var quantidade = await query.CountAsync();

            if (!string.IsNullOrEmpty(filtro.OrderBy))
            {
                string orderBy = filtro.OrderBy[0].ToString().ToUpper() + filtro.OrderBy.Substring(1);
                if (filtro.Ordem.Equals(1))
                    query = query.OrderByDescending(p => Microsoft.EntityFrameworkCore.EF.Property<T>(p!, orderBy));
                else
                    query = query.OrderBy(p => Microsoft.EntityFrameworkCore.EF.Property<T>(p!, orderBy));
            }

            var lista = await query.Skip(filtro.PaginaAtual() * filtro.Tamanho).Take(filtro.Tamanho).ToListAsync();

            return new ListaPaginada<T>(lista);
        }
    }
}
