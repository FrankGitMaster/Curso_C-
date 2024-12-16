using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
    {
    internal class MainProgram
        {
        static void Main(string[] args)
            {

            List<IVehiculo> listaVehiculos = new List<IVehiculo>
        {
            new Auto ("Toyota", "Corolla", 2020),
            new Bicicleta ("Montaña", 26)
        };

            void RecorrerLista(List<IVehiculo> vehiculos)
                {
                foreach (IVehiculo vehiculo in vehiculos)
                    {
                    vehiculo.MostrarDetalles();
                    }
                }

            RecorrerLista(listaVehiculos);

            }
        }
    }
