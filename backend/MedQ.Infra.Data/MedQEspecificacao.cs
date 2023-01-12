using MedQ.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
    }
}
