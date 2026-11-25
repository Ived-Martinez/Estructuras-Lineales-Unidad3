using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Proyecto9._9
{
    internal class ListaProcesos
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

            public void InsertarProceso(Proceso proceso)
            {
                Nodo nuevo = new Nodo(proceso);
                if (frente == null)
                {
                    frente = nuevo;
                    return;
                }

                Nodo actual = frente;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }

            public Proceso BuscarProceso(int pid)
            {
                Nodo actual = frente;
                while (actual != null)
                {
                    if (actual.Datos.PID == pid)
                        return actual.Datos;
                    actual = actual.Siguiente;
                }
                return null;
            }

            public bool EliminarProceso(int pid)
            {
                if (frente == null) return false;

                if (frente.Datos.PID == pid)
                {
                    frente = frente.Siguiente;
                    return true;
                }

                Nodo actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Datos.PID != pid)
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

