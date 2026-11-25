using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto10._10
{
    internal class ColaPrioridad
    {
            private Nodo frente;

            private class Nodo
            {
                public Pedido Datos;
                public Nodo Siguiente;

                public Nodo(Pedido pedido)
                {
                    Datos = pedido;
                    Siguiente = null;
                }
            }

            public bool EstaVacia()
            {
                return frente == null;
            }

            public void InsertarUrgente(Pedido pedido)
            {
                Nodo nuevo = new Nodo(pedido);

                if (frente == null || pedido.Prioridad < frente.Datos.Prioridad)
                {
                    nuevo.Siguiente = frente;
                    frente = nuevo;
                    return;
                }

                Nodo actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Datos.Prioridad <= pedido.Prioridad)
                {
                    actual = actual.Siguiente;
                }

                nuevo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevo;
            }

            public Pedido AtenderUrgente()
            {
                if (EstaVacia()) return null;

                Pedido urgente = frente.Datos;
                frente = frente.Siguiente;
                return urgente;
            }

            public bool CancelarUrgente(int numero)
            {
                if (EstaVacia()) return false;

                if (frente.Datos.Numero == numero)
                {
                    frente.Datos.Estado = "Cancelado";
                    frente = frente.Siguiente;
                    return true;
                }

                Nodo actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Datos.Numero != numero)
                {
                    actual = actual.Siguiente;
                }

                if (actual.Siguiente != null)
                {
                    actual.Siguiente.Datos.Estado = "Cancelado";
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                return false;
            }

            public void BuscarPorCliente(string nombreCliente)
            {
                Nodo actual = frente;
                while (actual != null)
                {
                    if (actual.Datos.Cliente.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(actual.Datos);
                    }
                    actual = actual.Siguiente;
                }
            }

            public void MostrarUrgentes()
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

