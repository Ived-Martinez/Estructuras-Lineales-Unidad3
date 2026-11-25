using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Proyecto9._9
{
    internal class ColaCircular
    {
            private Proceso[] datos;
            private int frente;
            private int final;
            private int capacidad;
            private int total;

            public ColaCircular(int capacidad = 10)
            {
                this.capacidad = capacidad;
                datos = new Proceso[capacidad];
                frente = 0;
                final = -1;
                total = 0;
            }

            public void Encolar(Proceso proceso)
            {
                if (total == capacidad) return;
                final = (final + 1) % capacidad;
                datos[final] = proceso;
                total++;
            }

            public Proceso Desencolar()
            {
                if (total == 0) return null;
                Proceso p = datos[frente];
                frente = (frente + 1) % capacidad;
                total--;
                return p;
            }

            public void Rotar()
            {
                if (total > 1)
                    Encolar(Desencolar());
            }

            public void Mostrar()
            {
                for (int i = 0; i < total; i++)
                {
                    int idx = (frente + i) % capacidad;
                    Console.Write(datos[idx].Nombre);
                    if (i < total - 1)
                        Console.Write(" -> ");
                }
                Console.WriteLine();
            }
        
    }
}

