using System;
using System.Collections.Generic;

namespace ProyectoGestorDeTareas
    {
    class GestorTareas
        {

        // Implementa un Func que recibe como primer parametro un IEnumerable<T>
        // IEnumerable<T> es la interfaz implementada directamente por List<T> y Queue<T>
        public static string GestionarTarea<T>(Func<IEnumerable<T>, T, string> funcTarea, IEnumerable<T> collection, T tarea)
            {
            return funcTarea(collection, tarea);
            }

        // Sobrecarga
        // Implementa un Func que recibe como primer parametro un IEnumerable<KeyValuePair<int, T>>
        // IEnumerable<KeyValuePair<int, T>> es la interfaz implementada directamente por Dictionary<TKey, TValue>
        public static string GestionarTarea<T>(Func<IEnumerable<KeyValuePair<int, T>>, T, string> funcTarea, IEnumerable<KeyValuePair<int, T>> collection, T tarea)
            {
            return funcTarea(collection, tarea);
            }

        // Metodo para agregar tareas a colecciones de tipo List<T> y Queue<T>
        // collection es IEnumerable<T> porque esta interfaz es implementada de manera directa por List<T> y Queue<T>
        public static string AgregarTarea<T>(IEnumerable<T> collection, T tarea)
            {
            string resultado = "";
            try
                {
                if (collection is List<T> lista) lista.Add(tarea);
                else if (collection is Queue<T> cola) cola.Enqueue(tarea);
                resultado = "(i) Tarea agregada\n";
                }
            catch (Exception ex)
                {
                resultado = "(x) Error al agregar tarea: " + ex.Message + Environment.NewLine;
                }
            return resultado;
            }

        // Sobrecarga
        // Metodo para agregar tareas a colecciones de tipo Dictionary<TKey, TValue>
        // collection es IEnumerable<KeyValuePair<Tkey, TValue>> porque esta interfaz es implementada de manera directa por Dictionary<TKey, TValue>
        public static string AgregarTarea<T>(IEnumerable<KeyValuePair<int, T>> collection, T tarea)
            {
            string resultado = "";
            try
                {
                if (collection is Dictionary<int, T> diccionario && tarea is TareaRapida tareaRapida) diccionario.Add(tareaRapida.Id, tarea);
                resultado = "(i) Tarea agregada\n";
                }
            catch (Exception ex)
                {
                resultado = "(x) Error al agregar tarea: " + ex.Message + Environment.NewLine;
                }
            return resultado;
            }

        // Metodo para retornar las tareas almacenadas en las colecciones.
        // IEnumerable<T> es implementada por List<T>, Dictionary<TKey, TValue>.Values y Queue<T>
        // Cuando collection es un Dictionary, el parametro recibido debe ser Dictionary<TKey, TValue>.Values para obtener una collecion de los Values del diccionario
        public static string VerTareas<T>(IEnumerable<T> collection)
            {
            string resultado = "";
            foreach (var item in collection)
                {
                if (item is Tarea tarea)
                    {
                    resultado += tarea.VerDetallesTarea() + Environment.NewLine;
                    }
                }
            return resultado;
            }
        }
    }
