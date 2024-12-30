//Ejercicio: Gestión de Turnos en una Cola (Queue)
//Enunciado:
//Crea un programa en C# que simule un sistema de gestión de turnos en una clínica. 
//El programa debe usar una Queue<Paciente> para almacenar los pacientes.
//El usuario podrá realizar las siguientes acciones:

//Agregar un paciente a la cola.
//Llamar al siguiente paciente (eliminarlo de la cola y mostrar su nombre).
//Ver todos los pacientes en la cola.
//Salir del programa.

using System;
using System.Linq;

namespace GestorTurnos
{
    public class Program
    {

        public static void Main(string[] args)
        {

            // SIMULACION DE BASE DE DATOS DE LOS PACIENTES EN EL SISTEMA
            Paciente p1 = new Paciente("Randy", 45, EEps.SURA);
            Paciente p2 = new Paciente("Marc", 60, EEps.COMPENSAR);
            Paciente p3 = new Paciente("Loui", 12, EEps.SALUDCOOP);
            Paciente p4 = new Paciente("Borges", 72, EEps.SANITAS);

            Cola cola = new Cola(Paciente.GetListaPacientes());

            do
            {
                Console.WriteLine("=== MENÚ COLA PACIENTES\n1. Agregar paciente\n2. Llamar paciente\n3. Ver pacientes en cola\n4. Salir");
                Console.Write(" - Seleccione una opción del menú: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        cola.AgregarPacienteACola();
                        break;
                    case "2":
                        cola.LlamarPaciente();
                        break;
                    case "3":
                        cola.VerPacientesEnCola();
                        break;
                    case "4":
                        Console.WriteLine("Programa finalizado");
                        return;
                    default:
                        Console.WriteLine("! Ingrese una opción valida");
                        continue;
                }
            } while (true);

        }
    }
}