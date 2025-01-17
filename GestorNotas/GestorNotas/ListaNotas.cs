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

        // Crear una nueva nota en la lista y retornar un mensaje que informa si la nota ha sido agregada con éxito
        public string CrearNota(string titulo)
            {
            Nota nuevaNota = new Nota(titulo);
            _listaNotas.AddLast(nuevaNota);
            return "Nota creada";
            }

        // Recorrer la lista de notas ordenando las notas por Estado y FechaHoraCreacion. Retorna todas las notas en un string
        public string RetornarListasNotas()
            {
            string notas = "";
            _listaNotas.OrderByDescending(nota => nota.Estado).ThenBy(nota => nota.FechaHoraCreacion).ToList().ForEach(nota => notas += nota.ToString());
            return notas;
            }

        // Imprimir las notas creadas y retornadas por el método RetornarListasNotas()
        public string VerNotas()
            {
            return $"{TituloListaNotas.ToUpper()}\n{RetornarListasNotas()}";
            }

        // Eliminar una nota en la lista y retornar un mensaje que informa si la nota ha sido eliminada con éxito
        public string EliminarNota(Nota nota)
            {
            _listaNotas.Remove(nota);
            return "Nota eliminada";
            }

        public List<Nota> GetListaNotas()
            {
            return _listaNotas.ToList();
            }
        }
    }