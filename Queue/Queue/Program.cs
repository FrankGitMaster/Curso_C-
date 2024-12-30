public class Program
{
    public static void Main(string[] args)
    {

        Queue<string> paises = new Queue<string>();
        paises.Enqueue("Colombia");
        paises.Enqueue("Perú");
        paises.Enqueue("Brasil");

        MostrarElementosCola<string>(paises);
        Console.WriteLine("Usando Peek para traer el primer elemento de la cola: " + paises.Peek());
        Console.WriteLine("Usando Dequeue para eliminar el primer elemento de la cola: " + paises.Dequeue());
        paises.Enqueue("Alemania");
        Console.WriteLine("Se usó Enqueue para agregar un nuevo elemento a la cola");
        Console.WriteLine("Usando Last para traer el último elemento de la cola: " + paises.Last());
        MostrarElementosCola<string>(paises);

        string[] arrayPaises = paises.ToArray();
        Console.WriteLine("Se paso el Queue a un Array con ToArray() y se imprime el elemento en el index 0: " + arrayPaises[0]);

        List<string> listaPaises = paises.ToList();
        Console.WriteLine("Se paso el Queue a una List con ToList() y se imprime el primer elemento de la lista: " + listaPaises.First());
    }

    public static void MostrarElementosCola<T>(Queue<T> cola)
    {
        int contador = 1;
        Console.WriteLine("=== Paises en cola ===");
        foreach (T elemento in cola)
        {
            Console.WriteLine($"{contador}. {elemento}");
            contador++;
        }
        Console.WriteLine("======================");
    }
}