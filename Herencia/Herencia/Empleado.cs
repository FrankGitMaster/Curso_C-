using System.Collections.Generic;
using System;

namespace Herencia
    {

    class Empleado
        {

        public int Id { get; }
        static int incrmentarId = 1;
        public string Nombre { get; }
        public virtual double Sueldo { get; }
        private string _area;
        private static List<Empleado> _listaEmpleados = new List<Empleado>();
        public string AreaEmpleado { get { return _area; } }
        Dictionary<Area, string> nombresAreas = new Dictionary<Area, string> {
                { Area.recursos_humanos, "Recursos humanos"},
                { Area.logistica, "Logística"},
                { Area.molinos, "Molinos"}
            };

        public Empleado(string nombre, double sueldo, Area area)
            {
            Id = incrmentarId;
            Nombre = nombre;
            Sueldo = sueldo;
            _area = nombresAreas[area];
            _listaEmpleados.Add(this);
            incrmentarId++;
            }

        public static void VerMiembrosLista<T>(List<T> lista) where T : Empleado // Metodo genérico
            {
            if (lista.Count <= 0)
                {
                Console.WriteLine("No hay items.");
                }
            else
                {
                foreach (T item in lista)
                    {
                    Console.WriteLine($"- {item.ToString()}");
                    }
                }
            Console.WriteLine();
            }

        public static List<Empleado> ListarEmpleados()
            {
            return _listaEmpleados;
            }

        public override string ToString() // Sobreescritura del metodo
            {
            return $"{this.Id} {this.Nombre}: S={this.Sueldo} A={this.AreaEmpleado} P={this.GetType().Name}";
            }
        }

    enum Area { recursos_humanos, logistica, molinos }
    }