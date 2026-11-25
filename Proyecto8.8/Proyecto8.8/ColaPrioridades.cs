using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto8._8
{
    internal class ColaPrioridades
    {
            private Nodo frente;
            private class Nodo
            {
                public Cliente Datos;
                public Nodo Siguiente;

                public Nodo(Cliente cliente)
                {
                    Datos = cliente;
                }
            }

            public void InsertarCliente(Cliente cliente)
            {
                Nodo nuevo = new Nodo(cliente);

                if (frente == null ||
                    cliente.Prioridad < frente.Datos.Prioridad)
                {
                    nuevo.Siguiente = frente;
                    frente = nuevo;

                    return;

                }

                Nodo actual = frente;

                while (actual.Siguiente.Datos.Prioridad
                    <= cliente.Prioridad)
                {
                    actual = actual.Siguiente;
                }

                nuevo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevo;
            }

            public Cliente Atender()
            {
                if (frente == null)
                    return null;

                Cliente cliente = frente.Datos;
                frente = frente.Siguiente;
                return cliente;

            }

            public void Mostrar()
            {
                Nodo actual = frente;

                while (actual != null)
                {
                    Console.WriteLine(actual.Datos);
                    actual = actual.Siguiente;
                }
            }

        }
    
}

