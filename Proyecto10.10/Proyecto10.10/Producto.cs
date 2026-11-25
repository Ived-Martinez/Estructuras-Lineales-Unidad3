using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto10._10
{
    internal class Producto
    {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public double Precio { get; set; }
            public int Existencias { get; set; }
            public string Categoria { get; set; }

            public Producto(int id, string nombre, double precio, int existencias, string categoria)
            {
                ID = id;
                Nombre = nombre;
                Precio = precio;
                Existencias = existencias;
                Categoria = categoria;
            }

            public override string ToString()
            {
                return $"ID: {ID} | Nombre: {Nombre} | Precio: ${Precio:F2} | Stock: {Existencias} | Categoría: {Categoria}";
            }
        
    }
}

