using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto6._6
{
    public class ListaDoble
    {
      
            private Nodo Inicio;

            private class Nodo
            {
                public Tarea Datos;
                public Nodo Anterior;
                public Nodo Siguiente;

                public Nodo(Tarea tarea)
                {
                    Datos = tarea;
                }
            }

            public void Insertar(Tarea tarea)
            {
                Nodo nuevo = new Nodo(tarea);
                if (Inicio == null)
                {
                    Inicio = nuevo;
                    return;
                }

                Nodo actual = Inicio;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
                nuevo.Anterior = actual;
            }

            public Tarea Buscar(int id)
            {
                Nodo actual = Inicio;
                while (actual != null)
                {
                    if (actual.Datos.Id == id)
                        return actual.Datos;
                    actual = actual.Siguiente;
                }
                return null;
            }

            public void Mostrar()
            {
                Nodo actual = Inicio;
                while (actual != null)
                {
                    Console.WriteLine(actual.Datos);
                    actual = actual.Siguiente;
                }
            }

            public bool Eliminar(int id)
            {
                Nodo actual = Inicio;
                while (actual != null)
                {
                    if (actual.Datos.Id == id)
                    {
                        if (actual.Anterior != null)
                            actual.Anterior.Siguiente = actual.Siguiente;
                        else
                            Inicio = actual.Siguiente;

                        if (actual.Siguiente != null)
                            actual.Siguiente.Anterior = actual.Anterior;

                        return true;
                    }
                    actual = actual.Siguiente;
                }
                return false;
            }

            public bool Modificar(int id, string nuevaDescripcion, int nuevaPrioridad, string nuevaFecha, string nuevoResponsable)
            {
                Tarea tarea = Buscar(id);
                if (tarea == null) return false;

                tarea.Descripcion = nuevaDescripcion;
                tarea.Prioridad = nuevaPrioridad;
                tarea.Fecha = nuevaFecha;
                tarea.Responsable = nuevoResponsable;
                return true;
            }

            public bool MarcarComoTerminada(int id)
            {
                Tarea tarea = Buscar(id);
                if (tarea == null) return false;

                tarea.Estado = "Terminada";
                return true;
            }

            public void MostrarTareasPendientes()
            {
                Nodo actual = Inicio;
                while (actual != null)
                {
                    if (actual.Datos.Estado == "Pendiente")
                        Console.WriteLine(actual.Datos);
                    actual = actual.Siguiente;
                }
            }

            public void OrdenarPorPrioridad()
            {
                if (Inicio == null || Inicio.Siguiente == null) return;

                bool cambiado;
                do
                {
                    cambiado = false;
                    Nodo actual = Inicio;
                    while (actual.Siguiente != null)
                    {
                        if (actual.Datos.Prioridad > actual.Siguiente.Datos.Prioridad)
                        {
                            Tarea temp = actual.Datos;
                            actual.Datos = actual.Siguiente.Datos;
                            actual.Siguiente.Datos = temp;
                            cambiado = true;
                        }
                        actual = actual.Siguiente;
                    }
                } while (cambiado);
            }

            public void RecorrerAdelante()
            {
                Nodo actual = Inicio;
                while (actual != null)
                {
                    Console.WriteLine(actual.Datos);
                    actual = actual.Siguiente;
                }
            }

            public void RecorrerAtras()
            {
                if (Inicio == null) return;

                Nodo actual = Inicio;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }

                while (actual != null)
                {
                    Console.WriteLine(actual.Datos);
                    actual = actual.Anterior;
                }
            }
        
    }
}

