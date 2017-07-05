using SIPI.Core.Data.DTO;

namespace SIPI.Presentation.Website.Models.Shared
{
    public class OffsetParams : IOffsetParams
    {
        public int Limit { get; set; }

        public int Offset { get; set; }
    }
}