using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoGestorDeTareas
    {
    class GestorTareas
        {

        private static List<TareaPendiente> _listaTareasPendientes = new List<TareaPendiente>();
        private static Dictionary<int, TareaRapida> _listaTareasRapidas = new Dictionary<int, TareaRapida>();

        public static void AgregarTarea<T>(Object collection, T tarea)
            {
            Console.WriteLine(collection.GetType().Name);
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
            /*            else if (collection is Queue<T> cola)
                            {
                            cola.Enqueue(tarea);
                            }*/
            else
                {
                Console.WriteLine("Coleccion no soportada");
                }
            }

        public static void Main(string[] args)
            {
            TareaPendiente tareaPendiente_1 = new TareaPendiente("Tarea pendiente 1", "Descripcion", ECategoria.ESTUDIO, EPrioridad.ALTA);
            AgregarTarea(_listaTareasPendientes, tareaPendiente_1);

            TareaRapida tareaRapida_1 = new TareaRapida("Tarea rapida 1");
            AgregarTarea(_listaTareasRapidas, tareaRapida_1);

            TareaRapida tareaRapida_2 = new TareaRapida("Tarea rapida 2");
            AgregarTarea(_listaTareasRapidas, tareaRapida_2);

            _listaTareasPendientes.ForEach(tarea => Console.WriteLine(tarea.VerDetallesTarea()));

            foreach (KeyValuePair<int, TareaRapida> tarea in _listaTareasRapidas)
                {
                Console.WriteLine(tarea.Value.VerDetallesTarea());
                }
            }
        }
    }
