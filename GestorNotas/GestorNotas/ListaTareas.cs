using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace GestorNotas
    {
    class ListaTareas : Base
        {

        private static LinkedList<Tarea> _listaTareas = new LinkedList<Tarea>();

        // Crear una nueva tarea en la lista y retornar un mensaje que informa si la nota ha sido agregada con éxito
        public static string CrearTarea(Tarea nuevaTarea)
            {
            _listaTareas.AddLast(nuevaTarea);
            return "Tarea creada";
            }

        // Recorrer la lista de tareas ordenando las tareas por FechaHoraCreacion. Retorna todas las tareas en un string
        public static string VerTareas()
            {
            string tareas = "";
            _listaTareas.OrderBy(tarea => tarea.FechaHoraCreacion).ToList().ForEach(tarea => tareas += tarea.ToString());
            return tareas;
            }

        public static string EliminarTarea(Tarea tarea)
            {
            _listaTareas.Remove(tarea);
            return "Tarea eliminada";
            }

        public static List<Tarea> GetListaTareas()
            {
            return _listaTareas.ToList();
            }
        }
    }