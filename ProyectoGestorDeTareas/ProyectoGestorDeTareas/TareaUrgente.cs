using System;
using System.Diagnostics.Metrics;

namespace ProyectoGestorDeTareas
{
    class TareaUrgente : Tarea
    {
        public static int Counter { get; private set; }
        public DateTime FechaHoraVencimiento = new DateTime();
        public TareaUrgente(string titulo, DateTime fechaHoraVencimiento) : base (titulo)
        {
            Counter++;
            FechaHoraVencimiento = fechaHoraVencimiento;
        }

        public override string VerDetallesTarea() => $"DETALLES DE LA TAREA URGENTE:\n- Título: {Titulo}\n- Fecha vencimiento: {FechaHoraVencimiento.ToString("dddd dd 'de' MMMM 'de' yyyy")}\n- Hora vencimiento: {FechaHoraVencimiento.ToString("hh:mm tt")}";
    }
}
