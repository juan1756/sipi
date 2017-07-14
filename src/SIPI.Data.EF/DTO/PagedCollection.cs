using SIPI.Core.Data.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Data.EF.DTO
{
    public class PagedCollection<T> : IPagedCollection<T>
    {
        public IList<T> Rows { get; private set; }

        public int Total { get; private set; }

        public PagedCollection(IOrderedQueryable<T> query, int offset, int limit)
        {
            Total = query.Count();
            Rows = query
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Rows.GetEnumerator();
        }
    }
}