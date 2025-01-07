class Program
{

    public static void Main(string[] args)
    {

        var listaNumeros = new List<int>()
        {
            2,5,9,10
        };

        //Action<int> actionImprimirCadaNumero = ImprimirCadaNumero;
        //Action<int> actionDobleDeCadaNumero = DobleDeCadaNumero;
        //Action<int> actionNumeroParImpar = NumeroParImpar;

        Console.WriteLine("ImprimirCadaNumero");
        //ProcesarNumeros(listaNumeros, actionImprimirCadaNumero);
        // Utilizando expresión lambda en lugar de Action
        ProcesarNumeros(listaNumeros, x => Console.WriteLine(x));

        Console.WriteLine("DobleDeCadaNumero");
        //ProcesarNumeros(listaNumeros, actionDobleDeCadaNumero);
        // Utilizando expresión lambda en lugar de Action
        ProcesarNumeros(listaNumeros, x => Console.WriteLine(x + x));

        Console.WriteLine("NumeroParImpar");
        //ProcesarNumeros(listaNumeros, actionNumeroParImpar);
        // Utilizando expresión lambda en lugar de Action
        ProcesarNumeros(listaNumeros, x =>
        {
            Console.WriteLine(x % 2 == 0 ? x + " es par" : x + " es impar");
        }
        );

    }

    public static void ProcesarNumeros(List<int> lista, Action<int> accion)
    {
        lista.ForEach(x => accion(x));
    }

   /* public static void ImprimirCadaNumero(int x)
    {
        Console.WriteLine(x);
    }

    public static void DobleDeCadaNumero(int x)
    {
        Console.WriteLine(x + x);
    }

    public static void NumeroParImpar(int x)
    {
        if (x % 2 == 0) Console.WriteLine(x + " es par");
        else Console.WriteLine(x + " es impar");
    }*/
}