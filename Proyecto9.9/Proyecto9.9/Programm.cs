using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto9._9
{
    internal class Programm
    {
            static ListaProcesos lista = new ListaProcesos();
            static ColaProcesos cola = new ColaProcesos();
            static ColaCircular colaCircular = new ColaCircular();

            static void Main(string[] args)
            {
                CrearProceso(1, "P01", 1, 5);
                CrearProceso(2, "P02", 2, 4);
                CrearProceso(3, "P03", 1, 6);
                CrearProceso(4, "P04", 3, 3);

                int op;
                do
                {
                    Console.WriteLine("1. Crear proceso");
                    Console.WriteLine("2. Eliminar proceso");
                    Console.WriteLine("3. Ejecutar proceso");
                    Console.WriteLine("4. Bloquear proceso");
                    Console.WriteLine("5. Desbloquear proceso");
                    Console.WriteLine("6. Mostrar procesos");
                    Console.WriteLine("7. Buscar proceso");
                    Console.WriteLine("8. Administrar cola de procesos");
                    Console.WriteLine("0. Salir");
                    Console.Write("Opción: ");
                    int.TryParse(Console.ReadLine(), out op);

                    switch (op)
                    {
                        case 1:
                            Console.Write("PID: ");
                            int pid = int.Parse(Console.ReadLine());
                            Console.Write("Nombre: ");
                            string nom = Console.ReadLine();
                            Console.Write("Prioridad: ");
                            int prio = int.Parse(Console.ReadLine());
                            Console.Write("Tiempo de ejecución: ");
                            int tie = int.Parse(Console.ReadLine());
                            CrearProceso(pid, nom, prio, tie);
                            break;
                        case 2:
                            Console.Write("PID a eliminar: ");
                            EliminarProceso(int.Parse(Console.ReadLine()));
                            break;
                        case 3:
                            Console.Write("Quantum: ");
                            cola.EjecutarSiguiente(int.Parse(Console.ReadLine()));
                            break;
                        case 4:
                            Console.Write("PID a bloquear: ");
                            BloquearProceso(int.Parse(Console.ReadLine()));
                            break;
                        case 5:
                            Console.Write("PID a desbloquear: ");
                            DesbloquearProceso(int.Parse(Console.ReadLine()));
                            break;
                        case 6:
                            lista.Mostrar();
                            break;
                        case 7:
                            Console.Write("PID a buscar: ");
                            Proceso p = lista.BuscarProceso(int.Parse(Console.ReadLine()));
                            Console.WriteLine(p != null ? p.ToString() : "No encontrado");
                            break;
                        case 8:
                            Console.Write("Cola: ");
                            cola.Mostrar();
                            Console.Write("Cola circular: ");
                            colaCircular.Mostrar();
                            colaCircular.Rotar();
                            Console.Write("Rotada: ");
                            colaCircular.Mostrar();
                            break;
                    }
                } while (op != 0);
            }

            static void CrearProceso(int pid, string nombre, int prioridad, int tiempo)
            {
                Proceso p = new Proceso(pid, nombre, prioridad, tiempo);
                lista.InsertarProceso(p);
                p.Estado = EstadoProceso.LISTO;
                cola.InsertarProceso(p);
                colaCircular.Encolar(p);
            }

            static void EliminarProceso(int pid)
            {
                cola.QuitarPorPID(pid);
                lista.EliminarProceso(pid);
            }

            static void BloquearProceso(int pid)
            {
                Proceso p = lista.BuscarProceso(pid);
                if (p != null && p.Estado != EstadoProceso.TERMINADO)
                {
                    cola.QuitarPorPID(pid);
                    p.Estado = EstadoProceso.BLOQUEADO;
                }
            }

            static void DesbloquearProceso(int pid)
            {
                Proceso p = lista.BuscarProceso(pid);
                if (p != null && p.Estado == EstadoProceso.BLOQUEADO)
                {
                    p.Estado = EstadoProceso.LISTO;
                    cola.InsertarProceso(p);
                }
            }
     
    }
    
}

