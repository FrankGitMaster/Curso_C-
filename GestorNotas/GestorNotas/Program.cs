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
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nNOTAS Y TAREAS:");
                Console.ResetColor();
                List<Base> listaPrincipalOrdenada = _listaPrincipal.OrderByDescending(e => e.FechaHoraCreacion).ToList();
                foreach (var elemento in listaPrincipalOrdenada) Console.WriteLine($"{elemento.ToString()}");
                if (listaPrincipalOrdenada.Count == 0) ColorMensaje(3, "No hay notas/tareas\n");
                Console.WriteLine($"{txtTituloGestor}");
                // Seleccionar opción del menú principal
                Console.Write($"1. Notas\n2. Tareas\n");
                ColorMensaje(0, txtSeleccioneUnaOpcion);
                string opcionMenuPrincipal = Console.ReadLine();
                switch (opcionMenuPrincipal)
                    {
                    case "1":
                        // Notas
                        Console.Write($"{txtTituloNotas}\n1. Crear nota rápida\n2. Lista de notas\n3. Volver\n");
                        ColorMensaje(0, txtSeleccioneUnaOpcion);
                        string opcionCrearNota = Console.ReadLine();
                        switch (opcionCrearNota)
                            {
                            case "1":
                                Console.WriteLine($"{txtTituloNotaRapida}");
                                string titulo = ValidarValorIngresado("Título");
                                string nota = ValidarValorIngresado("Nota");
                                NotaRapida nuevaNotaRapida = new NotaRapida(titulo, nota);
                                _listaPrincipal.Add(nuevaNotaRapida);
                                ColorMensaje(1, "Nota rápida creada");
                                break;
                            case "2":
                                do
                                    {
                                    List<ListaNotas> listasNotas = _listaPrincipal.OfType<ListaNotas>().ToList();
                                    Console.Write($"{txtTituloListaNotas}\n1. Crear Lista\n2. Crear nota en lista\n3. Ver notas en lista\n4. Volver\n");
                                    ColorMensaje(0, txtSeleccioneUnaOpcion);
                                    string opcionListaNotas = Console.ReadLine();
                                    switch (opcionListaNotas)
                                        {
                                        case "1":
                                            Console.WriteLine($"{txtTituloListaNotas}");
                                            string tituloLista = ValidarValorIngresado("Título lista");
                                            ListaNotas nuevaListaNotas = new ListaNotas(tituloLista);
                                            _listaPrincipal.Add(nuevaListaNotas);
                                            ColorMensaje(1, "Lista creada");
                                            continue;
                                        case "2":
                                            if (listasNotas.Count <= 0)
                                                {
                                                ColorMensaje(3, "No hay listas: primero debe crear una lista");
                                                continue;
                                                }
                                            else
                                                {
                                                EjecutarActionEnListasNotas(actionCrearNotaListaNotas, listasNotas);
                                                }
                                            break;
                                        case "3":
                                            if (listasNotas.Count <= 0)
                                                {
                                                ColorMensaje(3, "No hay listas: primero debe crear una lista");
                                                continue;
                                                }
                                            else
                                                {
                                                EjecutarActionEnListasNotas(actionVerElementosLista, listasNotas);
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
                        Console.Write($"{txtTituloTarea}\n1. Crear tarea\n2. Ver tareas\n3. Volver\n");
                        ColorMensaje(0, txtSeleccioneUnaOpcion);
                        string opcionCrearTarea = Console.ReadLine();
                        switch (opcionCrearTarea)
                            {
                            case "1":
                                Console.WriteLine($"{txtTituloTarea}");
                                string nombre = ValidarValorIngresado("Nombre");
                                string descripcion = ValidarValorIngresado("Descripción");
                                Console.WriteLine(Tarea.VerCategoriasTarea());
                                int categoria = ValidarEnumIngresado<Tarea.CategoriaTarea>("Categoría");
                                DateTime fechaHoraVencimiento = ValidarFechaIngresada("Fecha de vencimiento (día/mes/año hora:minutos)");
                                Tarea nuevaTarea = new Tarea(nombre, descripcion, (Tarea.CategoriaTarea)categoria, fechaHoraVencimiento);
                                _listaPrincipal.Add(nuevaTarea);
                                ColorMensaje(1, "Tarea creada");
                                break;
                            case "2":
                                Console.WriteLine($"{txtTituloTarea}");
                                if (ListaTareas.GetListaTareas().Count <= 0)
                                    {
                                    ColorMensaje(3, "No hay tareas");
                                    continue;
                                    }
                                else
                                    {
                                    Console.WriteLine(ListaTareas.VerTareas());
                                    }
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

        public static Action<List<ListaNotas>, int> actionVerElementosLista = (listaNotas, indiceLista) =>
        {
            if (listaNotas[indiceLista - 1].GetListaNotas().Count > 0) Console.WriteLine(listaNotas[indiceLista - 1].VerNotas());
            else Console.WriteLine($"{listaNotas[indiceLista - 1].TituloListaNotas.ToUpper()}\n"); ColorMensaje(3, "No hay notas");
        };

        public static Action<List<ListaNotas>, int> actionCrearNotaListaNotas = (listaNotas, indiceLista) =>
        {
            string campoIngresado = ValidarValorIngresado("Título nota");
            Console.WriteLine(listaNotas[indiceLista - 1].CrearNota(campoIngresado));
            Console.ResetColor();
        };

        public static void EjecutarActionEnListasNotas(Action<List<ListaNotas>, int> action, List<ListaNotas> listaNotas)
            {
            do
                {
                Console.WriteLine($"{txtTituloListaNotas}");
                for (int i = 0; i < listaNotas.Count; i++) Console.WriteLine($"{i + 1}. {listaNotas[i].TituloListaNotas.ToUpper()} / {listaNotas[i].FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy h:mm:ss tt")}\n - Notas: {listaNotas[i].GetListaNotas().Count}");
                ColorMensaje(0, "Seleccione una lista: ");
                // Validar que el valor ingresado corresponda a un elemento de la List<ListNotas>
                if (!int.TryParse(Console.ReadLine(), out int indiceLista) || indiceLista > listaNotas.Count || indiceLista <= 0)
                    {
                    ColorMensaje(2, "Seleccione una lista válida");
                    continue;
                    }
                else
                    {
                    action(listaNotas, indiceLista);
                    break;
                    }
                } while (true);
            }

        // Validar que el valor retornado por el método ValidarValorIngresado() cumpla con el formato especificado por el patrón(patronFecha)
        public static DateTime ValidarFechaIngresada(string nombreCampo)
            {
            string fechaIngresada;
            DateTime fechaVencimiento;
            // Expresión regular para validar formato dd/MM/yyyy HH:mm
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
                if (string.IsNullOrEmpty(valor)) ColorMensaje(3, $"Ingrese un valor para {nombreCampo}");
                } while (string.IsNullOrEmpty(valor));
            return valor;
            }
        }
    }