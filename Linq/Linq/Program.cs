using System.Linq;
using System.Security.Cryptography;

class Program
    {

    public static void Main(String[] args)
        {

        var secuencia = Enumerable.Range(1, 10);

        // Linq con expresiones convencionales. Usando select y where
        var secuenciaSelectConvencional = from i in secuencia where i % 2 == 0 select i * 3;

        // Linq con expresiones lambda
        var secuenciaSelect = secuencia.Select(i => i * 3); // Select, Where y OrderBy retornan un IEumerable<T>
        Console.WriteLine("secuenciaSelect: " + string.Join(", ", secuenciaSelect));

        var secuenciaWhere = secuencia.Where(i => i % 2 == 0);
        Console.WriteLine("secuenciaWhere: " + string.Join(", ", secuenciaWhere));

        var secuenciaOrderBy = secuencia.OrderBy(i => -i);
        Console.WriteLine("secuenciaOrderBy: " + string.Join(", ", secuenciaOrderBy));

        }
    }