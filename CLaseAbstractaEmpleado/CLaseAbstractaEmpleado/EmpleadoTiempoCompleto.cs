namespace CLaseAbstractaEmpleado
    {
    internal class EmpleadoTiempoCompleto : Empleado
        {

        private double _salarioMensual;
        public double SalarioMensual {
            get
                {
                return _salarioMensual;
                }
            private set
                {
                if(value <= 0)
                    {
                    throw new ArgumentException("El salario mensual debe ser mayor a 0");
                    }
                _salarioMensual = value;
                }
            }

        private double salarioMensual;
        public EmpleadoTiempoCompleto(string nombre, double salarioMensual) : base(nombre)
            {
            this.salarioMensual = salarioMensual;
            }

        public double GetSalarioMensual()
            {
            return this.salarioMensual;
            }

        public override double CalcularSalario()
            {
            return _salarioMensual;
            }
        }
    }
