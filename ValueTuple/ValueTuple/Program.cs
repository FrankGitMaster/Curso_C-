using System.Globalization;

namespace ValueTuple
    {

    public class Program
        {

        public static void Main(string[] args)
            {
            Tuple<string, int> persona = new("frank", 26);
            Console.WriteLine(persona.Item1);

            Console.WriteLine("\n");

            ValueTuple<string, int> carro = new ValueTuple<string, int>("Ferrari", 350);
            carro.Item1 = "Lamborghini";
            var carro2 = (Marca: "Supra", Velocidad: 310);//Creación con nombres personalizados
            var carro3 = ("Mazda", 250);
            (string marca, int velocidad) carro4 = ("Porshe", 300);//Creación e instanciación
            (string marca, int velocidad) = ("Susuki", 220); //Desestructuracipon
            Console.WriteLine(carro.Item1);
            Console.WriteLine(carro2.Marca);
            Console.WriteLine(carro3.Item1);
            Console.WriteLine(carro4.marca);
            Console.WriteLine(marca);

            Console.WriteLine("\n");

            Console.WriteLine(ObtenerDatos(carro4));
            Console.WriteLine(ObtenerDatos2("Todo good!", 100));
            }

        //Un método puede recibir una ValueTuple<T> como parametro
        public static string ObtenerDatos((string dato1, int dato2) valueTuple)
            {
            return $"{valueTuple.dato1} {valueTuple.dato2}";
            }

        //También puede un metodo retornar un ValueType<T>
        public static (string d1, int d2) ObtenerDatos2(string dato1, int dato2)
            {
            return (dato1, dato2);
            }
        }
    }