using System;
using System.Collections.Generic;

namespace LinkedList
    {

    class Program
        {

        public static void Main(string[] args)
            {


            string[] paises = { "Colombia", "España", "Finlandia", "Australia", "España", "Bélgica" };
            LinkedList<string> listaPaises = new LinkedList<string>(paises);

            // Agregar un nuevo pais al inicio de la lista
            listaPaises.AddFirst("Rumania");
            //listaPaises.AddFirst(new LinkedListNode<string>("Rumania")); ASI TAMBIEN SE PUEDE

            // Mover el primer nodo para que sea el último
            LinkedListNode<string> primerNodo = listaPaises.First;
            listaPaises.RemoveFirst();
            listaPaises.AddLast(primerNodo);

            // Cambiar el último nodo a Alemania
            listaPaises.RemoveLast();
            listaPaises.AddLast("Alemania");

            // Mover el último no al primer nodo
            LinkedListNode<string> ultimoNodo = listaPaises.Last;
            listaPaises.RemoveLast();
            listaPaises.AddFirst(ultimoNodo);

            // Indicar la última ocurrencia de España encontrada en la lista
            LinkedListNode<string> ultimoNodoEncontrado = listaPaises.FindLast("España");

            // Agregar "Italia" y "Francia" despues de la última ocurrencia de España
            listaPaises.AddAfter(ultimoNodoEncontrado, "Italia");
            listaPaises.AddAfter(ultimoNodoEncontrado, "Francia");

            // Indicar el nodo que contenga "Colombia"
            LinkedListNode<string> nodoEncontado = listaPaises.Find("Colombia");

            //foreach(string pais in listaPaises)
            //    {
            //    Console.WriteLine(pais);
            //    }

            
            for(LinkedListNode<string> nodo = listaPaises.First; nodo !=null; nodo = nodo.Next)
                {
                Console.WriteLine(nodo.Value);
                }

            }
        }
    }