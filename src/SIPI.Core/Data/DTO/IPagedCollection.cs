using System.Collections.Generic;

namespace SIPI.Core.Data.DTO
{
    public interface IPagedCollection<T>
    {
        int Total { get; }

        IList<T> Rows { get; }
    }
}