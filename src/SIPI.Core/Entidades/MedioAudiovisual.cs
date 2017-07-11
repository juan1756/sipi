using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SIPI.Core.Entidades
{
    public class MedioAudiovisual
    {
        protected MedioAudiovisual()
        {
            Oradores = new Collection<Orador>();
        }

        public MedioAudiovisual(Categoria categoria, string tema, Tipo tipo, string url, int tamano)
            :this()
        {
            Categoria = categoria;
            Tema = tema;
            Tipo = tipo;
            Url = url;
            Tamano = tamano;
        }

        public int Id { get; private set; }

        public virtual Categoria Categoria { get; private set; }

        public DateTime FechaGrabacion { get; private set; }

        public virtual ICollection<Orador> Oradores { get; private set; }

        public string Tema { get; private set; }

        public Tipo Tipo { get; private set; }

        public string Url { get; private set; }

        public int Tamano { get; private set; }

        public MedioAudiovisualView GetView()
        {
            return new MedioAudiovisualView(Id, FechaGrabacion, Categoria.Nombre, Tema, Tipo.Nombre, Url);
        }
    }
}