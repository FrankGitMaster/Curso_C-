using System;
using System.Collections.Generic;
using System.Linq;

namespace ListaTareas
    {
    class Program
        {
        public static void Main(string[] args)
            {
            ListaTareas listaTareas = new ListaTareas();

            while (true)
                {
                Console.WriteLine("\n=== MENÚ ===");
                Console.WriteLine("1. Agregar una tarea");
                Console.WriteLine("2. Insertar una tarea en una posición específica");
                Console.WriteLine("3. Eliminar una tarea por su descripción");
                Console.WriteLine("4. Ver todas las tareas");
                Console.WriteLine("5. Marcar una tarea como completada");
                Console.WriteLine("6. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                    {
                    case "1":
                        listaTareas.AgregarTarea();
                        break;
                    case "2":
                        listaTareas.InsertarTarea();
                        break;
                    case "3":
                        listaTareas.EliminarTarea();
                        break;
                    case "4":
                        listaTareas.ListarTareas();
                        break;
                    case "5":
                        listaTareas.MarcarComoCompletada();
                        break;
                    case "6":
                        Console.WriteLine("Programa finalizado.");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                    }
                }
            }
        }

    class Tarea
        {
        public string Descripcion { get; set; }
        public bool Completada { get; set; }

        public Tarea(string descripcion)
            {
            Descripcion = descripcion;
            Completada = false;
            }

        public override string ToString()
            {
            return $"{Descripcion} - [{(Completada ? "Completada" : "Pendiente")}]";
            }
        }

    class ListaTareas
        {
        private LinkedList<Tarea> _listaTareas;

        public ListaTareas()
            {
            _listaTareas = new LinkedList<Tarea>();
            }

        public void AgregarTarea()
            {
            string descripcion = LeerDescripcion();
            _listaTareas.AddLast(new Tarea(descripcion));
            Console.WriteLine("Tarea agregada.");
            }

        public void InsertarTarea()
            {
            if (_listaTareas.Count == 0)
                {
                Console.WriteLine("La lista está vacía. Se agregará la tarea al inicio.");
                AgregarTarea();
                return;
                }

            string descripcion = LeerDescripcion();
            int posicion = LeerPosicion();

            LinkedListNode<Tarea> nodoActual = _listaTareas.First;
            for (int i = 1; i < posicion && nodoActual != null; i++)
                {
                nodoActual = nodoActual.Next;
                }

            if (nodoActual != null)
                {
                _listaTareas.AddBefore(nodoActual, new Tarea(descripcion));
                }
            else
                {
                _listaTareas.AddLast(new Tarea(descripcion));
                }

            Console.WriteLine("Tarea insertada.");
            }

        public void EliminarTarea()
            {
            string descripcion = LeerDescripcion();
            var tarea = _listaTareas.FirstOrDefault(t => t.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase));
            if (tarea != null)
                {
                _listaTareas.Remove(tarea);
                Console.WriteLine("Tarea eliminada.");
                }
            else
                {
                Console.WriteLine("No se encontró la tarea especificada.");
                }
            }

        public void ListarTareas()
            {
            if (_listaTareas.Count == 0)
                {
                Console.WriteLine("No hay tareas en la lista.");
                return;
                }

            Console.WriteLine("\n=== Lista de Tareas ===");
            int enumerador = 1;
            foreach (var tarea in _listaTareas)
                {
                Console.WriteLine($"{enumerador}. {tarea}");
                enumerador++;
                }
            }

        public void MarcarComoCompletada()
            {
            string descripcion = LeerDescripcion();
            var tarea = _listaTareas.FirstOrDefault(t => t.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase));
            if (tarea != null)
                {
                tarea.Completada = true;
                _listaTareas.Remove(tarea);
                _listaTareas.AddLast(tarea);
                Console.WriteLine("Tarea marcada como completada.");
                }
            else
                {
                Console.WriteLine("No se encontró la tarea especificada.");
                }
            }

        private string LeerDescripcion()
            {
            string descripcion;
            do
                {
                Console.Write("Ingrese la descripción de la tarea: ");
                descripcion = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(descripcion));

            return descripcion;
            }

        private int LeerPosicion()
            {
            int posicion;
            while (true)
                {
                Console.Write("Ingrese la posición: ");
                if (int.TryParse(Console.ReadLine(), out posicion) && posicion > 0)
                    {
                    return posicion;
                    }

                Console.WriteLine("Ingrese un número válido mayor a 0.");
                }
            }
        }
    }
