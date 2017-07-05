using SIPI.Core.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Data.EF.DTO
{
    public class PagedCollection<T> : IPagedCollection<T>
    {
        public IList<T> Rows { get; private set; }

        public int Total { get; private set; }

        public PagedCollection(IOrderedQueryable<T> query, IOffsetParams offsetParams)
        {
            Total = query.Count();
            Rows = query
                .Skip(offsetParams.Offset)
                .Take(offsetParams.Limit)
                .ToList();
        }
    }
}
