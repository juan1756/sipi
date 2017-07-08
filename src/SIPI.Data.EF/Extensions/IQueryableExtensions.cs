using SIPI.Core.Data.DTO;
using SIPI.Data.EF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQueryableExtensions
    {
        public static IPagedCollection<T> ToPagedCollection<T>(this IOrderedQueryable<T> query, int offset, int limit)
        {
            return new PagedCollection<T>(query, offset, limit);
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, bool when, Expression<Func<T, bool>> expression)
        {
            if (when)
                return query.Where(expression);

            return query;
        }
    }
}
