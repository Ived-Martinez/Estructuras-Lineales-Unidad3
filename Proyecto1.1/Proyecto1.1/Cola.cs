using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_1
{
    internal class Cola
    {


        private Nodo frente;
        private Nodo final;

        // Constructor
        public Cola()
        {
            frente = null;
            final = null;
        }

        // Registrar paciente
        public void Encolar(Paciente paciente)
        {
            Nodo nuevo = new Nodo(paciente);

            if (frente == null)
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        // Atender paciente
        public Paciente Desencolar()
        {
            if (frente == null)
            {
                return null;
            }

            Paciente paciente = frente.Datos;

            frente = frente.Siguiente;

            if (frente == null)
            {
                final = null;
            }

            return paciente;
        }

        // Mostrar pacientes
        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Nodo aux = frente;

            while (aux != null)
            {
                Console.WriteLine(aux.Datos);
                aux = aux.Siguiente;
            }
        }
    }
}

