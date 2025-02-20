using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
{
    class ListaTareas : ListaBase
    {

        private LinkedList<Tarea> _listaTareas = new LinkedList<Tarea>();

        // Crear una nueva nota en la lista y retornar mensaje que informa si la nota ha sido agregada con exito
        public string CrearTarea(string nombre, string descripcion, int categoria, string fechaHoraVencimiento)
        {
            string resultado = "";
            try
            {
                Tarea nuevaTarea = new Tarea(nombre, descripcion, (Tarea.CategoriaTarea)categoria, fechaHoraVencimiento);
                if (categoria > Enum.GetValues(typeof(Tarea.CategoriaTarea)).Length || categoria <= 0)
                {
                    resultado = "(x) Error al crear la tarea: La categoría ingresada no es válida";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    // Agregar la tarea a la lista
                    _listaTareas.AddLast(nuevaTarea);
                    resultado = "(i) Tarea creada";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
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

        public override string RetornarElementosLista()
        {
            string tareas = "";
            _listaTareas.OrderBy(tarea => tarea.FechaHoraCreacion).ToList().ForEach(tarea => tareas += tarea.ToString());
            Console.ResetColor();
            return tareas;
        }

        public override string VerElementosLista()
        {
            return $"TAREAS:\n{(_listaTareas.Count > 0 ? RetornarElementosLista() : "No hay tareas")}\n";
        }
    }
}