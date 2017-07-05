using SIPI.Core.Data.DTO;
using SIPI.Data.EF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Data.EF.Extensions
{
    public static class IQueryableExtensions
    {
        public static IPagedCollection<T> ToPagedCollection<T>(this IOrderedQueryable<T> query, IOffsetParams offsetParams)
        {
            return new PagedCollection<T>(query, offsetParams);
        }
    }
}
