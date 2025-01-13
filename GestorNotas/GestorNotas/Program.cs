using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
    {

    class Program
        {

        private static List<Base> listaPrincipal = new List<Base>();

        public static void Main(string[] args)
            {

            do
                {
                Console.WriteLine("GESTOR DE NOTAS Y TAREAS\n");

                List<Base> ordenada = listaPrincipal.OrderByDescending(e => e.FechaHoraCreacion).ToList();
                foreach (var obj in ordenada)
                    {
                    Console.WriteLine(obj.ToString());
                    }

                Console.Write("1. Crear nota\n2. Crear Tarea\n - Seleccione una opción: ");
                string opcionMenuPrincipal = Console.ReadLine();
                switch (opcionMenuPrincipal)
                    {
                    case "1":
                        Console.Write("CREAR NOTA\n1. Nota rápida\n2. Lista de notas\n - Seleccione una opción: ");
                        string opcionMenuNotas = Console.ReadLine();
                        switch (opcionMenuNotas)
                            {
                            case "1":
                                Console.Write("NOTA RAPIDA\n - Ingrese el título: ");
                                string titulo = Console.ReadLine();
                                Console.Write(" - Ingrese la descripción: ");
                                string descripcion = Console.ReadLine();
                                NotaRapida nuevaNotaRapida = new NotaRapida(titulo, descripcion);
                                listaPrincipal.Add(nuevaNotaRapida);
                                break;
                            case "2":
                                Console.Write("LISTA DE NOTAS\n - Ingrese el título de la lista: ");
                                string tituloListaNotas = Console.ReadLine();
                                ListaNotas nuevaListaNotas = new ListaNotas(tituloListaNotas);
                                listaPrincipal.Add(nuevaListaNotas);
                                break;
                            }
                        break;
                    }
                continue;
                break;
                } while (true);

            // Nota rapida
            /*            NotaRapida notaRapida_1 = new NotaRapida("Título nota rápida", "Descripción de la nota rápida");
                        NotaRapida notaRapida_2 = new NotaRapida("Hacer la cena", "Descripción sobre hacer la cena");
                        Console.WriteLine(notaRapida_1.VerDetalles());
                        Console.WriteLine(notaRapida_2.VerDetalles());*/

            // Lista de notas
            /*
                        Console.WriteLine(listaNotas_1.CrearNota("Actualizar debts"));
                        Console.WriteLine(listaNotas_1.CrearNota("Comprar zapatillas"));
                        Console.WriteLine(listaNotas_1.CrearNota("Comprar camiseta"));
                        Console.WriteLine(listaNotas_1.VerLista());*/

            // Lista de tareas
            /*            ListaTareas listaTareas = new ListaTareas();
                        Console.WriteLine(listaTareas.CrearTarea("Llamar a mi bro", "Llamar a mi hermano", 4, "2025/01/15 06:00"));
                        Console.WriteLine(listaTareas.CrearTarea("Contactar mentora", "Escribirle a la mentora para info sobre homologación", 1, "13/01/2025 17:00"));
                        Console.WriteLine(listaTareas.VerLista());*/
            }
        }
    }