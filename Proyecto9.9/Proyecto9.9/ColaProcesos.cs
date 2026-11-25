using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Proyecto9._9
{
    internal class ColaProcesos
    {
     
            private Nodo frente;

            private class Nodo
            {
                public Proceso Datos;
                public Nodo Siguiente;

                public Nodo(Proceso proceso)
                {
                    Datos = proceso;
                    Siguiente = null;
                }
            }

            public bool EstaVacia()
            {
                return frente == null;
            }

            public void InsertarProceso(Proceso proceso)
            {
                Nodo nuevo = new Nodo(proceso);

                if (frente == null || proceso.Prioridad < frente.Datos.Prioridad)
                {
                    nuevo.Siguiente = frente;
                    frente = nuevo;
                    return;
                }

                Nodo actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Datos.Prioridad <= proceso.Prioridad)
                {
                    actual = actual.Siguiente;
                }

                nuevo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevo;
            }

            public Proceso EjecutarSiguiente(int quantum)
            {
                if (frente == null) return null;

                Proceso actual = frente.Datos;
                frente = frente.Siguiente;

                actual.Estado = EstadoProceso.EJECUTANDO;
                Console.WriteLine($"Ejecutando -> {actual}");

                if (actual.TiempoEjecucion <= quantum)
                {
                    actual.TiempoEjecucion = 0;
                    actual.Estado = EstadoProceso.TERMINADO;
                }
                else
                {
                    actual.TiempoEjecucion -= quantum;
                    actual.Estado = EstadoProceso.LISTO;
                    InsertarProceso(actual);
                }

                return actual;
            }

            public void QuitarPorPID(int pid)
            {
                if (frente == null) return;

                if (frente.Datos.PID == pid)
                {
                    frente = frente.Siguiente;
                    return;
                }

                Nodo actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Datos.PID != pid)
                {
                    actual = actual.Siguiente;
                }

                if (actual.Siguiente != null)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
            }

            public void Mostrar()
            {
                Nodo actual = frente;
                while (actual != null)
                {
                    Console.Write(actual.Datos.Nombre);
                    if (actual.Siguiente != null)
                        Console.Write(" -> ");
                    actual = actual.Siguiente;
                }
                Console.WriteLine();
            }
        }
    
}

