//Ejercicio: Gestión de Turnos en una Cola (Queue)
//Enunciado:
//Crea un programa en C# que simule un sistema de gestión de turnos en una clínica. 
//El programa debe usar una Queue<string> para almacenar los nombres de los pacientes.
//El usuario podrá realizar las siguientes acciones:

//Agregar un paciente a la cola.
//Llamar al siguiente paciente (eliminarlo de la cola y mostrar su nombre).
//Ver todos los pacientes en la cola.
//Salir del programa.

public enum Paises
    {
    ESPANA, BRASIL
    }

public class Program
    {
    public static void Main(string[] args)
        {

        Dictionary<Paises, string> dictionaryPaises = new Dictionary<Paises, string>()
        {
            { Paises.BRASIL, "Brasil"},
            { Paises.ESPANA, "España"}
        };

        foreach (KeyValuePair<Paises, string> pais in dictionaryPaises)
            {
            Console.WriteLine(pais.Value);
            }
        }
    }