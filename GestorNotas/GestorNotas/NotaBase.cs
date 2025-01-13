using System;

namespace GestorNotas
{
    abstract class NotaBase
    {

        public DateTime FechaHoraCreacion { get; set; } // Eliminar el set, la fecha se asigna el valor de Now al crear la instancia

        public NotaBase()
        {
            FechaHoraCreacion = DateTime.Now;
        }

        public abstract string VerDetallesNota();
    }
}
