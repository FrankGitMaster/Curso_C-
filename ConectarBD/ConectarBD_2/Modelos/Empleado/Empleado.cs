namespace ConectarBD_2.Modelos.Empleado
    {
    public class Empleado
        {

        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public long Sueldo { get; set; }
        public bool Bonificacion {  get; set; }
        public DateTime FechaContrato { get; set; }

        }
    }
