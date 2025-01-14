using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
{

    class Program
    {

        private static List<Base> _listaPrincipal = new List<Base>();

        public static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("GESTOR DE NOTAS Y TAREAS\n");

                List<Base> listaPrincipalOrdenada = _listaPrincipal.OrderByDescending(e => e.FechaHoraCreacion).ToList();
                foreach (var elemento in listaPrincipalOrdenada)
                {
                    Console.WriteLine(elemento.ToString());
                }
                if (listaPrincipalOrdenada.Count == 0) Console.WriteLine("No hay notas ni tareas\n");

                Console.Write("1. Crear nota\n2. Crear Tarea\n - Seleccione una opción: ");
                string opcionMenuPrincipal = Console.ReadLine();
                switch (opcionMenuPrincipal)
                {
                    case "1":
                        Console.Write("CREAR NOTA\n1. Nota rápida\n2. Lista de notas\n - Seleccione una opción: ");
                        string opcionCrearNota = Console.ReadLine();
                        switch (opcionCrearNota)
                        {
                            case "1":
                                Console.Write("NOTA RAPIDA\n - Ingrese el título: ");
                                string titulo = Console.ReadLine();
                                Console.Write(" - Ingrese la descripción: ");
                                string descripcion = Console.ReadLine();
                                NotaRapida nuevaNotaRapida = new NotaRapida(titulo, descripcion);
                                _listaPrincipal.Add(nuevaNotaRapida);
                                break;
                            case "2":
                                Console.Write("LISTA DE NOTAS\n1. Crear Lista\n2. Crear nota en lista\nSeleccione una opción: ");
                                string opcionListaNotas = Console.ReadLine();
                                switch (opcionListaNotas)
                                {
                                    case "1":
                                        Console.Write("LISTA DE NOTAS\n - Ingrese el título de la lista: ");
                                        string tituloListaNotas = Console.ReadLine();
                                        ListaNotas nuevaListaNotas = new ListaNotas(tituloListaNotas);
                                        _listaPrincipal.Add(nuevaListaNotas);
                                        break;
                                    case "2":
                                        List<Base> listasNotasSeleccionada = _listaPrincipal.Where(lista => lista is ListaNotas).ToList();
                                        if (listasNotasSeleccionada.ToList().Count <= 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("(x) No hay lista creadas");
                                            Console.ResetColor();
                                            break;
                                        }
                                        else
                                        {
                                            List<ListaNotas> listaN = listasNotasSeleccionada.OfType<ListaNotas>().ToList();
                                            for (int i = 0; i < listaN.Count; i++) Console.WriteLine($"{i + 1}. {listaN[i]}");
                                            do
                                            {
                                                Console.Write("LISTA DE NOTAS\n - Seleccione una lista: ");
                                                if (!int.TryParse(Console.ReadLine(), out int opcionListaNotasSeleccionada) || opcionListaNotasSeleccionada > listaN.Count || opcionListaNotasSeleccionada <= 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("(x) Error: Seleccione una lista válida");
                                                    Console.ResetColor();
                                                    continue;
                                                }
                                                else
                                                {
                                                    Console.Write(" - Ingrese el título de la nota: ");
                                                    string tituloNota = Console.ReadLine();
                                                    listaN[opcionListaNotasSeleccionada - 1].CrearNota(tituloNota);
                                                    break;
                                                }
                                            } while (true);
                                        }
                                        break;
                                }
                                break;
                        }
                        break;
                }
                continue;
                break;
            } while (true);
        }
    }
}