using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While
    {
    internal class Program
        {
        static void Main(string[] args)
            {

            Random rnd = new Random();
            int numRandom = rnd.Next(0, 101);
            int numIngresado = 0, contador = 0;

            while (numIngresado != numRandom)
                {

                Console.WriteLine("¡Se ha generado un número aleatorio entre 1 y 100! Intenta adivinarlo.");

                string entrada = Console.ReadLine();
                if (!Int32.TryParse(entrada, out numIngresado))
                    {
                    Console.WriteLine("Ingrese un número válido");
                    continue;
                    }

                contador++;
                if (numIngresado < numRandom) Console.WriteLine("El número aleatorio es MAYOR.");
                else if (numIngresado > numRandom) Console.WriteLine("El número aleatorio es MENOR.");

                }

            Console.WriteLine($"Felicitaciones! {numIngresado} es igual al aleatorio. Lo logró en {contador} intentos.");

            }
        }
    }