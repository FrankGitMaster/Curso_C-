using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Herencia
    {
    internal class Program
        {

        static void Main(string[] args)
            {


            Jefe j1 = new Jefe("Ivan Gonzalez", 7000, "recursos humanos", 1000);
            Coordinador c1 = new Coordinador("Diego Medrano", 4500, "logistica", 500);
            Auxiliar a1 = new Auxiliar("Pablo Cardenas", 1500, "logistica");
            Auxiliar a2 = new Auxiliar("Ronald", 1500, "molinos");
            Auxiliar a3 = new Auxiliar("Jorge Borda", 1800, "logistica");

            Empleado.VerMiembrosLista(Empleado.ListarEmpleados());

            c1.AgregarAuxiliar();

            Console.WriteLine($"Empleados del area del coordinador {c1.Nombre}");
            Empleado.VerMiembrosLista(c1.ListarAuxiliaresCoordinador());


            }
        }
    }
