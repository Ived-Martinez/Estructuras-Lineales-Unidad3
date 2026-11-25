
using System;

namespace Proyecto_1
{
    internal class Menu
    {
        static Cola pacientes = new Cola();

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== CLINICA =====");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Atender paciente");
                Console.WriteLine("3. Mostrar pacientes");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese una opcion valida.");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Registrar();
                        break;

                    case 2:
                        Atender();
                        break;

                    case 3:
                        pacientes.Mostrar();
                        Console.ReadKey();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }

        static void Registrar()
        {
            Console.Clear();

            Console.WriteLine("===== REGISTRAR PACIENTE =====");

            Console.Write("Expediente: ");
            int expediente = int.Parse(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Prioridad: ");
            int prioridad = int.Parse(Console.ReadLine());

            Paciente paciente = new Paciente(
                expediente, nombre, edad, prioridad);

            pacientes.Encolar(paciente);

            Console.WriteLine("\nPaciente registrado correctamente.");
            Console.ReadKey();
        }

        static void Atender()
        {
            Console.Clear();

            Console.WriteLine("===== ATENDER PACIENTE =====");

            Paciente paciente = pacientes.Desencolar();

            if (paciente == null)
            {
                Console.WriteLine("No hay pacientes.");
            }
            else
            {
                Console.WriteLine("Paciente atendido:");
                Console.WriteLine(paciente);
            }

            Console.ReadKey();
        }
    }
}

