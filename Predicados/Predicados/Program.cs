namespace Predicados
    {

    class program
        {

        static void Main(string[] args)
            {

            List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Predicate<int> esPar = num => num % 2 == 0;
            Predicate<int> esPar = Matematicas.Pares;

            List<int> listaPares = numeros.FindAll(esPar);

            foreach (int par in listaPares)
                {
                Console.WriteLine(par);
                }

            Console.WriteLine(esPar(101));
            }
        }

    class Matematicas
        {

        public static bool Pares(int num)
            {
            return num % 2 == 0;
            }
        }
    }