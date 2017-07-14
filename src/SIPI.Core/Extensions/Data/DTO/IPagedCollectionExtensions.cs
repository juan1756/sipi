using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Core.Data.DTO
{
    public static class IPagedCollectionExtensions
    {
        public static IPagedCollection<T2> Convert<T, T2>(this IPagedCollection<T> page, Func<T, T2> converter)
        {
            return new ConvertedPagedCollection<T, T2>(page, converter);
        }

        private class ConvertedPagedCollection<T, T2> : IPagedCollection<T2>
        {
            public IList<T2> Rows { get; private set; }

            public int Total { get; private set; }

            public ConvertedPagedCollection(IPagedCollection<T> page, Func<T, T2> converter)
            {
                Rows = page.Rows.Select(converter).ToList();
                Total = page.Total;
            }

            public IEnumerator<T2> GetEnumerator()
            {
                return Rows.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Rows.GetEnumerator();
            }
        }
    }
}