using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
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

        public MiembroView Miembro { get; private set; }

        public ConfirmarModel(
            IEnumerable<ProvinciaView> provincias,
            IEnumerable<LocalidadView> localidades,
            IEnumerable<MedioAudiovisualView> medios,
            MiembroView miembro)
        {
            Provincias = provincias;
            Localidades = localidades;
            Miembro = miembro;
            Medios = medios;
        }
    }
}