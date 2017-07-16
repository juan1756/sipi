using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Models.Pedidos
{
    public class ConfirmarDataModel
    {
        public int CantidadCopias { get; set; }

        public int[] Medios { get; set; }
    }
}