﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
    {
    class ListaNotas : ListaBase
        {

        private static LinkedList<Nota> _listaNotas = new LinkedList<Nota>();
        public string TituloListaNotas { get; }
        public ListaNotas(string tituloListaNotas)
            {
            TituloListaNotas = tituloListaNotas;
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

        // Recorrer la lista de notas y ordenarla por estado y luego por fecha de creación para retornar las notas como string
        public override string RetornarElementosLista()
            {
            string notas = "";
            _listaNotas.OrderByDescending(nota => nota.Estado).ThenBy(nota => nota.FechaHoraCreacion).ToList().ForEach(nota => notas += nota.VerDetalles());
            Console.ResetColor();
            return notas;
            }

        // Imprimir las notas de la lista, muestra mensaje indicando que la lista esta vacía en caso de que no hayan notas
        public override string VerElementosLista()
            {
            return $"NOTAS:\n{FechaHoraCreacion.ToString(txtFormatoFecha)}\nTítulo: {TituloListaNotas}\n{(_listaNotas.Count > 0 ? RetornarElementosLista() : "No hay notas")}\n";
            }

        public static List<Nota> GetListaNotas()
            {
            return _listaNotas.ToList();
            }

        public override string ToString()
            {
            return $"NOTAS:\n{FechaHoraCreacion.ToString(txtFormatoFecha)}\nTítulo: {TituloListaNotas}\n";
            }
        }
    }
