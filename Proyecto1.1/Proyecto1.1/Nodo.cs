using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_1
{
    internal class Nodo
    {
        public Paciente Datos { get; set; }
        public Nodo Siguiente { get; set; }

        // Constructor
        public Nodo(Paciente paciente)
        {
            Datos = paciente;
            Siguiente = null;
        }
    }
}
