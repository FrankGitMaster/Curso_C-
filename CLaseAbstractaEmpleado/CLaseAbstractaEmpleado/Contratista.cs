namespace CLaseAbstractaEmpleado
    {
    class Contratista : Empleado
        {

        private double _tarifaPorHora;
        private int _horasTrabajadas;

        public Contratista(string nombre, double tarifaPorHora, int horasTrabajadas) : base(nombre)
            {
            _tarifaPorHora = tarifaPorHora;
            _horasTrabajadas = horasTrabajadas;
            }

        public override double CalcularSalario()
            {
            return _tarifaPorHora * _horasTrabajadas;
            }

        }
    }
