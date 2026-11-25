using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto9._9
{
    public enum EstadoProceso
        {
            NUEVO,
            LISTO,
            EJECUTANDO,
            BLOQUEADO,
            TERMINADO
        }

        public class Proceso
        {
            public int PID { get; set; }
            public string Nombre { get; set; }
            public int Prioridad { get; set; }
            public EstadoProceso Estado { get; set; }
            public int TiempoEjecucion { get; set; }

            public Proceso(int pid, string nombre, int prioridad, int tiempoEjecucion)
            {
                PID = pid;
                Nombre = nombre;
                Prioridad = prioridad;
                TiempoEjecucion = tiempoEjecucion;
                Estado = EstadoProceso.NUEVO;
            }

            public override string ToString()
            {
                return $"PID: {PID}, Nombre: {Nombre}, Prioridad: {Prioridad}, Estado: {Estado}, Tiempo: {TiempoEjecucion}";
            }
        }
    
}

