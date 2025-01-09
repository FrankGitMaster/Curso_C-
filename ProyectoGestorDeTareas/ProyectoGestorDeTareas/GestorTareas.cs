using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProyectoGestorDeTareas
{
    class GestorTareas
    {

        private static List<TareaPendiente> _listaTareasPendientes = new List<TareaPendiente>();
        private static Dictionary<int, TareaRapida> _listaTareasRapidas = new Dictionary<int, TareaRapida>();
        private static Queue<TareaUrgente> _listaTareasUrgentes = new Queue<TareaUrgente>();

        public static string AgregarTarea<T>(Object collection, T tarea)
        {
            if (collection is List<T> lista)
            {
                lista.Add(tarea);
            }
            else if (collection is Dictionary<int, T> diccionario)
            {
                if (tarea is TareaRapida tareaRapida)
                {
                    diccionario.Add(tareaRapida.Id, tarea);
                }
            }
            else if (collection is Queue<T> cola)
            {
                cola.Enqueue(tarea);
            }
            if (collection is List<T> || collection is Dictionary<int, T> || collection is Queue<T>) return "(i) Nueva tarea creada";
            else return "(!) Error al crear la tarea";
        }

        public static void VerTareas<T>(T collection)
        {
            if (collection is List<T> || collection is Dictionary<int, T> || collection is Queue<T>)
            {
                
            }
        }

        public static void Main(string[] args)
        {
            TareaPendiente tareaPendiente_1 = new TareaPendiente("Tarea pendiente 1", "Descripcion", ECategoria.ESTUDIO, EPrioridad.ALTA);
            TareaRapida tareaRapida_1 = new TareaRapida("Tarea rapida 1");
            TareaRapida tareaRapida_2 = new TareaRapida("Tarea rapida 2");
            TareaUrgente tareaUrgente_1 = new TareaUrgente("Tarea urgente 1", new DateTime(2025, 01, 30, 17, 35, 00));

            Console.WriteLine(AgregarTarea(_listaTareasPendientes, tareaPendiente_1));
            Console.WriteLine(AgregarTarea(_listaTareasRapidas, tareaRapida_1));
            Console.WriteLine(AgregarTarea(_listaTareasRapidas, tareaRapida_2));
            Console.WriteLine(AgregarTarea(_listaTareasUrgentes, tareaUrgente_1));


            _listaTareasPendientes.ForEach(tarea => Console.WriteLine(tarea.VerDetallesTarea()));

            _listaTareasRapidas.Values.ToList().ForEach(tarea => Console.WriteLine(tarea.VerDetallesTarea()));

            _listaTareasUrgentes.ToList().ForEach(tarea => Console.WriteLine(tarea.VerDetallesTarea()));
        }
    }
}
