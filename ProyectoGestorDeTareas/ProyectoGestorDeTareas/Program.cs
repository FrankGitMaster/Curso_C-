using System;

namespace ProyectoGestorDeTareas
{
    class Program
    {

        private static string titulo = "Gestor de tareas";
        private static string menu = "1. Crear tarea\n2. Editar tarea\n3. Eliminar tarea\n4. Buscar tarea\n5. Ver tareas\n6. Salir";

        public static void Main(string[] args)
            {

            Console.WriteLine(titulo.ToUpper() + Environment.NewLine + menu);
            string opcion = Console.ReadLine();
            switch (opcion)
                {
                case "1":
                    Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea()));
                    break;
                }
        }
    }
}
