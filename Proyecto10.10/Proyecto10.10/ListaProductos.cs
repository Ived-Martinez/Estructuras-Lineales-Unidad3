using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto10._10
{
    internal class ListaProductos
    {
            private Nodo inicio;

            private class Nodo
            {
                public Producto Datos;
                public Nodo Siguiente;

                public Nodo(Producto producto)
                {
                    Datos = producto;
                    Siguiente = null;
                }
            }

            public void Insertar(Producto producto)
            {
                Nodo nuevo = new Nodo(producto);
                if (inicio == null)
                {
                    inicio = nuevo;
                    return;
                }

                Nodo actual = inicio;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }

            public Producto Buscar(int id)
            {
                Nodo actual = inicio;
                while (actual != null)
                {
                    if (actual.Datos.ID == id)
                        return actual.Datos;
                    actual = actual.Siguiente;
                }
                return null;
            }

            public bool Eliminar(int id)
            {
                if (inicio == null) return false;

                if (inicio.Datos.ID == id)
                {
                    inicio = inicio.Siguiente;
                    return true;
                }

                Nodo actual = inicio;
                while (actual.Siguiente != null && actual.Siguiente.Datos.ID != id)
                {
                    actual = actual.Siguiente;
                }

                if (actual.Siguiente != null)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                return false;
            }

            public void MostrarInventario()
            {
                if (inicio == null)
                {
                    Console.WriteLine("No hay productos en el inventario.");
                    return;
                }

                Nodo actual = inicio;
                while (actual != null)
                {
                    Console.WriteLine(actual.Datos);
                    actual = actual.Siguiente;
                }
            }

            public int ContarProductos()
            {
                int total = 0;
                Nodo actual = inicio;
                while (actual != null)
                {
                    total++;
                    actual = actual.Siguiente;
                }
                return total;
            }
        }
    
}

