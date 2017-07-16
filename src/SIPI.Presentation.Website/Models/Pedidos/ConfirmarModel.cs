using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Models.Pedidos
{
    public class ConfirmarModel
    {
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

        public IEnumerable<ProvinciaView> Provincias { get; private set; }

        public IEnumerable<LocalidadView> Localidades { get; private set; }

        public IEnumerable<MedioAudiovisualView> Medios { get; private set; }

        public MiembroDireccionModel Miembro { get; private set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de copias debe ser un valor mayor que cero")]
        public int CantidadCopias { get; set; }

        public int Insumos
        {
            get
            {
                var tamanoTotal = Medios.Sum(x => x.Tamano);
                var tamanoInsumo = Convert.ToInt32(ConfigurationManager.AppSettings["Insumo.Tamano"]);
                var insumos = tamanoTotal / tamanoInsumo;
                if (tamanoTotal % tamanoInsumo > 0)
                    insumos++;

                return insumos;
            }
        }

        public decimal CostoTotal
        {
            get
            {
                return Insumos * Convert.ToInt32(ConfigurationManager.AppSettings["Insumo.Precio"]);
            }
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
            Piso = miembro.Piso;
            ProvinciaId = miembro.Provincia.Id;
        }

        [Required(ErrorMessage = "El campo Altura es requerido")]
        public int Altura { get; set; }

        [Required(ErrorMessage = "El campo Calle es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Calle puede contener como máximo 150 caracteres")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "El campo Localidad es requerido")]
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "El campo Piso es requerido")]
        [MaxLength(150, ErrorMessage = "El campo Piso puede contener como máximo 150 caracteres")]
        public string Piso { get; set; }

        [Required(ErrorMessage = "El campo Provincia es requerido")]
        public int ProvinciaId { get; set; }
    }
}