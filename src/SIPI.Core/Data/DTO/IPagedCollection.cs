using System.Collections.Generic;

namespace SIPI.Core.Data.DTO
{
    public interface IPagedCollection<T> : IEnumerable<T>
    {
        int Total { get; }

        IList<T> Rows { get; }
    }
}