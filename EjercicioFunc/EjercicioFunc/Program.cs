class Program
{

    public static void Main(string[] args)
    {

        var listaNumeros = new List<int>()
        {
            2,6,9,4,1
        };

        // Utilizando expresiones lambda
        Func<int, int> funcionDobleNumero = numeroEntrada => numeroEntrada + numeroEntrada;
        Func<int, int> funcionElevaAlCuadrado = numeroEntrada => numeroEntrada * numeroEntrada;
        Func<int, int> funcionIncementadoEn5 = numeroEntrada => numeroEntrada + 5;

        Console.WriteLine("funcionDobleNumero");
        TransformarNumeros(listaNumeros, funcionDobleNumero);
        Console.WriteLine("funcionElevaAlCuadrado");
        TransformarNumeros(listaNumeros, funcionElevaAlCuadrado);
        Console.WriteLine("IncementadoEn5");
        TransformarNumeros(listaNumeros, funcionIncementadoEn5);
    }

    public static void TransformarNumeros(List<int> lista, Func<int, int> funcion)
    {
        lista.ForEach(e => Console.WriteLine(funcion(e)));
    }
}