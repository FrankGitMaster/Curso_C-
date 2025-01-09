using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoGestorDeTareas
    {
    class Program
        {

        private static List<TareaPendiente> _listaTareasPendientes = new List<TareaPendiente>();
        private static Dictionary<int, TareaRapida> _listaTareasRapidas = new Dictionary<int, TareaRapida>();
        private static Queue<TareaUrgente> _listaTareasUrgentes = new Queue<TareaUrgente>();
        public static void Main(string[] args)
            {

            Func<IEnumerable<TareaPendiente>, TareaPendiente, string> functionAgregarTareaPendiente = GestorTareas.AgregarTarea;
            Func<IEnumerable<KeyValuePair<int, TareaRapida>>, TareaRapida, string> functionAgregarTareaRapida = GestorTareas.AgregarTarea;
            Func<IEnumerable<TareaUrgente>, TareaUrgente, string> functionAgregarTareaUrgente = GestorTareas.AgregarTarea;

            TareaPendiente tareaPendiente_1 = new TareaPendiente("Tarea pendiente 1", "Descripcion 1", ECategoria.ESTUDIO, EPrioridad.ALTA);
            TareaPendiente tareaPendiente_2 = new TareaPendiente("Tarea pendiente 2", "Descripcion 2", ECategoria.DEPORTE, EPrioridad.MEDIA);
            TareaRapida tareaRapida_1 = new TareaRapida("Tarea rapida 1");
            TareaRapida tareaRapida_2 = new TareaRapida("Tarea rapida 2");
            TareaUrgente tareaUrgente_1 = new TareaUrgente("Tarea urgente 1", new DateTime(2025, 01, 30, 17, 35, 00));
            TareaUrgente tareaUrgente_2 = new TareaUrgente("Tarea urgente 2", new DateTime(2025, 08, 07, 02, 00, 00));

            // TAREAS PENDIENTES
            Console.WriteLine(GestorTareas.GestionarTarea(functionAgregarTareaPendiente, _listaTareasPendientes, tareaPendiente_1));
            Console.WriteLine(GestorTareas.GestionarTarea(functionAgregarTareaPendiente, _listaTareasPendientes, tareaPendiente_2));
            Console.WriteLine("TAREAS PENDIENTES:\n");
            Console.WriteLine(GestorTareas.VerTareas(_listaTareasPendientes));

            // TAREAS RAPIDAS
            Console.WriteLine(GestorTareas.GestionarTarea(functionAgregarTareaRapida, _listaTareasRapidas, tareaRapida_1));
            Console.WriteLine(GestorTareas.GestionarTarea(functionAgregarTareaRapida, _listaTareasRapidas, tareaRapida_2));
            Console.WriteLine("TAREAS RAPIDAS:\n");
            Console.WriteLine(GestorTareas.VerTareas(_listaTareasRapidas.Values));

            // TAREAS URGENTES
            Console.WriteLine(GestorTareas.GestionarTarea(functionAgregarTareaUrgente, _listaTareasUrgentes, tareaUrgente_1));
            Console.WriteLine(GestorTareas.GestionarTarea(functionAgregarTareaUrgente, _listaTareasUrgentes, tareaUrgente_2));
            Console.WriteLine("TAREAS URGENTES:\n");
            Console.WriteLine(GestorTareas.VerTareas(_listaTareasUrgentes));
            }
        }
    }
