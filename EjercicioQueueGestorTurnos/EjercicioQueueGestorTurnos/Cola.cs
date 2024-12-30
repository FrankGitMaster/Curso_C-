namespace GestorTurnos
{
    class Cola
    {

        public Queue<Paciente> colaPacientes { get; }
        private List<Paciente> listaPacientes { get; }
        public Cola(List<Paciente> lista)
        {
            colaPacientes = new Queue<Paciente>();
            listaPacientes = lista;
        }

        public void AgregarPacienteACola()
        {
            Console.WriteLine("AGREGAR PACIENTE");
            do
            {
                Console.Write("- Ingrese el Id del paciente: ");
                int idIngresado;
                // Verificar que el valor ingresado como Id no sea alfabetico
                if (!Int32.TryParse(Console.ReadLine(), out idIngresado))
                {
                    Console.WriteLine("! El Id debe ser númerico");
                    continue;
                }
                else
                {
                    // Recorrer la lista de pacientes y verificar si el Id ingresado existe en esta lista 
                    foreach (Paciente paciente in listaPacientes)
                    {
                        if (idIngresado == paciente.Id)
                        {
                            if (colaPacientes.Contains(paciente))
                            {
                                Console.WriteLine("! Este paciente ya esta en la cola");
                                break;
                            }
                            else
                            {
                                colaPacientes.Enqueue(paciente);
                                Console.WriteLine("! Paciente agregado a la cola");
                                break;
                            }
                        }
                        if (listaPacientes.IndexOf(paciente) == (listaPacientes.Count - 1))
                        {
                            Console.WriteLine("! No existe un paciente con el Id ingresado");
                        }
                    }
                    break;
                }
            } while (true);
            Console.WriteLine();
        }

        public void LlamarPaciente()
        {
            if (!ColaVacia())
            {
                Console.WriteLine("LLAMAR PACIENTE");
                Console.WriteLine($"! Llamando al paciente {colaPacientes.Peek().Nombre}");
                colaPacientes.Dequeue();
            }
            else
            {
                Console.WriteLine("! No hay pacientes en cola");
            }
            Console.WriteLine();
        }

        public void VerPacientesEnCola()
        {
            if (!ColaVacia())
            {
                Console.WriteLine("PACIENTES EN COLA");
                foreach (Paciente p in colaPacientes)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
            {
                Console.WriteLine("! No hay pacientes en cola");
            }
            Console.WriteLine();
        }

        public bool ColaVacia() => colaPacientes.Count == 0 ? true : false; // Puede simplificarse asi:
        // public bool ColaVacia() => colaPacientes.Count == 0; La comparación devuelve un booleano

    }
}