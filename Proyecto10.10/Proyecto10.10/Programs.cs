using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto10._10
{
    internal class Programs
    {
      static ListaProductos inventario = new ListaProductos();
            static ColaPedidos colaPendientes = new ColaPedidos();
            static ColaPrioridad colaUrgentes = new ColaPrioridad();
            static PilaHistorial historial = new PilaHistorial();
            static double totalVentasProcesadas = 0;

            static void Main(string[] args)
            {
                int opcion;

                do
                {
                    Console.WriteLine("\n=== SISTEMA DE GESTIÓN DE PEDIDOS ===");
                    Console.WriteLine("1. Registrar producto");
                    Console.WriteLine("2. Buscar producto");
                    Console.WriteLine("3. Eliminar producto");
                    Console.WriteLine("4. Registrar pedido");
                    Console.WriteLine("5. Cancelar pedido");
                    Console.WriteLine("6. Procesar pedido");
                    Console.WriteLine("7. Atender pedido urgente");
                    Console.WriteLine("8. Mostrar pedidos pendientes");
                    Console.WriteLine("9. Mostrar historial");
                    Console.WriteLine("10. Consultar inventario");
                    Console.WriteLine("11. Buscar cliente");
                    Console.WriteLine("12. Mostrar estadisticas");
                    Console.WriteLine("0. Salir");
                    Console.Write("Opción: ");

                    if (!int.TryParse(Console.ReadLine(), out opcion))
                        opcion = -1;

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("ID Producto: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Precio: ");
                            double precio = double.Parse(Console.ReadLine());
                            Console.Write("Existencias: ");
                            int existencias = int.Parse(Console.ReadLine());
                            Console.Write("Categoría: ");
                            string categoria = Console.ReadLine();

                            inventario.Insertar(new Producto(id, nombre, precio, existencias, categoria));
                            historial.Apilar($"Registró producto #{id} ({nombre})");
                            Console.WriteLine("Producto registrado.");
                            break;

                        case 2:
                            Console.Write("ID de producto a buscar: ");
                            Producto prod = inventario.Buscar(int.Parse(Console.ReadLine()));
                            Console.WriteLine(prod != null ? prod.ToString() : "Producto no encontrado.");
                            break;

                        case 3:
                            Console.Write("ID de producto a eliminar: ");
                            int idElim = int.Parse(Console.ReadLine());
                            if (inventario.Eliminar(idElim))
                            {
                                historial.Apilar($"Eliminó producto #{idElim}");
                                Console.WriteLine("Producto eliminado.");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró el producto.");
                            }
                            break;

                        case 4:
                            Console.Write("Número de pedido: ");
                            int num = int.Parse(Console.ReadLine());
                            Console.Write("Cliente: ");
                            string cliente = Console.ReadLine();
                            Console.Write("Fecha: ");
                            string fecha = Console.ReadLine();
                            Console.Write("Productos: ");
                            string productos = Console.ReadLine();
                            Console.Write("Total: ");
                            double total = double.Parse(Console.ReadLine());
                            Console.Write("Prioridad (1 = Urgente, 2 = Normal): ");
                            int prioridad = int.Parse(Console.ReadLine());

                            Pedido nuevoPedido = new Pedido(num, cliente, fecha, productos, total, prioridad);
                            if (prioridad == 1)
                            {
                                colaUrgentes.InsertarUrgente(nuevoPedido);
                                historial.Apilar($"Registró pedido URGENTE #{num} de {cliente}");
                            }
                            else
                            {
                                colaPendientes.Encolar(nuevoPedido);
                                historial.Apilar($"Registró pedido pendiente #{num} de {cliente}");
                            }
                            Console.WriteLine("Pedido registrado.");
                            break;

                        case 5:
                            Console.Write("Número de pedido a cancelar: ");
                            int numCanc = int.Parse(Console.ReadLine());
                            if (colaPendientes.CancelarPedido(numCanc) || colaUrgentes.CancelarUrgente(numCanc))
                            {
                                historial.Apilar($"Canceló pedido #{numCanc}");
                                Console.WriteLine("Pedido cancelado.");
                            }
                            else
                            {
                                Console.WriteLine("Pedido no encontrado en pendientes ni urgentes.");
                            }
                            break;

                        case 6:
                            Pedido proc = colaPendientes.Desencolar();
                            if (proc != null)
                            {
                                proc.Estado = "Procesado";
                                totalVentasProcesadas += proc.Total;
                                historial.Apilar($"Procesó pedido #{proc.Numero} (${proc.Total:F2})");
                                Console.WriteLine($"Procesado: {proc}");
                            }
                            else
                            {
                                Console.WriteLine("No hay pedidos pendientes por procesar.");
                            }
                            break;

                        case 7:
                            Pedido urg = colaUrgentes.AtenderUrgente();
                            if (urg != null)
                            {
                                urg.Estado = "Procesado";
                                totalVentasProcesadas += urg.Total;
                                historial.Apilar($"Atendió pedido urgente #{urg.Numero} (${urg.Total:F2})");
                                Console.WriteLine($"Atendido urgente: {urg}");
                            }
                            else
                            {
                                Console.WriteLine("No hay pedidos urgentes en cola.");
                            }
                            break;

                        case 8:
                            Console.WriteLine("\n--- PEDIDOS PENDIENTES ---");
                            colaPendientes.MostrarPendientes();
                            Console.WriteLine("\n--- PEDIDOS URGENTES ---");
                            colaUrgentes.MostrarUrgentes();
                            break;

                        case 9:
                            Console.WriteLine("\n--- HISTORIAL DE OPERACIONES ---");
                            historial.MostrarHistorial();
                            break;

                        case 10:
                            Console.WriteLine("\n--- INVENTARIO DE PRODUCTOS ---");
                            inventario.MostrarInventario();
                            break;

                        case 11:
                            Console.Write("Nombre del cliente a buscar: ");
                            string cliBuscar = Console.ReadLine();
                            colaPendientes.BuscarPorCliente(cliBuscar);
                            colaUrgentes.BuscarPorCliente(cliBuscar);
                            break;

                        case 12:
                            Console.WriteLine("\n--- ESTADÍSTICAS ---");
                            Console.WriteLine($"Productos registrados: {inventario.ContarProductos()}");
                            Console.WriteLine($"Pedidos pendientes en cola: {colaPendientes.ContarPendientes()}");
                            Console.WriteLine($"Operaciones en historial: {historial.ContarOperaciones()}");
                            Console.WriteLine($"Total de ventas procesadas: ${totalVentasProcesadas:F2}");
                            break;
                    }

                } while (opcion != 0);
            }
        }
    
}

