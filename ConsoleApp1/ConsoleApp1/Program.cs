namespace Delegados
    {

    class Program
        {

        public static void Main(string[] args)
            {

            OperacionMatematica delegadoSuma = Suma;
            OperacionMatematica delegadoResta = Resta;
            OperacionMatematica delegadoMultiplicacion = Multiplicacion;
            OperacionMatematica delegadoDivision = Division;

            do
                {
                Console.Write("Ingrese una opción del menú\n1. Suma\n2. Resta\n3. Multiplicación\n4. División\n5. Salir del programa\n - Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                    {
                    case "1":
                        MostrarResultado(delegadoSuma);
                        break;
                    case "2":
                        MostrarResultado(delegadoResta);
                        break;
                    case "3":
                        MostrarResultado(delegadoMultiplicacion);
                        break;
                    case "4":
                        MostrarResultado(delegadoDivision);
                        break;
                    case "5":
                        Console.WriteLine("Programa finalizado");
                        return;
                    default:
                        Console.WriteLine(" ! Seleccione una opción válida");
                        continue;
                    }
                } while (true);
            }

        // El delegado debe tener la misma firma que los metodos que delegados
        public delegate int OperacionMatematica(int n1, int n2);

        public static int Suma(int num1, int num2)
            {
            return num1 + num2;
            }

        public static int Resta(int num1, int num2)
            {
            return num1 - num2;
            }

        public static int Multiplicacion(int num1, int num2)
            {
            return num1 * num2;
            }

        public static int Division(int num1, int num2)
            {
            if(num1 == 0 || num2 == 0)
                {
                Console.WriteLine(" ! No es posible dividir por 0");
                return 0;
                }
            else
                {
                return num1 / num2;
                }
            }

        // Se pasa el deligado delegadoOperacion como parametro en otra función
        public static void MostrarResultado(OperacionMatematica delegadoOperacion)
            {

            Console.Write(" - Ingrese el primer número: ");
            int valor1 = Int32.Parse(Console.ReadLine());
            Console.Write(" - Ingrese el segundo número: ");
            int valor2 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("El resultado es: " + delegadoOperacion(valor1, valor2));
            }
        }
    }