namespace ListaTareas
    {
    class ListaTareas
        {

        private LinkedList<Tarea> _listaTareas;

        public ListaTareas()
            {
            _listaTareas = new LinkedList<Tarea>();
            }

        public void AgregarTarea()
            {
            string descripcion;
            Tarea tarea;
            do
                {
                Console.Write("Ingrese la descripción de la tarea: ");
                descripcion = Console.ReadLine();
                } while (descripcion == "");
            tarea = new Tarea(descripcion);
            _listaTareas.AddLast(tarea);
            Console.WriteLine("Tarea agregada");
            }

        public void InsertarTarea()
            {
            List<Tarea> nuevaListaTareas = _listaTareas.ToList(); // Creo una List con los nodos(elementos) de la LinkedList para poder usar el metodo Insert de la clase List
            Tarea nuevaTarea;
            string descripcion;
            do // Repito el bucle...
                {
                Console.Write("Ingrese la descripción de la tarea: ");
                descripcion = Console.ReadLine();
                } while (descripcion == ""); // ...mientras el valor a la variable descripcion sea vacío
            int posicion;
            while (true) // Repito el bucle hasta que el valor ingresado sea...
                {
                Console.Write("En que posición desde insertar la tarea?: ");
                if (!Int32.TryParse(Console.ReadLine(), out posicion)) // ...númerico
                    {
                    Console.WriteLine("Ingrese un valor númerico para establecer la posición de la nueva tarea");
                    continue;
                    }
                else if (posicion > nuevaListaTareas.Count + 1) // ...menor que la cantidad de elementos de la List + 1(para que pueda ocupar la posición mayor/quedar de último)
                    {
                    Console.WriteLine("El valor ingresado excede la cantidad de elementos de la lista");
                    continue;
                    }
                else if (posicion <= 0) // ... mayor a 0
                    {
                    Console.WriteLine("El valor ingresado debe ser mayor a 0");
                    continue;
                    }
                break; // Rompo el bucle si no se cumple ninguna condición
                }
            nuevaTarea = new Tarea(descripcion); // Creo una nueva instancia de la clase Tarea con el valor de la varibale descripcion
            // El método Insert permite insertar un elemento en una posición específica de una lista. Los elementos existentes desde esa posición se desplazan hacia la derecha.
            nuevaListaTareas.Insert(posicion - 1, nuevaTarea); // Inserto la nueva tarea(tipo Tarea) en la posición - 1(porque el indice empieza en 0)
            _listaTareas.Clear(); // Elimino todos los nodos de la LinkedList para que no se dupliquen al agregarlos con AddList 
            foreach (Tarea tarea in nuevaListaTareas) // Recorro los elementos de la List con la nueva tarea insertada
                {
                _listaTareas.AddLast(tarea); // Agrego los nodos a la LinkedList (se puden agregar porque son del mismo tipo Tarea)
                }
            Console.WriteLine("Tarea insertada");
            }

        public void EliminarTarea()
            {
            int contador = 0;
            string descripcion;
            if (!ListaVacia()) // Si la LikedList no esta vacia ejecuta el resto de la función
                {
                do
                    {
                    Console.Write("Ingrese la descripción de la tarea que desea eliminar: ");
                    descripcion = Console.ReadLine();
                    } while (descripcion == null);
                foreach (Tarea tarea in _listaTareas.ToList())
                    {
                    if (tarea.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase))
                        {
                        _listaTareas.Remove(tarea);
                        contador++;
                        }
                    }
                if (contador > 0)
                    {
                    Console.WriteLine("Tarea eliminada");
                    }
                else
                    {
                    Console.WriteLine("La tarea no existe");
                    }
                }
            else // Si la LinkedList esta vacia muestra este mensaje sin ejecutar nada de la función
                {
                Console.WriteLine("No hay tareas por eliminar");
                }
            }

        public void ListarTareas()
            {
            Console.WriteLine("=== Lista de Tareas ===");
            int enumerador = 1;
            foreach (Tarea tarea in _listaTareas.ToList())
                {
                if (tarea.Completada)
                    {
                    _listaTareas.Remove(tarea);
                    _listaTareas.AddLast(tarea);
                    }
                }
            foreach (Tarea tarea in _listaTareas)
                {
                Console.WriteLine($"{enumerador}. {tarea.Descripcion} - [{tarea.GetCompletada()}]");
                enumerador++;
                }
            if (_listaTareas.Count == 0)
                {
                Console.WriteLine("No hay tareas en la lista");
                }
            }

        public void MarcarComoCompletada()
            {
            int contador = 0;
            string descripcion;
            if (!ListaVacia()) // Si la LinkedList no esta vacía ejecuta el resto del programa
                {
                do
                    {
                    Console.Write("Ingrese la descripción de la tarea a marcar como completada: ");
                    descripcion = Console.ReadLine();
                    } while (descripcion == "");
                foreach (Tarea tarea in _listaTareas.ToList())
                    {
                    // Contains verifica si un fragmento de texto específico está presente dentro de la cadena. Es sensible a mayúsculas y minúsculas.
                    if (tarea.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase)) // tarea.Descripcion es un string, no un elemento de coleccción. En colecciones (List<T>, LinkedList<T>, HashSet<T>, etc.) El método Contains verifica si un elemento existe en la colección. Devuelve un valor booleano
                        {
                        tarea.Completada = true; // Verifica si la tarea esta completada/true
                        _listaTareas.Remove(tarea); // Elimina el nodo de la LinkedList
                        _listaTareas.AddLast(tarea); // Lo agrega de último en la LinkedList
                        contador++;
                        }
                    }
                if (contador > 0)
                    {
                    Console.WriteLine("Tarea marcada como completada.");
                    }
                else
                    {
                    Console.WriteLine("La tarea no existe");
                    }
                }
            else // Si la LinkedList esta vacia muestra este mensaje sin ejecutar nada de la función
                {
                Console.WriteLine("No hay tareas por marcar");
                }
            }

        public bool ListaVacia() // Verificar si la LinkedList tiene nodos
            {
            if (_listaTareas.Count == 0)
                {
                return true;
                }
            else
                {
                return false;
                }
            }
        }
    }
