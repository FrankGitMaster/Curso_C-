using System.Collections.Generic;

namespace Ejercicio
    {

    class Program
        {

        public static void Main(string[] args)
            {

            Dictionary<int, string> personas = new Dictionary<int, string>();

            personas.Add(1, "Frank");
            personas.Add(2, "Paracleto");

            KeyValuePair<int, string> maria = new KeyValuePair<int, string>(3, "Maria");

            (int id, string nombre) = maria;

            Console.WriteLine(nombre);

            }
        }
    }