using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Data.DTO
{
    public interface IOffsetParams
    {
        int Offset { get; }

        int Limit { get; }
    }
}
