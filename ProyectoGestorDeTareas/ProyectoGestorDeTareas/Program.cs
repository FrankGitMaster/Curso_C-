using System;

namespace ProyectoGestorDeTareas
{
    class Program
    {

        public static void Main(string[] args)
        {

            TareaPendiente tareaPendiente_1 = new TareaPendiente("Tarea pendiente 1", "Descripcion 1", ECategoria.ESTUDIO, EPrioridad.ALTA);
            TareaPendiente tareaPendiente_2 = new TareaPendiente("Tarea pendiente 2", "Descripcion 2", ECategoria.DEPORTE, EPrioridad.MEDIA);
            TareaRapida tareaRapida_1 = new TareaRapida("Tarea rapida 1");
            TareaRapida tareaRapida_2 = new TareaRapida("Tarea rapida 2");
            TareaUrgente tareaUrgente_1 = new TareaUrgente("Tarea urgente 1", new DateTime(2025, 01, 30, 17, 35, 00));
            TareaUrgente tareaUrgente_2 = new TareaUrgente("Tarea urgente 2", new DateTime(2025, 08, 07, 02, 00, 00));

            // TAREAS PENDIENTES
            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasPendientes(), tareaPendiente_1));
            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasPendientes(), tareaPendiente_2));
            Console.WriteLine(GestorTareas.VerTareas(GestorTareas.GetListaTareasPendientes()));
            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionEliminarTarea, GestorTareas.GetListaTareasPendientes(), tareaPendiente_1));
            Console.WriteLine(GestorTareas.VerTareas(GestorTareas.GetListaTareasPendientes()));

            // TAREAS RAPIDAS
            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasRapidas(), tareaRapida_1));
            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasRapidas(), tareaRapida_2));
            Console.WriteLine(GestorTareas.VerTareas(GestorTareas.GetListaTareasRapidas().Values));

            // TAREAS URGENTES
            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasUrgentes(), tareaUrgente_1));
            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasUrgentes(), tareaUrgente_2));
            Console.WriteLine(GestorTareas.VerTareas(GestorTareas.GetListaTareasUrgentes()));
        }
    }
}
