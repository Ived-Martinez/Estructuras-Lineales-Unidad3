using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto10._10
{
    internal class Pedido
    {
            public int Numero { get; set; }
            public string Cliente { get; set; }
            public string Fecha { get; set; }
            public string Productos { get; set; }
            public double Total { get; set; }
            public int Prioridad { get; set; } // Ej. 1 = Urgente, 2+ = Normal
            public string Estado { get; set; }    // Pendiente, Procesado, Cancelado

            public Pedido(int numero, string cliente, string fecha, string productos, double total, int prioridad)
            {
                Numero = numero;
                Cliente = cliente;
                Fecha = fecha;
                Productos = productos;
                Total = total;
                Prioridad = prioridad;
                Estado = "Pendiente";
            }

            public override string ToString()
            {
                return $"Pedido #{Numero} | Cliente: {Cliente} | Fecha: {Fecha} | Productos: {Productos} | Total: ${Total:F2} | Prioridad: {Prioridad} | Estado: {Estado}";
            }
        
    }
}

