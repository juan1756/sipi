using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIPI.Core.Vistas;

namespace SIPI.Core.Entidades
{
    public class Rol
    {
        private Rol() { }

        public Rol(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string Descripcion { get; private set; }

        public RolView GetView()
        {
            return new RolView(Id, Nombre, Descripcion);
        }
    }
}
