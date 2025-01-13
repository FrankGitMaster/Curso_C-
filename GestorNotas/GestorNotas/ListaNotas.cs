using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
{
    class ListaNotas : NotaBase
    {

        private LinkedList<Nota> _listaNotas = new LinkedList<Nota>();
        public string TituloListaNotas { get; }

        public ListaNotas(string tituloListaNotas)
        {
            TituloListaNotas = tituloListaNotas;
        }

        public string CrearNota(Nota nota)
        {
            _listaNotas.AddLast(nota);
            return "(i) Nota agregada";
        }

        public string RecorrerLista()
        {
            string notas = "";
            _listaNotas.Select(nota => nota).OrderByDescending(nota => nota.Estado).ThenBy(nota => nota.FechaHoraCreacion).ToList().ForEach(nota => notas += nota.VerDetallesNota());
            return notas;
        }

        public override string VerDetallesNota()
        {
            return $"{FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy hh:mm")}\nTítulo: {TituloListaNotas}\n{(_listaNotas.Count > 0 ? RecorrerLista() : "La lista esta vacía")}\n";
        }
    }
}
