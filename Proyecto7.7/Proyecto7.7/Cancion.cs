using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto7._7
{
    internal class Cancion
    {
     
            public string Nombre { get; set; }
            public string Artista { get; set; }

            public Cancion(string nombre, string artista)
            {
                Nombre = nombre;
                Artista = artista;
            }

            public override string ToString()
            {
                return $"{Nombre} - {Artista}";
            }
        
    }
}

