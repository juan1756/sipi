﻿namespace SIPI.Core.Vistas
{
    public class RolView
    {
        public RolView(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string Descripcion { get; private set; }
    }
}