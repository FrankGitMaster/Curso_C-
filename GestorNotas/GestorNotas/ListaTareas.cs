using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
    {
    class ListaTareas : Base
        {

        private static LinkedList<Tarea> _listaTareas = new LinkedList<Tarea>();

        // Crear una nueva tarea en la lista y retornar mensaje que informa si la nota ha sido agregada con exito
        public string CrearTarea(string nombre, string descripcion, Tarea.CategoriaTarea categoria, DateTime fechaHoraVencimiento)
            {
            string resultado = "";
            try
                {
                Tarea nuevaTarea = new Tarea(nombre, descripcion, categoria, fechaHoraVencimiento);
                // Agregar la tarea a la lista
                _listaTareas.AddLast(nuevaTarea);
                resultado = "(i) Tarea creada";
                Console.ForegroundColor = ConsoleColor.Green;
                }
            catch (FormatException ex)
                {
                // Aquí capturamos la excepción de formato lanzada en el constructor de Tarea
                resultado = $"(x) Error al crear la tarea: {ex.Message}";
                Console.ForegroundColor = ConsoleColor.Red;
                }
            catch (Exception ex)
                {
                resultado = $"(x) Error inesperado: {ex.Message} {ex.StackTrace}";
                Console.ForegroundColor = ConsoleColor.Red;
                }
            return resultado;
            }

        // Recorrer la lista de tareas ordenando las tareas por FechaHoraCreacion. Retorna todas las tareas en un string
        public static string VerTareas()
            {
            string tareas = "";
            _listaTareas.OrderBy(tarea => tarea.FechaHoraCreacion).ToList().ForEach(tarea => tareas += tarea.ToString());
            Console.ResetColor();
            return tareas;
            }

        public static List<Tarea> GetListaTareas()
            {
            return _listaTareas.ToList();
            }
        }
    }