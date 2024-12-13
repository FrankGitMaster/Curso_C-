using System;

namespace Excepciones
    {
    internal class Program
        {
        static void Main(string[] args)
            {

            string entrada;
            int numeroIngresado = 0;

            do
                {
                Console.WriteLine("Ingrese un número");
                entrada = Console.ReadLine();
                try
                    {
                    numeroIngresado = Int32.Parse(entrada);
                    break;
                    }
                catch (Exception ex) when (ex.GetType() != typeof(FormatException))
                    {
                    Console.WriteLine($"Error: {ex.Message}");
                    continue;
                    }
                catch (FormatException ex)
                    {
                    Console.WriteLine($"Error, has introducido texto: {ex.Message}");
                    continue;
                    }

                } while (true);

            Console.WriteLine($"Mi número es: {numeroIngresado}");
            Console.WriteLine("Resto del programa...");



            }
        }
    }
