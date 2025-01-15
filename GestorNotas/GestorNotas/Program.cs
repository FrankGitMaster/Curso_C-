using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static GestorNotas.Tarea;

namespace GestorNotas
    {

    class Program
        {
        private static List<Base> _listaPrincipal = new List<Base>();
        // Mensaje de entrada 
        private const string txtSeleccioneUnaOpcion = "Seleccione una opción: ";
        // Títulos módulos
        private const string txtTituloGestor = "GESTOR DE NOTAS Y TAREAS:";
        private const string txtTituloNotas = "NOTAS:";
        private const string txtTituloNotaRapida = "NOTA RAPIDA:";
        private const string txtTituloListaNotas = "LISTA DE NOTAS:";
        private const string txtTituloTarea = "TAREAS:";

        public static void Main(string[] args)
            {
            do
                {
                Console.WriteLine($"\nNOTAS Y TAREAS:\n");
                List<Base> listaPrincipalOrdenada = _listaPrincipal.OrderByDescending(e => e.FechaHoraCreacion).ToList();
                foreach (var elemento in listaPrincipalOrdenada) Console.WriteLine($"{elemento.ToString()}");
                if (listaPrincipalOrdenada.Count == 0) ColorMensaje(1, "No hay notas/tareas");
                Console.WriteLine($"{txtTituloGestor}");
                // Seleccionar opción del menú principal
                Console.Write($"1. Notas\n2. Tareas\n");
                ColorMensaje(3, txtSeleccioneUnaOpcion);
                string opcionMenuPrincipal = Console.ReadLine();
                switch (opcionMenuPrincipal)
                    {
                    case "1":
                        // Notas
                        Console.Write($"{txtTituloNotas}\n1. Crear nota rápida\n2. Lista de notas\n3. Volver\n");
                        ColorMensaje(3, txtSeleccioneUnaOpcion);
                        string opcionCrearNota = Console.ReadLine();
                        switch (opcionCrearNota)
                            {
                            case "1":
                                Console.WriteLine($"{txtTituloNotaRapida}");
                                string titulo = ValidarValorIngresado("Título");
                                string nota = ValidarValorIngresado("Nota");
                                NotaRapida nuevaNotaRapida = new NotaRapida(titulo, nota);
                                _listaPrincipal.Add(nuevaNotaRapida);
                                ColorMensaje(0, "Nota rápida creada");
                                break;
                            case "2":
                                do
                                    {
                                    List<ListaNotas> listasNotas = _listaPrincipal.OfType<ListaNotas>().ToList();
                                    Console.Write($"{txtTituloListaNotas}\n1. Crear Lista\n2. Crear nota en lista\n3. Ver notas en lista\n4. Volver\n");
                                    ColorMensaje(3, txtSeleccioneUnaOpcion);
                                    string opcionListaNotas = Console.ReadLine();
                                    switch (opcionListaNotas)
                                        {
                                        case "1":
                                            Console.WriteLine($"{txtTituloListaNotas}");
                                            string tituloLista = ValidarValorIngresado("Título lista");
                                            ListaNotas nuevaListaNotas = new ListaNotas(tituloLista);
                                            _listaPrincipal.Add(nuevaListaNotas);
                                            ColorMensaje(0, "Lista creada");
                                            continue;
                                        case "2":
                                            if (listasNotas.Count <= 0)
                                                {
                                                ColorMensaje(2, "No hay listas: primero debe crear una lista");
                                                continue;
                                                }
                                            else
                                                {
                                                do
                                                    {
                                                    Console.WriteLine($"{txtTituloListaNotas}");
                                                    for (int i = 0; i < listasNotas.Count; i++) Console.WriteLine($"{i + 1}. {listasNotas[i].TituloListaNotas.ToUpper()} / {listasNotas[i].FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy h:mm:ss tt")}\n - Notas: {listasNotas[i].GetListaNotas().Count}");
                                                    ColorMensaje(3, "Seleccione una lista: ");
                                                    // Validar que el valor ingresado corresponda a un elemento de la List<ListNotas>
                                                    if (!int.TryParse(Console.ReadLine(), out int ListaNotasSeleccionada) || ListaNotasSeleccionada > listasNotas.Count || ListaNotasSeleccionada <= 0)
                                                        {
                                                        ColorMensaje(2, "Seleccione una lista válida");
                                                        continue;
                                                        }
                                                    else
                                                        {
                                                        string tituloNota = ValidarValorIngresado("Título nota");
                                                        Console.WriteLine(listasNotas[ListaNotasSeleccionada - 1].CrearNota(tituloNota));
                                                        Console.ResetColor();
                                                        break;
                                                        }
                                                    } while (true);
                                                }
                                            break;
                                        case "3":
                                            if (listasNotas.Count <= 0)
                                                {
                                                ColorMensaje(2, "No hay listas: primero debe crear una lista");
                                                continue;
                                                }
                                            else
                                                {
                                                do
                                                    {
                                                    Console.WriteLine($"{txtTituloListaNotas}");
                                                    for (int i = 0; i < listasNotas.Count; i++) Console.WriteLine($"{i + 1}. {listasNotas[i].TituloListaNotas.ToUpper()} / {listasNotas[i].FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy h:mm:ss tt")}\n - Notas: {listasNotas[i].GetListaNotas().Count}");
                                                    ColorMensaje(3, "Seleccione una lista: ");
                                                    // Validar que el valor ingresado corresponda a un elemento de la List<ListNotas>
                                                    if (!int.TryParse(Console.ReadLine(), out int ListaNotasSeleccionada) || ListaNotasSeleccionada > listasNotas.Count || ListaNotasSeleccionada <= 0)
                                                        {
                                                        ColorMensaje(2, "Seleccione una lista válida");
                                                        continue;
                                                        }
                                                    else
                                                        {
                                                        Console.WriteLine(listasNotas[ListaNotasSeleccionada - 1].VerElementosLista());
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
                            case "3":
                                break;
                            }
                        break;
                    case "2":
                        // Tareas
                        Console.Write($"{txtTituloTarea}\n1. Crear tarea\n2. Var tareas\n3. Volver\n");
                        ColorMensaje(3, txtSeleccioneUnaOpcion);
                        string opcionCrearTarea = Console.ReadLine();
                        switch (opcionCrearTarea)
                            {
                            case "1":
                                Console.WriteLine($"{txtTituloTarea}");
                                string nombre = ValidarValorIngresado("Nombre");
                                string descripcion = ValidarValorIngresado("Descripción");
                                Console.WriteLine(Tarea.VerCategoriasTarea());
                                int categoria = ValidarEnumIngresado<CategoriaTarea>("Categoría");
                                string fechaHoraVencimiento = ValidarFechaIngresada("Fecha de vencimiento (día/mes/año hora:minutos)");
                                Tarea nuevaTarea = new Tarea(nombre, descripcion, (CategoriaTarea)categoria, fechaHoraVencimiento);
                                _listaPrincipal.Add(nuevaTarea);
                                ColorMensaje(0, "Tarea creada");
                                break;
                            case "2":
                                do
                                    {
                                    List<ListaNotas> listasNotas = _listaPrincipal.OfType<ListaNotas>().ToList();
                                    Console.Write($"{txtTituloListaNotas}\n1. Crear Lista\n2. Crear nota en lista\n3. Ver notas en lista\n4. Volver\n");
                                    ColorMensaje(3, txtSeleccioneUnaOpcion);
                                    string opcionListaNotas = Console.ReadLine();
                                    switch (opcionListaNotas)
                                        {
                                        case "1":
                                            Console.WriteLine($"{txtTituloListaNotas}");
                                            string tituloLista = ValidarValorIngresado("Título lista");
                                            ListaNotas nuevaListaNotas = new ListaNotas(tituloLista);
                                            _listaPrincipal.Add(nuevaListaNotas);
                                            ColorMensaje(0, "Lista creada");
                                            continue;
                                        case "2":
                                            if (listasNotas.Count <= 0)
                                                {
                                                ColorMensaje(2, "No hay listas: primero debe crear una lista");
                                                continue;
                                                }
                                            else
                                                {
                                                do
                                                    {
                                                    Console.WriteLine($"{txtTituloListaNotas}");
                                                    for (int i = 0; i < listasNotas.Count; i++) Console.WriteLine($"{i + 1}. {listasNotas[i].TituloListaNotas.ToUpper()} / {listasNotas[i].FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy h:mm:ss tt")}\n - Notas: {listasNotas[i].GetListaNotas().Count}");
                                                    ColorMensaje(3, "Seleccione una lista: ");
                                                    // Validar que el valor ingresado corresponda a un elemento de la List<ListNotas>
                                                    if (!int.TryParse(Console.ReadLine(), out int ListaNotasSeleccionada) || ListaNotasSeleccionada > listasNotas.Count || ListaNotasSeleccionada <= 0)
                                                        {
                                                        ColorMensaje(2, "Seleccione una lista válida");
                                                        continue;
                                                        }
                                                    else
                                                        {
                                                        string tituloNota = ValidarValorIngresado("Título nota");
                                                        Console.WriteLine(listasNotas[ListaNotasSeleccionada - 1].CrearNota(tituloNota));
                                                        Console.ResetColor();
                                                        break;
                                                        }
                                                    } while (true);
                                                }
                                            break;
                                        case "3":
                                            if (listasNotas.Count <= 0)
                                                {
                                                ColorMensaje(2, "No hay listas: primero debe crear una lista");
                                                continue;
                                                }
                                            else
                                                {
                                                do
                                                    {
                                                    Console.WriteLine($"{txtTituloListaNotas}");
                                                    for (int i = 0; i < listasNotas.Count; i++) Console.WriteLine($"{i + 1}. {listasNotas[i].TituloListaNotas.ToUpper()} / {listasNotas[i].FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy h:mm:ss tt")}\n - Notas: {listasNotas[i].GetListaNotas().Count}");
                                                    ColorMensaje(3, "Seleccione una lista: ");
                                                    // Validar que el valor ingresado corresponda a un elemento de la List<ListNotas>
                                                    if (!int.TryParse(Console.ReadLine(), out int ListaNotasSeleccionada) || ListaNotasSeleccionada > listasNotas.Count || ListaNotasSeleccionada <= 0)
                                                        {
                                                        ColorMensaje(2, "Seleccione una lista válida");
                                                        continue;
                                                        }
                                                    else
                                                        {
                                                        Console.WriteLine(listasNotas[ListaNotasSeleccionada - 1].VerElementosLista());
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
                            case "3":
                                break;
                            }
                        break;
                    default:
                        ColorMensaje(2, "Seleccione una opción válida");
                        continue;
                    }
                continue;
                } while (true);
            }

        // Validar que el valor retornado por el método ValidarValorIngresado() cumpla con el formato especificado por el patrón(patronFecha)
        public static string ValidarFechaIngresada(string nombreCampo)
            {
            string fechaIngresada;
            // Expresión regular para validar formato dd/MM/yyyy HH:mm
            string patronFecha = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4} (0[0-9]|1[0-9]|2[0-3]):([0-5][0-9])$";
            do
                {
                fechaIngresada = ValidarValorIngresado(nombreCampo);
                if(!Regex.IsMatch(fechaIngresada, patronFecha))
                    {
                    ColorMensaje(2, "Formato incorrecto"); continue;
                    }
                else if ((DateTime.Parse(fechaIngresada) < DateTime.Now))
                    {
                    ColorMensaje(2, "Formato correcto, pero fecha no válida en el calendario"); continue;
                    }
                else break; // Si pasa la validación, salir del bucle
                } while (true);
            return fechaIngresada;
            }

        // Validar que el valor retornado por el método ValidarValorIngresado() corresponda al enum especificado
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

        // Validar que el valor ingresado no sea nulo o vacío
        public static string ValidarValorIngresado(string nombreCampo)
            {
            string valor = "";
            do
                {
                Console.Write($" - {nombreCampo}: ");
                valor = Console.ReadLine();
                if (string.IsNullOrEmpty(valor)) ColorMensaje(1, $"Ingrese un valor para {nombreCampo}");
                } while (string.IsNullOrEmpty(valor));
            return valor;
            }

        public static void ColorMensaje(int codigoTipoMensaje, string mensaje)
            {
            if (codigoTipoMensaje == (int)TipoMensaje.Succes)
                {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"(\u221A) {mensaje}");
                }
            else if (codigoTipoMensaje == (int)TipoMensaje.Alert)
                {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"(i) {mensaje}");
                }
            else if (codigoTipoMensaje == (int)TipoMensaje.Error)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"(x) {mensaje}");
                }
            else if (codigoTipoMensaje == (int)TipoMensaje.Input)
                {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" - {mensaje}");
                }
            Console.ResetColor();
            }

        enum TipoMensaje
            {
            Succes,
            Alert,
            Error,
            Input
            }
        }
    }