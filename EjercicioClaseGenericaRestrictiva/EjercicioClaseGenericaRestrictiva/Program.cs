using System.Diagnostics.Contracts;
using System.Collections.Generic;

namespace Ejercicio
    {

    class Program
        {

        public static void Main(string[] args)
            {

            Contenedor<int> paises = new Contenedor<int>();
            Pais holanda = new Pais("Holanda", 1500);
            Pais rusia = new Pais("Rusia", 8000);
            Pais francia = new Pais("Francia", 4500);
            Pais colombia = new Pais("Colombia", 10000);
            Pais suiza = new Pais("Suiza", 7000);

            paises.Agregar(34);
            paises.Agregar(55);
            paises.Agregar(22);
            paises.Agregar(85);
            paises.Agregar(234);

            Console.WriteLine(paises.ObtenerMaximo());
            }
        }

    class Contenedor<T> where T : IComparable<T>
        {

        private List<T> _elementos = new List<T>();
        public int Conteo => _elementos.Count;

        public void Agregar(T elemento)
            {
            _elementos.Add(elemento);
            }

        public T ObtenerMaximo()
            {
            if (_elementos.Count <= 0)
                {
                throw new Exception("Lista vacia");
                }
            else
                {
                T maximo = _elementos[0];
                foreach(T elemento in _elementos)
                    {
                    if(elemento.CompareTo(maximo) > 0)
                        {
                        maximo = elemento;
                        }
                    }
                return maximo;
                }
            }


        }

    class Pais : IComparable<Pais>
        {

        public Pais(string nombre, int poblacion)
            {
            Nombre = nombre;
            Poblacion = poblacion;
            }

        public string? Nombre { get; }
        public int Poblacion { get; }

        public int CompareTo(Pais? other)
            {

            return this.Poblacion.CompareTo(other?.Poblacion);
            }

        public override string ToString()
            {
            return $"Pais= {Nombre}\nPoblación= {Poblacion}";
            }
        }
    }