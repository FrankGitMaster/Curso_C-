using Herencia;
using System.Collections.Generic;
using System;

class Auxiliar : Empleado, IRecibirMercancia
    {

    private static List<Auxiliar> _listaAuxiliares = new List<Auxiliar>();
    public Auxiliar(string nombre, double sueldo, string area) : base(nombre, sueldo, area)
        {
        _listaAuxiliares.Add(this);
        }

    public void Recibir()
        {
        Console.WriteLine($"El auxiliar {this.Nombre} recibió la mercancía, debe almacenarla.");
        }

    public static List<Auxiliar> ListarAuxiliares()
        {
        return _listaAuxiliares;
        }

    }