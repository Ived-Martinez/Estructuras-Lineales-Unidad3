using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto6._6
{
    internal class Programs
    {
      
            static void Main(string[] args)
            {
                ListaDoble lista = new ListaDoble();
                int opcion;

                do
                {
                    Console.WriteLine("--- ADMINISTRADOR DE TAREAS (LISTA DOBLE) ---");
                    Console.WriteLine("1. Agregar tarea");
                    Console.WriteLine("2. Eliminar tarea");
                    Console.WriteLine("3. Buscar tarea");
                    Console.WriteLine("4. Modificar tarea");
                    Console.WriteLine("5. Marcar como terminada");
                    Console.WriteLine("6. Mostrar tareas pendientes");
                    Console.WriteLine("7. Ordenar tareas");
                    Console.WriteLine("8. Recorrer lista hacia adelante");
                    Console.WriteLine("9. Recorrer lista hacia atras");
                    Console.WriteLine("0. Salir");
                    Console.Write("Opcion: ");
                    int.TryParse(Console.ReadLine(), out opcion);

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Descripcion: ");
                            string desc = Console.ReadLine();
                            Console.Write("Prioridad: ");
                            int prio = int.Parse(Console.ReadLine());
                            Console.Write("Fecha: ");
                            string fecha = Console.ReadLine();
                            Console.Write("Responsable: ");
                            string resp = Console.ReadLine();
                            lista.Insertar(new Tarea(id, desc, prio, fecha, resp));
                            break;

                        case 2:
                            Console.Write("ID a eliminar: ");
                            Console.WriteLine(lista.Eliminar(int.Parse(Console.ReadLine())) ? "Eliminada." : "No encontrada.");
                            break;

                        case 3:
                            Console.Write("ID a buscar: ");
                            Tarea encontrada = lista.Buscar(int.Parse(Console.ReadLine()));
                            Console.WriteLine(encontrada != null ? encontrada.ToString() : "No encontrada.");
                            break;

                        case 4:
                            Console.Write("ID a modificar: ");
                            int idMod = int.Parse(Console.ReadLine());
                            Console.Write("Nueva descripcion: ");
                            string nDesc = Console.ReadLine();
                            Console.Write("Nueva prioridad: ");
                            int nPrio = int.Parse(Console.ReadLine());
                            Console.Write("Nueva fecha: ");
                            string nFecha = Console.ReadLine();
                            Console.Write("Nuevo responsable: ");
                            string nResp = Console.ReadLine();
                            Console.WriteLine(lista.Modificar(idMod, nDesc, nPrio, nFecha, nResp) ? "Modificada." : "No encontrada.");
                            break;

                        case 5:
                            Console.Write("ID a marcar como terminada: ");
                            Console.WriteLine(lista.MarcarComoTerminada(int.Parse(Console.ReadLine())) ? "Marcada como terminada." : "No encontrada.");
                            break;

                        case 6:
                            lista.MostrarTareasPendientes();
                            break;

                        case 7:
                            lista.OrdenarPorPrioridad();
                            Console.WriteLine("Tareas ordenadas por prioridad.");
                            break;

                        case 8:
                            lista.RecorrerAdelante();
                            break;

                        case 9:
                            lista.RecorrerAtras();
                            break;
                    }
                } while (opcion != 0);
            }
     }
    
}

