using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto6._6
{
    public class Tarea
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public int Prioridad { get; set; }
            public string Fecha { get; set; }
            public string Estado { get; set; }
            public string Responsable { get; set; }

            public Tarea(int id, string descripcion)
            {
                Id = id;
                Descripcion = descripcion;
                Estado = "Pendiente";
            }

            public Tarea(int id, string descripcion, int prioridad, string fecha, string responsable)
            {
                Id = id;
                Descripcion = descripcion;
                Prioridad = prioridad;
                Fecha = fecha;
                Responsable = responsable;
                Estado = "Pendiente";
            }

            public override string ToString()
            {
                return $"{Id} - {Descripcion} - {Estado}";
            }
        
    }
}

