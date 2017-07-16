using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Models.Pedidos
{
    public class ConfirmarModel
    {
        public IEnumerable<ProvinciaView> Provincias { get; private set; }

        public IEnumerable<LocalidadView> Localidades { get; private set; }

        public IEnumerable<MedioAudiovisualView> Medios { get; private set; }

        public MiembroDireccionModel Miembro { get; private set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de copias debe ser un valor mayor que cero")]
        public int CantidadCopias { get; set; }

        public ConfirmarModel(
            IEnumerable<ProvinciaView> provincias,
            IEnumerable<LocalidadView> localidades,
            IEnumerable<MedioAudiovisualView> medios,
            MiembroView miembro)
        {
            Provincias = provincias;
            Localidades = localidades;
            Miembro = new MiembroDireccionModel(miembro);
            Medios = medios;
            CantidadCopias = 1;
        }
    }

    public class ConfirmarPedidoModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de copias debe ser un valor mayor que cero")]
        public int CantidadCopias { get; set; }

        public int[] Medios { get; set; }
    }

    public class MiembroDireccionModel
    {
        public MiembroDireccionModel() { }

        public MiembroDireccionModel(MiembroView miembro)
        {
            Altura = miembro.Altura;
            Calle = miembro.Calle;
            LocalidadId = miembro.Localidad.Id;
            Telefono = miembro.Telefono;
            Piso = miembro.Piso;
            ProvinciaId = miembro.Provincia.Id;
        }

        public int Altura { get; set; }

        public string Calle { get; set; }

        public virtual int LocalidadId { get; set; }

        public string Telefono { get; set; }

        public string Piso { get; set; }

        public virtual int ProvinciaId { get; set; }
    }
}