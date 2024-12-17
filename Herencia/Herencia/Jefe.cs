using Herencia;

namespace Herencia
    {
    class Jefe : Empleado
        {

        public double Comision { get; }

        public Jefe(string nombre, double sueldo, Area area, double comision) : base(nombre, sueldo, area)
            {
            Comision = comision;
            }

        public override double Sueldo
            {
            get
                {
                return base.Sueldo + Comision;
                }
            }

        }
    }