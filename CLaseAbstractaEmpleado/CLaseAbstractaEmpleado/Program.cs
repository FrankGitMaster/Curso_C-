using CLaseAbstractaEmpleado;
using System.Collections;

namespace ClaseAbstractaEmpleado
    {

    class Program
        {

        public static void Main(string[] args)
            {

            EmpleadoTiempoCompleto etc1 = new EmpleadoTiempoCompleto("Frank", 1300);
            Contratista c1 = new Contratista("German", 200, 8);

            List<Empleado> listaEmpleados = new List<Empleado>();
            listaEmpleados.Add(etc1);
            listaEmpleados.Add(c1);


            foreach (Empleado e in listaEmpleados)
                {
                e.MostrarInformacion();
                }

            Console.WriteLine(etc1.SalarioMensual);

            }
        }
    }