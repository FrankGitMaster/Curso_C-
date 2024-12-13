using System.Collections.Generic;
using System;

class Empleado
    {

    public int Id { get; }
    static int incrmentarId = 1;
    public string Nombre { get; }
    public virtual double Sueldo { get; }
    private string _area;
    private static List<Empleado> _listaEmpleados = new List<Empleado>();
    public string Area { get { return _area; } }

    public Empleado(string nombre, double sueldo, string area)
        {
        Id = incrmentarId;
        Nombre = nombre;
        Sueldo = sueldo;
        _area = area.ToUpper();
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
        return $"{this.Id} {this.Nombre}: S={this.Sueldo} A={this.Area} P={this.GetType().Name}";
        }
    }