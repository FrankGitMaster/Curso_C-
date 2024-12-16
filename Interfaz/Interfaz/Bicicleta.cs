using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
    {
    internal class Bicicleta : IVehiculo
        {

        public string Tipo { get; }
        public int TamanoRuedas { get; }

        public Bicicleta(string tipo, int tamanoRuedas)
            {
            Tipo = tipo;
            TamanoRuedas = tamanoRuedas;
            }

        public void Arrancar()
            {
            Console.WriteLine("La bicicleta arrancó; tiene pedales en acero");
            }

        public void Frenar()
            {
            Console.WriteLine("La bicileta frenó; tiene freno de disco");
            }

        public void MostrarDetalles()
            {
            Console.WriteLine(ToString());
            }

        public override string ToString()
            {
            return $"{this.GetType().Name}\nTipo={this.Tipo}\nTamaño Ruedas={this.TamanoRuedas}\n";
            }
        }
    }
