﻿using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Core.Controladores
{
    public class ControladorMediosAudiovisuales
    {
        private readonly IMedioAudiovisualMapper _medios;

        public ControladorMediosAudiovisuales(IMedioAudiovisualMapper medios)
        {
            _medios = medios;
        }

        public IPagedCollection<MedioAudiovisualView> ObtenerCatalogo(int? idCategoria, string tema, DateTime? fechaDesde, DateTime? fechaHasta, int? idTipo, int desde, int cantidad)
        {
            return _medios
                .ObtenerCatalogo(idCategoria, tema, fechaDesde, fechaHasta, idTipo, desde, cantidad)
                .Convert(x => x.GetView());
        }

        public IEnumerable<MedioAudiovisualView> ObtenerMedios(int[] medios)
        {
            return _medios
                .ObtenerMedios(medios)
                .Select(x => x.GetView())
                .ToList();
        }
    }
}