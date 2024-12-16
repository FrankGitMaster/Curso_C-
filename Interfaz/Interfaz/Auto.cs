using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
    {
    public class Auto : IVehiculo
        {

        public string Marca { get; }
        public string Modelo { get; }
        public int Ano { get; }

        public Auto(string marca, string modelo, int ano)
            {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            }

        public void Arrancar()
            {
            Console.WriteLine("El auto arrancó; encendio su motor V8");
            }

        public void Frenar()
            {
            Console.WriteLine("El auto frenó; usa sistema ABS");
            }

        public void MostrarDetalles()
            {
            Console.WriteLine(ToString());
            }

        public override string ToString()
            {
            return $"{this.GetType().Name}\nMarca={this.Marca}\nModelo={this.Modelo}\nAño={this.Ano}\n";
            }
        }
    }
