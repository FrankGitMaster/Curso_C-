using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoGestorDeTareas
{
    class Program
    {

        private static string txTSeleccioneOpcion = "- Seleccione una opción: ";
        private static string txtTitulo = "Gestor de tareas";
        private static string txtMenu = $"1. Crear tarea\n2. Editar tarea\n3. Eliminar tarea\n4. Buscar tarea\n5. Ver tareas\n6. Salir\n{txTSeleccioneOpcion}";
        private static string txtMenuTiposTareas = $"\n1. Pendiente\n2. Rapida\n3. Urgente\n{txTSeleccioneOpcion}";

        public static void Main(string[] args)
        {
            Console.Write(txtTitulo.ToUpper() + Environment.NewLine + txtMenu);
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": // Crear tareas
                    Console.Write($"De qué tipo es la tarea?\n{txtMenuTiposTareas}");
                    string opcionTipoTarea = Console.ReadLine();
                    Console.WriteLine("Ingrese los datos de la tarea");
                    Console.Write("- Título: ");
                    string titulo = Console.ReadLine();
                    switch (opcionTipoTarea)
                    {
                        case "1": // Crear tarea pendiente (Título, Descripción, Categoría, Prioridad)
                            Console.Write("- Descripción: ");
                            string descripcion = Console.ReadLine();
                            RecorrerEnum<ECategoria>();
                            Console.Write(txTSeleccioneOpcion);
                            ECategoria categoria = (ECategoria)int.Parse(Console.ReadLine());
                            RecorrerEnum<EPrioridad>();
                            Console.Write(txTSeleccioneOpcion);
                            EPrioridad prioridad = (EPrioridad)int.Parse(Console.ReadLine());
                            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasPendientes(), new TareaPendiente(titulo, descripcion, categoria, prioridad)));
                            break;
                        case "2": // Crear tarea rapida (Título)
                            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasRapidas(), new TareaRapida(titulo)));
                            break;
                        case "3": // Crear tarea urgente (Título, FechaHoraVencimiento)
                            Console.Write("- Fecha y hora de vencimiento (día/mes/año hora:min): ");
                            string fechaHoraVencimiento = Console.ReadLine();
                            Console.WriteLine(GestorTareas.FuncionesTarea(GestorTareas.functionAgregarTarea, GestorTareas.GetListaTareasUrgentes(), new TareaUrgente(titulo, DateTime.Parse(fechaHoraVencimiento))));
                            break;
                    }
                    break;
                case "5":
                    Console.Write($"De qué tipo es la lista?\n{txtMenuTiposTareas}");
                    string opcionTipoLista = Console.ReadLine();
                    /*List<T> tipoLista;*/
                    switch (opcionTipoLista)
                    {
                        case "1":
                            /*tipoLista = GestorTareas.GetListaTareasPendientes();*/
                            break;
                    }
                    break;
                case "6":
                    return;
            }
        }

        public static void RecorrerEnum<T>() where T : Enum
        {
            string[] arrayNames = Enum.GetNames(typeof(T));
            for (int i = 0; i < arrayNames.Length; i++) Console.WriteLine($"{i + 1}. {arrayNames[i]}");
        }
    }
}
