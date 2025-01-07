using System;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{

    static void Main(string[] args)
    {
        string frase = "Mi nomvre es Frank, telefono (+57) 320 213 3170 y correo es frank_psn@outlook.com";

        string patron = @"\@";

        Regex RegularExpresion = new Regex(patron);

        MatchCollection myMatch = RegularExpresion.Matches(frase);

        if (myMatch.Count > 0) Console.WriteLine("Todo good");
        else Console.WriteLine("Nada");

        myMatch.ToList().ForEach(e => Console.WriteLine(e));
    }
}