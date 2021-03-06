﻿using SIPI.Core.Vistas;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace SIPI.Core.Entidades
{
    public class Operador : Usuario
    {
        protected Operador()
            : base()
        {
            Roles = new Collection<Rol>();
        }

        public Operador(int id, string email, string nombre, string apellido, string contrasena, Rol rol)
            : base(id, email, nombre, apellido, contrasena)
        {
            Roles = new Collection<Rol>();
            Roles.Add(rol);
        }

        public virtual ICollection<Rol> Roles { get; private set; }

        public override UsuarioView GetView()
        {
            return new OperadorView(
                Id,
                Nombre,
                Apellido,
                Email,
                Roles.Select(x => x.GetView()).ToList());
        }

        public bool TengoRol(string rol)
        {
            return Roles.Any(r => r.Nombre.Equals(rol, StringComparison.OrdinalIgnoreCase));
        }
    }
}