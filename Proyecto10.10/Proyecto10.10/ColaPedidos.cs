using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto10._10
{
    internal class ColaPedidos
    {
            private Nodo frente;
            private Nodo final;

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

            public void Encolar(Pedido pedido)
            {
                Nodo nuevo = new Nodo(pedido);
                if (EstaVacia())
                {
                    frente = final = nuevo;
                    return;
                }
                final.Siguiente = nuevo;
                final = nuevo;
            }

            public Pedido Desencolar()
            {
                if (EstaVacia()) return null;

                Pedido atendido = frente.Datos;
                frente = frente.Siguiente;
                if (frente == null)
                    final = null;

                return atendido;
            }

            public bool CancelarPedido(int numero)
            {
                if (EstaVacia()) return false;

                if (frente.Datos.Numero == numero)
                {
                    frente.Datos.Estado = "Cancelado";
                    frente = frente.Siguiente;
                    if (frente == null) final = null;
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
                    if (actual.Siguiente == final)
                        final = actual;
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                return false;
            }

            public void BuscarPorCliente(string nombreCliente)
            {
                bool encontrado = false;
                Nodo actual = frente;
                while (actual != null)
                {
                    if (actual.Datos.Cliente.Equals(nombreCliente, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(actual.Datos);
                        encontrado = true;
                    }
                    actual = actual.Siguiente;
                }
                if (!encontrado)
                    Console.WriteLine("No se encontraron pedidos pendientes para ese cliente.");
            }

            public void MostrarPendientes()
            {
                if (EstaVacia())
                {
                    Console.WriteLine("No hay pedidos pendientes en cola.");
                    return;
                }

                Nodo actual = frente;
                while (actual != null)
                {
                    Console.WriteLine(actual.Datos);
                    actual = actual.Siguiente;
                }
            }

            public int ContarPendientes()
            {
                int count = 0;
                Nodo actual = frente;
                while (actual != null)
                {
                    count++;
                    actual = actual.Siguiente;
                }
                return count;
            }
        
    }
}

