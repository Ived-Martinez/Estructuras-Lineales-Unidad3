using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_1
{
    public class Paciente
    {
        public int Expediente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Prioridad { get; set; }

        // Constructor
        public Paciente(int expediente, string nombre, int edad, int prioridad)
        {
            Expediente = expediente;
            Nombre = nombre;
            Edad = edad;
            Prioridad = prioridad;
        }

        // Mostrar datos del paciente
        public override string ToString()
        {
            return $"Expediente: {Expediente} | " +
                   $"Nombre: {Nombre} | " +
                   $"Edad: {Edad} | " +
                   $"Prioridad: {Prioridad}";
        }
    }
}
