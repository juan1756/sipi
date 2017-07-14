using System;
using System.Text.RegularExpressions;

namespace SIPI.Core.Vistas
{
    public class MedioAudiovisualView
    {
        public int Id { get; private set; }

        public DateTime FechaGrabacion { get; private set; }

        public string Categoria { get; private set; }

        public string Tema { get; private set; }

        public string Tipo { get; private set; }

        public string Url { get; private set; }

        public MedioAudiovisualView(int id, DateTime fechaGrabacion, string categoria, string tema, string tipo, string url)
        {
            Id = id;
            FechaGrabacion = fechaGrabacion;
            Categoria = categoria;
            Tema = tema;
            Tipo = tipo;
            Url = GenerateEmbedUrl(url);
        }

        private string GenerateEmbedUrl(string url)
        {
            // https://stackoverflow.com/a/15824742
            var rgx = new Regex(@"(?:https?:\/\/)?(?:www\.)?(?:(?:(?:youtube.com\/watch\?[^?]*v=|youtu.be\/)([\w\-]+))(?:[^\s?]+)?)");
            return rgx.Replace(url, "http://www.youtube.com/embed/$1");
        }
    }
}