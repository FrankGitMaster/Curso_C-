using System;

namespace Program
    {
    class Program
        {
        static void Main(string[] args)
            {

            int[] miArray = LeerDatos();
            LlenarArray(miArray);

            }

        static int[] LlenarArray(int[] array)
            {

            try
                {
                for (int i = 0; i < array.Length; i++)
                    {
                    do
                        {
                        Console.WriteLine($"Ingrese el valor {i + 1} del array");
                        int ValorElemento = 0;
                        if (!Int32.TryParse(Console.ReadLine(), out ValorElemento))
                            {
                            Console.WriteLine("ERROR: valor incorrecto!");
                            continue;
                            }
                        array[i] = ValorElemento;
                        break;
                        } while (true);
                    }
                Console.WriteLine("Array LLenado con exito!");
                RecorrerArray(array);
                }
            catch (Exception ex)
                {
                Console.WriteLine($"ERROR: {ex.Message}");
                }

            return array;
            }

        static int[] LeerDatos()
            {

            int NumElementos = 0;
            int[] array;

            do
                {
                Console.WriteLine("Cuántos elementos tendrá el array?");
                if (!Int32.TryParse(Console.ReadLine(), out NumElementos))
                    {
                    Console.WriteLine("Error: valor incorrecto");
                    continue;
                    }
                array = new int[NumElementos];
                break;
                } while (true);

            return array;
            }

        static void RecorrerArray(int[] array)
            {

            foreach (int e in array)
                {
                Console.WriteLine(e);
                }
            }
        }
    }
