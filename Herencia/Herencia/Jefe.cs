using Herencia;

class Jefe : Empleado
    {

    public double Comision { get; }

    public Jefe(string nombre, double sueldo, string area, double comision) : base(nombre, sueldo, area)
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