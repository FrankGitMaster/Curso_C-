using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
    {
    class ListaNotas : Base
        {

        private LinkedList<Nota> _listaNotas;
        public string TituloListaNotas { get; }
        public ListaNotas(string tituloListaNotas)
            {
            TituloListaNotas = tituloListaNotas;
            _listaNotas = new LinkedList<Nota>();
            }


        public override string ToString()
            {
            return $"LISTA NOTAS:\n{FechaHoraCreacion.ToString(txtFormatoFecha)}\n - Título: {TituloListaNotas}\n - Notas: {_listaNotas.Count}\n";
            }

        // Crear una nueva nota en la lista y retornar mensaje que informa si la nota ha sido agregada con exito
        public string CrearNota(string titulo)
            {
            string resultado = "";
            try
                {
                Nota nuevaNota = new Nota(titulo);
                _listaNotas.AddLast(nuevaNota);
                resultado = "(i) Nota creada";
                Console.ForegroundColor = ConsoleColor.Green;
                }
            catch (Exception ex)
                {
                resultado = $"(x) Error al crear la nota: {ex.Message}";
                Console.ForegroundColor = ConsoleColor.Red;
                }
            return resultado;
            }

        // Recorrer la lista de notas ordenando las notas por Esatdo y FechaHoraCreacion. Retorna todas las notas en un string
        public string RetornarListasNotas()
            {
            string notas = "";
            _listaNotas.OrderByDescending(nota => nota.Estado).ThenBy(nota => nota.FechaHoraCreacion).ToList().ForEach(nota => notas += nota.ToString());
            Console.ResetColor();
            return notas;
            }

        // Imprimir las notas creadas. Retorna string indicando que la lista de notas esta vacía en caso de que no hayan notas creadas en la lista consultada
        public string VerNotas()
            {
            return $"{TituloListaNotas.ToUpper()}\n{RetornarListasNotas()}\n";
            }

        public List<Nota> GetListaNotas()
            {
            return _listaNotas.ToList();
            }
        }
    }