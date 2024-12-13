using Herencia;
using System.Collections.Generic;
using System.Linq;
using System;

class Coordinador : Jefe, IRecibirMercancia
    {

    private List<Auxiliar> _listaAuxiliaresCoordinador;

    public Coordinador(string nombre, double sueldo, string area, double comision) : base(nombre, sueldo, area, comision)
        {
        _listaAuxiliaresCoordinador = new List<Auxiliar>();
        }

    public void AgregarAuxiliar()
        {
        Console.WriteLine(("lista de auxiliares").ToUpper());
        List<Auxiliar> listaAuxiliares = Auxiliar.ListarAuxiliares();
        VerMiembrosLista(listaAuxiliares);
        do
            {
            int idNuevoAuxiliar;
            Auxiliar nuevoAuxiliar;
            while (true)
                {
                Console.WriteLine("Ingrese el ID del auxiliar que desea ingresar:");
                if (!Int32.TryParse(Console.ReadLine(), out idNuevoAuxiliar))
                    {
                    Console.WriteLine("ERROR: Ingrese un valor númerico para el id del auxiliar.");
                    continue;
                    }
                else
                    {
                    break;
                    }
                }
            for (int i = 0; i < listaAuxiliares.Count; i++)
                {
                if (listaAuxiliares[i].Id.Equals(idNuevoAuxiliar))
                    {
                    nuevoAuxiliar = listaAuxiliares[i];
                    _listaAuxiliaresCoordinador.Add(nuevoAuxiliar);
                    Console.WriteLine($"Se agregó el empleado {nuevoAuxiliar.Nombre} al area del coordinador {this.Nombre}");
                    break;
                    }
                else if (i == listaAuxiliares.Count-1 && !listaAuxiliares[i].Id.Equals(idNuevoAuxiliar))
                    {
                    Console.WriteLine($"El Auxiliar con ID: {idNuevoAuxiliar} no existe.");
                    }
                }
            string respuesta = "";
            do
                {
                Console.WriteLine("¿Desea agregar otro auxiliar?");
                respuesta = Console.ReadLine();
                if (String.IsNullOrEmpty(respuesta) || !respuesta.All(char.IsLetter) || (!respuesta.Equals("si", StringComparison.OrdinalIgnoreCase) && !respuesta.Equals("no", StringComparison.OrdinalIgnoreCase)))
                    {
                    Console.WriteLine("Ingrese Si o No para continuar.");
                    continue;
                    }
                else
                    {
                    if (respuesta.Equals("si", StringComparison.OrdinalIgnoreCase))
                        {
                        respuesta = "si";
                        }
                    else if (respuesta.Equals("no", StringComparison.OrdinalIgnoreCase))
                        {
                        respuesta = "no";
                        }
                    break;
                    }
                } while (true);
            if (respuesta == "si")
                {
                continue;
                }
            else
                {
                break;
                }
            } while (true);
        }

    public List<Auxiliar> ListarAuxiliaresCoordinador()
        {
        return _listaAuxiliaresCoordinador;
        }

    public void Recibir()
        {
        Console.WriteLine($"El coordinador {this.Nombre} recibió la mercancía.");
        }
    }