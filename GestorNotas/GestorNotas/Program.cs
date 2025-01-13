using System;

namespace GestorNotas
{

    class Program
    {

        public static void Main(string[] args)
        {

            NotaRapida notaRapida_1 = new NotaRapida("Título nota rápida", "Descripción de la nota rápida");
            NotaRapida notaRapida_2 = new NotaRapida("Hacer la cena", "Descripción sobre hacer la cena");
            Console.WriteLine(notaRapida_1.VerDetallesNota());
            Console.WriteLine(notaRapida_2.VerDetallesNota());

            ListaNotas listaNotas_1 = new ListaNotas("Título de la lista de notas TO DOs");
            ListaNotas listaNotas_2 = new ListaNotas("Segunda lista de notas");
            Nota n1 = new Nota("nota prueba", "Completo");
            Nota n2 = new Nota("camiseta", "Incompleto");
            Nota n3 = new Nota("Comprar", "Incompleto");
            n1.FechaHoraCreacion = DateTime.Parse("01/01/2023");
            n2.FechaHoraCreacion = DateTime.Parse("01/01/2023");
            n3.FechaHoraCreacion = DateTime.Parse("01/01/2022");
            listaNotas_1.CrearNota(n1);
            listaNotas_1.CrearNota(n2);
            listaNotas_1.CrearNota(n3);
            Console.WriteLine(listaNotas_1.VerDetallesNota());
            
            Nota n4 = new Nota("llamar U", "Completo");
            Nota n5 = new Nota("Comprar ajedrez", "Incompleto");
            listaNotas_2.CrearNota(n4);
            listaNotas_2.CrearNota(n5);
            Console.WriteLine(listaNotas_2.VerDetallesNota());
        }
    }
}