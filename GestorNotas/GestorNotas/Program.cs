using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static GestorNotas.ColorMensajeHelper;

namespace GestorNotas
    {

    class Program
        {
        private static List<Base> _listaPrincipal = new List<Base>();
        //Mensaje de entrada 
        private const string _txtSeleccioneUnaOpcion = "Seleccione una opción: ";
        //Títulos módulos
        private const string _txtTituloGestor = "GESTOR DE NOTAS Y TAREAS:";
        private const string _txtTituloNotas = "NOTAS:";
        private const string _txtTituloNotaRapida = "NOTA RAPIDA:";
        private const string _txtTituloListaNotas = "LISTA DE NOTAS:";
        private const string _txtTituloTarea = "TAREAS:";

        public static void Main(string[] args)
            {
            do
                {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nNOTAS Y TAREAS:");
                Console.ResetColor();
                List<Base> listaPrincipalOrdenada = _listaPrincipal.OrderByDescending(e => e.FechaHoraCreacion).ToList();
                foreach (var elemento in listaPrincipalOrdenada) Console.WriteLine($"{elemento.ToString()}");
                if (listaPrincipalOrdenada.Count == 0) ColorMensaje(3, "No hay notas/tareas\n");
                Console.WriteLine($"{_txtTituloGestor}");
                //Seleccionar opción del menú principal
                Console.Write($"1. Notas\n2. Tareas\n");
                ColorMensaje(0, _txtSeleccioneUnaOpcion);
                string opcionMenuPrincipal = Console.ReadLine();
                switch (opcionMenuPrincipal)
                    {
                    case "1":
                        //Notas
                        Console.Write($"{_txtTituloNotas}\n1. Crear nota rápida\n2. Lista de notas\n3. Volver\n");
                        ColorMensaje(0, _txtSeleccioneUnaOpcion);
                        string opcionCrearNota = Console.ReadLine();
                        switch (opcionCrearNota)
                            {
                            case "1":
                                Console.WriteLine($"{_txtTituloNotaRapida}");
                                string titulo = ValidarValorIngresado("Título");
                                string nota = ValidarValorIngresado("Nota");
                                NotaRapida nuevaNotaRapida = new NotaRapida(titulo, nota);
                                _listaPrincipal.Add(nuevaNotaRapida);
                                ColorMensaje(1, "Nota rápida creada");
                                break;
                            case "2":
                                do
                                    {
                                    List<ListaNotas> coleccionListaNotas = _listaPrincipal.OfType<ListaNotas>().ToList();
                                    Console.Write($"{_txtTituloListaNotas}\n1. Crear Lista\n2. Crear nota en lista\n3. Ver notas en lista\n4. Eliminar nota en lista\n5. Eliminar lista\n6. Volver\n");
                                    ColorMensaje(0, _txtSeleccioneUnaOpcion);
                                    string opcionListaNotas = Console.ReadLine();
                                    switch (opcionListaNotas)
                                        {
                                        case "1": //Crear Lista
                                            Console.WriteLine($"{_txtTituloListaNotas}");
                                            string tituloLista = ValidarValorIngresado("Título lista");
                                            ListaNotas nuevaListaNotas = new ListaNotas(tituloLista);
                                            _listaPrincipal.Add(nuevaListaNotas);
                                            ColorMensaje(1, "Lista creada");
                                            continue;
                                        case "2": //Crear nota en lista
                                            if (coleccionListaNotas.Count <= 0) ColorMensaje(3, "No hay listas: primero debe crear una lista");
                                            else EjecutarActionEnListasNotas(actionCrearNotaListaNotas, coleccionListaNotas);
                                            continue;
                                        case "3": //Ver notas en lista
                                            if (coleccionListaNotas.Count <= 0) ColorMensaje(3, "No hay listas: primero debe crear una lista");
                                            else EjecutarActionEnListasNotas(actionVerNotasLista, coleccionListaNotas);
                                            continue;
                                        case "4": //Eliminar nota en lista
                                            if (coleccionListaNotas.Count <= 0) ColorMensaje(3, "No hay listas: primero debe crear una lista");
                                            else EjecutarActionEnListasNotas(actionEliminarNotaListaNotas, coleccionListaNotas);
                                            continue;
                                        case "5": //Eliminar lista
                                            if (coleccionListaNotas.Count <= 0) ColorMensaje(3, "No hay listas: primero debe crear una lista");
                                            else EjecutarActionEnListasNotas(actionEliminarListaNotas, coleccionListaNotas);
                                            continue;
                                        case "6": //Volver
                                            break;
                                        default:
                                            ColorMensaje(2, "Seleccione una opción válida");
                                            continue;
                                        }
                                    break;
                                    } while (true);
                                break;
                            case "3":
                                break;
                            }
                        break;
                    case "2":
                        //Tareas
                        do
                            {
                            List<Tarea> listaTareas = ListaTareas.GetListaTareas().ToList();
                            Console.Write($"{_txtTituloTarea}\n1. Crear tarea\n2. Ver tareas\n3. Eliminar tarea\n4. Volver\n");
                            ColorMensaje(0, _txtSeleccioneUnaOpcion);
                            string opcionCrearTarea = Console.ReadLine();
                            switch (opcionCrearTarea)
                                {
                                case "1": //Crear tarea
                                    Console.WriteLine($"{_txtTituloTarea}");
                                    string nombre = ValidarValorIngresado("Nombre");
                                    string descripcion = ValidarValorIngresado("Descripción");
                                    Console.WriteLine(Tarea.VerCategoriasTarea());
                                    int categoria = ValidarEnumIngresado<Tarea.CategoriaTarea>("Categoría");
                                    DateTime fechaHoraVencimiento = ValidarFechaIngresada("Fecha de vencimiento (día/mes/año hora:minutos)");
                                    Tarea nuevaTarea = new Tarea(nombre, descripcion, (Tarea.CategoriaTarea)categoria, fechaHoraVencimiento);
                                    ColorMensaje(1, ListaTareas.CrearTarea(nuevaTarea));
                                    _listaPrincipal.Add(nuevaTarea);
                                    continue;
                                case "2": //Ver tareas
                                    if (listaTareas.Count <= 0) ColorMensaje(3, "No hay tareas");
                                    else Console.WriteLine(ListaTareas.VerTareas());
                                    continue;
                                case "3": //Eliminar tarea
                                    Console.WriteLine($"{_txtTituloTarea}");
                                    if (listaTareas.Count <= 0) ColorMensaje(3, "No hay tareas");
                                    else
                                        {
                                        do
                                            {
                                            for (int i = 0; i < listaTareas.Count; i++) Console.Write($"{i + 1}. {listaTareas[i]}");
                                            ColorMensaje(0, "Seleccione una tarea: ");
                                            if (!int.TryParse(Console.ReadLine(), out int tareaSeleccionada) || tareaSeleccionada > listaTareas.Count || tareaSeleccionada <= 0)
                                                {
                                                ColorMensaje(2, "Ingrese un índice válido de la lista");
                                                continue;
                                                }
                                            else
                                                {
                                                ColorMensaje(1, ListaTareas.EliminarTarea(listaTareas[tareaSeleccionada - 1]));
                                                _listaPrincipal.Remove(listaTareas[tareaSeleccionada - 1]);
                                                break;
                                                }
                                            } while (true);
                                        }
                                    continue;
                                case "4":
                                    break;
                                default:
                                    ColorMensaje(2, "Seleccione una opción válida");
                                    continue;
                                }
                            break;
                            } while (true);
                        break;
                    default:
                        ColorMensaje(2, "Seleccione una opción válida");
                        continue;
                    }
                continue;
                } while (true);
            }

        //Action para eliminar una lista de notas de la lista principal
        public static Action<List<ListaNotas>, int> actionEliminarListaNotas = (coleccionListaNotas, indiceLista) =>
        {
            ListaNotas listaAEliminar = coleccionListaNotas[indiceLista - 1];
            _listaPrincipal.Remove(listaAEliminar);
            ColorMensaje(1, "Lista eliminada");
        };

        //Action para crear una nota en la lista pasada por parámetro
        public static Action<List<ListaNotas>, int> actionCrearNotaListaNotas = (coleccionListaNotas, indiceLista) =>
        {
            string campoIngresado = ValidarValorIngresado("Título nota");
            ColorMensaje(1, coleccionListaNotas[indiceLista - 1].CrearNota(campoIngresado));
        };

        //Action para ver las notas almacenadas en la lista pasada por parámetro
        public static Action<List<ListaNotas>, int> actionVerNotasLista = (coleccionListaNotas, indiceLista) =>
        {
            if (coleccionListaNotas[indiceLista - 1].GetListaNotas().Count > 0) Console.WriteLine(coleccionListaNotas[indiceLista - 1].VerNotas());
            else
                {
                Console.WriteLine($"{coleccionListaNotas[indiceLista - 1].TituloListaNotas.ToUpper()}: ");
                ColorMensaje(3, "No hay notas");
                };
        };

        //Action para eliminar una nota de la lista pasada por parámetro
        public static Action<List<ListaNotas>, int> actionEliminarNotaListaNotas = (coleccionListaNotas, indiceLista) =>
        {
            do
                {
                List<Nota> listaNotas = coleccionListaNotas[indiceLista - 1].GetListaNotas().ToList();
                for (int i = 0; i < listaNotas.Count; i++) Console.WriteLine($"{i + 1}. {listaNotas[i].Titulo}");
                ColorMensaje(0, "Seleccione una nota: ");
                if (!int.TryParse(Console.ReadLine(), out int notaSeleccionada) || notaSeleccionada > coleccionListaNotas.Count || notaSeleccionada <= 0)
                    {
                    ColorMensaje(2, "Ingrese un índice válido de la nota");
                    continue;
                    }
                else
                    {
                    ColorMensaje(1, coleccionListaNotas[indiceLista - 1].EliminarNota(listaNotas[notaSeleccionada - 1]));
                    listaNotas.Remove(listaNotas[notaSeleccionada - 1]);
                    break;
                    }
                } while (true);
        };

        //Imprime las listas de notas creadas y ejecuta la función del Action recibido por parámetro
        public static void EjecutarActionEnListasNotas(Action<List<ListaNotas>, int> action, List<ListaNotas> coleccionListaNotas)
            {
            do
                {
                Console.WriteLine($"{_txtTituloListaNotas}");
                for (int i = 0; i < coleccionListaNotas.Count; i++) Console.WriteLine($"{i + 1}. {coleccionListaNotas[i].TituloListaNotas.ToUpper()} / {coleccionListaNotas[i].FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy h:mm:ss tt")}\n - Notas: {coleccionListaNotas[i].GetListaNotas().Count}");
                ColorMensaje(0, "Seleccione una lista: ");
                //Validar que el valor ingresado corresponda a una lista de la List<ListNotas>
                if (!int.TryParse(Console.ReadLine(), out int indiceLista) || indiceLista > coleccionListaNotas.Count || indiceLista <= 0)
                    {
                    ColorMensaje(2, "Seleccione una lista válida");
                    continue;
                    }
                else
                    {
                    action(coleccionListaNotas, indiceLista);
                    break;
                    }
                } while (true);
            }

        //Validar que la fecha ingresada sea válida y cumpla con el formato especificado(patronFecha). Retorna la fecha en formato DateTime
        public static DateTime ValidarFechaIngresada(string nombreCampo)
            {
            string fechaIngresada;
            DateTime fechaVencimiento;
            //Expresión regular para validar formato dd/MM/yyyy HH:mm
            string patronFecha = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4} (0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$";
            do
                {
                fechaIngresada = ValidarValorIngresado(nombreCampo);
                if (!Regex.IsMatch(fechaIngresada, patronFecha))
                    {
                    ColorMensaje(2, "Formato incorrecto"); continue;
                    }
                else if ((DateTime.Parse(fechaIngresada) < DateTime.Now))
                    {
                    ColorMensaje(2, "Formato correcto, pero fecha no válida en el calendario"); continue;
                    }
                else
                    {
                    DateTime.TryParse(fechaIngresada, out fechaVencimiento);
                    break;
                    }
                } while (true);
            return fechaVencimiento;
            }

        //Castear el valor retornado por el método ValidarValorIngresado() para que sea de tipo numérico
        //y validar que su valor corresponda a un valor subyacente del Enum especificado
        public static int ValidarEnumIngresado<T>(string nombreCampo) where T : Enum
            {
            string valor;
            int valorEnum;
            int cantidadCategorias = Enum.GetNames(typeof(T)).ToList().Count;
            do
                {
                valor = ValidarValorIngresado(nombreCampo);
                if (!int.TryParse(valor, out valorEnum)) { ColorMensaje(2, "Seleccione una opción válida"); continue; }
                else if (valorEnum > cantidadCategorias || valorEnum <= 0) { ColorMensaje(2, "Seleccione una opción válida"); continue; }
                else break;
                } while (true);
            return valorEnum;
            }

        //Validar que el valor ingresado no sea nulo o vacío
        public static string ValidarValorIngresado(string nombreCampo)
            {
            string valor = "";
            do
                {
                Console.Write($" - {nombreCampo}: ");
                valor = Console.ReadLine();
                if (string.IsNullOrEmpty(valor)) ColorMensaje(3, $"Ingrese un valor para {nombreCampo}");
                } while (string.IsNullOrEmpty(valor));
            return valor;
            }
        }
    }