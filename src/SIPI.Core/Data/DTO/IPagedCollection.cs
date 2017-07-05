using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Data.DTO
{
    public interface IPagedCollection<T>
    {
        int Total { get; }

        IList<T> Rows { get; }
    }
}
