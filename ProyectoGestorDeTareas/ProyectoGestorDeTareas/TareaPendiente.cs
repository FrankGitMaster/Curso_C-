using System;
using System.Collections.Generic;

namespace ProyectoGestorDeTareas
{
    internal class TareaPendiente : Tarea
    {

        private List<TareaPendiente> _listaTareasPendientes = new List<TareaPendiente>();
        public ECategoria Categoria { get; }
        public EPrioridad Prioridad { get; }
        public TareaPendiente(string titulo, string descripcion, ECategoria categoria, EPrioridad prioridad) : base(titulo, descripcion)
        {
            Categoria = categoria;
            Prioridad = prioridad;
            _listaTareasPendientes.Add(this);
        }

        public override string VerDetallesTarea()
        {
            return "";
        }
    }
}
