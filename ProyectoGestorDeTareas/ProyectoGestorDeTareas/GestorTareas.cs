using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoGestorDeTareas
{
    class GestorTareas
    {

        private static string msjInfo = "(i) ";
        private static string msjError = "(x) ";
        private static string msjInfoTareaAgregada = msjInfo + "Tarea agregada";
        private static string msjErrorTareaAgregada = "Error al agregar tarea: ";
        private static string msjInfoTareaEliminada = msjInfo + "Tarea eliminada";
        private static string msjErrorTareaEliminada = "Error al eliminar tarea: ";
        private static string resultado = "";

        // Metodo que implementa un Func para apuntar a los metodos AgregarTarea(), 
        // collection es object porque esta clase hereda de manera directa a todas las colecciones utilizadas List<T>, Queue<T> y Dictionary<KeyValuePair<Tkey, TValue>> y asi se reutiliza el metodo para todas
        public static string FuncionesTarea<T>(Func<object, T, string> funcTarea, object collection, T tarea)
        {
            return funcTarea(collection, tarea);
        }

        // Metodo para agregar tareas a colecciones
        // collection es object porque esta clase hereda de manera directa a todas las colecciones utilizadas List<T>, Queue<T> y Dictionary<KeyValuePair<Tkey, TValue>> y asi se reutiliza el metodo para todas
        public static string AgregarTarea(object collection, Tarea tarea)
        {
            try
            {
                if (collection is List<TareaPendiente> lista && tarea is TareaPendiente tareaPendiente) lista.Add(tareaPendiente);
                else if (collection is Dictionary<int, TareaRapida> diccionario && tarea is TareaRapida tareaRapida) diccionario.Add(tareaRapida.Id, tareaRapida);
                else if (collection is Queue<TareaUrgente> cola && tarea is TareaUrgente tareaUrgente) cola.Enqueue(tareaUrgente);
                resultado = msjInfoTareaAgregada + "\n";
            }
            catch (Exception ex)
            {
                resultado = msjErrorTareaAgregada + ex.Message + Environment.NewLine;
            }
            return resultado;
        }

        public static string EliminarTarea(object collection, Tarea tarea)
        {
            try
            {
                if (collection is List<TareaPendiente> lista && tarea is TareaPendiente tareaPendiente) lista.Remove(tareaPendiente);
                else if (collection is Dictionary<int, TareaRapida> diccionario && tarea is TareaRapida tareaRapida) diccionario.Remove(tareaRapida.Id);
                else if (collection is Queue<TareaUrgente> cola) cola.Dequeue();
                resultado = msjInfoTareaEliminada + "\n";
            }
            catch (Exception ex)
            {
                resultado = msjErrorTareaEliminada + ex.Message + Environment.NewLine;
            }
            return resultado;
        }

        // Metodo para retornar las tareas almacenadas en las colecciones.
        // IEnumerable<T> es implementada por List<T>, Dictionary<TKey, TValue>.Values y Queue<T>
        // Cuando collection es un Dictionary, el parametro recibido debe ser Dictionary<TKey, TValue>.Values para obtener una collecion de los Values del diccionario
        public static string VerTareas<T>(IEnumerable<T> collection)
        {
            resultado = "";
            string nombreLista = collection.First().GetType().Name;
            string resultadoNombreLista = string.Concat(nombreLista.Select(a => char.IsUpper(a) ? " " + a : a.ToString())).Trim().ToUpper();
            Console.WriteLine(resultadoNombreLista + ":");
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
