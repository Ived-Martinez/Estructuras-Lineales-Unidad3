using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto10._10
{
    internal class PilaHistorial
    {
            private Nodo tope;

            private class Nodo
            {
                public string Operacion;
                public Nodo Siguiente;

                public Nodo(string operacion)
                {
                    Operacion = operacion;
                    Siguiente = null;
                }
            }

            public void Apilar(string operacion)
            {
                Nodo nuevo = new Nodo(operacion);
                nuevo.Siguiente = tope;
                tope = nuevo;
            }

            public void MostrarHistorial()
            {
                if (tope == null)
                {
                    Console.WriteLine("El historial está vacío.");
                    return;
                }

                Nodo actual = tope;
                while (actual != null)
                {
                    Console.WriteLine($"- {actual.Operacion}");
                    actual = actual.Siguiente;
                }
            }

            public int ContarOperaciones()
            {
                int count = 0;
                Nodo actual = tope;
                while (actual != null)
                {
                    count++;
                    actual = actual.Siguiente;
                }
                return count;
            }
        }
    
}

