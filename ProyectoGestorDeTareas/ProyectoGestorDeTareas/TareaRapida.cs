using System.Collections.Generic;

namespace ProyectoGestorDeTareas
    {
    class TareaRapida : Tarea
        {

        public static int Counter { get; private set; }
        public int Id { get; private set; }
        public TareaRapida(string titulo) : base(titulo)
            {
            Counter++;
            Id = Counter;
            }

        public override string VerDetallesTarea() => $"DETALLES DE LA TAREA RAPIDA:\n- Id: {Id}\n- Título: {Titulo}\n";
        }
    }
