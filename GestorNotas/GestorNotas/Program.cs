using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
    {

    class Program
        {
        private static List<Base> _listaPrincipal = new List<Base>();
        // Mensaje de entrada 
        private const string txtSeleccioneUnaOpcion = "Seleccione una opción: ";
        // Títulos módulos
        private const string txtTituloGestor = "GESTOR DE NOTAS Y TAREAS:";
        private const string txtTituloCrearNota = "NOTAS:";
        private const string txtTituloNotaRapida = "NOTA RAPIDA:";
        private const string txtTituloListaNotas = "LISTA DE NOTAS:";

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
                        // Seleccionar opción del menú de creación de notas
                        Console.Write($"{txtTituloCrearNota}\n1. Crear nota rápida\n2. Lista de notas\n3. Volver\n");
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
                                            List<ListaNotas> listasNotas = _listaPrincipal.OfType<ListaNotas>().ToList();
                                            if (listasNotas.Count <= 0)
                                                {
                                                ColorMensaje(2, "No hay listas: primero debe crear una lista");
                                                continue;
                                                }
                                            else
                                                {

                                                }
                                            break;
                                        case "3":

                                            break;
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
                        // Seleccionar opción del menú de creación de tareas
                        break;
                    default:
                        ColorMensaje(2, "Seleccione una opción válida");
                        continue;
                    }
                continue;
                } while (true);
            }

        public static void RecorrerListasNota<T>(List<T> lista)
            {
            do
                {
                Console.WriteLine($"{txtTituloListaNotas}");
                for (int i = 0; i < listasNotas.Count; i++) Console.WriteLine($"{i + 1}. {listasNotas[i].TituloListaNotas.ToUpper()} / Notas: {listasNotas[i].GetListaNotas().Count}");
                Console.Write("Seleccione una lista: ");
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