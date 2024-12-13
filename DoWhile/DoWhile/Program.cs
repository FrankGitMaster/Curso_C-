using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_C_
    {
    internal class Program
        {
        static void Main(string[] args)
            {

            Random rnd = new Random();
            int numRandom = rnd.Next(1, 101);
            int numIngresado = 0, contador = 0;

            do
                {

                Console.WriteLine("Ingrese un valor entre 1 y 100.");
                string entrada = Console.ReadLine();
                if (Int32.TryParse(entrada, out numIngresado))
                    {
                    contador++;
                    if (numIngresado < numRandom)
                        {
                        Console.WriteLine($"El número random es mayor que {numIngresado}");
                        }
                    else if (numIngresado > numRandom)
                        {
                        Console.WriteLine($"El número random es menor que {numIngresado}");
                        }
                    }
                else
                    {
                    Console.WriteLine("Ingrese un número valido");
                    continue;
                    }

                } while (numIngresado != numRandom);

            Console.WriteLine($"Los números son iguales, lo logró en {contador} intentos");


            }
        }
    }