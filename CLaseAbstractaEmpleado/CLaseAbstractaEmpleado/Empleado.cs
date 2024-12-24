namespace CLaseAbstractaEmpleado
    {
    abstract class Empleado
        {

        public string Nombre { get; private set; }

        public Empleado(string nombre)
            {
            Nombre = nombre;
            }

        public abstract double CalcularSalario();

        public void MostrarInformacion()
            {
            Console.WriteLine($"Empleado\n- {Nombre}\n- {CalcularSalario():C}");
            }
        }
    }
