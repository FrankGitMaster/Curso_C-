namespace ListaTareas
    {

    class Program
        {

        public static void Main(string[] args)
            {

            ListaTareas listaTareas = new ListaTareas();

            Console.WriteLine("=== MENÚ ===\n1. Agregar una tarea\n2. Insertar una tarea en una posición específica\n3. Eliminar una tarea por su descripción\n4. Ver todas las tareas\n5. Marcar una tarea como completada\n6. Salir");
            while (true)
                {
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                    {
                    case "1":
                        Console.WriteLine("- Agregar una tarea");
                        listaTareas.AgregarTarea();
                        break;
                    case "2":
                        Console.WriteLine("- Insertar una tarea en una posición específica");
                        listaTareas.InsertarTarea();
                        break;
                    case "3":
                        Console.WriteLine("- Eliminar una tarea por su descripción");
                        listaTareas.EliminarTarea();
                        break;
                    case "4":
                        Console.WriteLine("- Ver todas las tareas");
                        listaTareas.ListarTareas();
                        break;
                    case "5":
                        Console.WriteLine("- Marcar una tarea como completada");
                        listaTareas.MarcarComoCompletada();
                        break;
                    case "6":
                        Console.WriteLine("- Programa finalizado");
                        return;
                    default:
                        Console.WriteLine("Opción invalida");
                        continue;
                    }
                }
            }
        }
    }
