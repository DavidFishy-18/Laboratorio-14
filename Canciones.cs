using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio__14
{
    public class Canciones
    {
        string nombre, artista;
        string duracion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Artista { get => artista; set => artista = value; }
        public string Duracion { get => duracion; set => duracion = value; }
    }
}