using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio__14
{
    public class Albumes
    {
        string titulo, artista, fecha;
        List<Canciones> c;

        public Albumes()
        {
            C = new List<Canciones>();
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Artista { get => artista; set => artista = value; }
        public List<Canciones> C { get => c; set => c = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}