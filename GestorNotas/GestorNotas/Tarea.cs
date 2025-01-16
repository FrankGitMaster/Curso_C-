using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorNotas
    {
    class Tarea : Base
        {

        public string Nombre { get; }
        public string Descripcion { get; }
        public CategoriaTarea Categoria { get; }
        public DateTime FechaHoraVencimiento { get; }

        public Tarea(string nombre, string descripcion, CategoriaTarea categoria, DateTime fechaHoraVencimiento)
            {
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            FechaHoraVencimiento = fechaHoraVencimiento;
            }

        public override string ToString()
            {
            return $"TAREA:\n{FechaHoraCreacion.ToString(txtFormatoFecha)}\n - Nombre: {Nombre}\n - Descripción: {Descripcion}\n - Categoría: {Categoria}\n - Fecha vencimiento: {FechaHoraVencimiento.ToString(txtFormatoFecha)}\n";
            }

        public static string VerCategoriasTarea()
            {
            string listaCategorias = "";
            List<string> categorias = Enum.GetNames(typeof(CategoriaTarea)).ToList();
            for(int i = 0; i < categorias.Count; i++) listaCategorias += $"{i+1}. {categorias[i]}\n";
            return listaCategorias;
            }

        public enum CategoriaTarea
            {
            Compras = 1,
            Deporte = 2,
            Hobbies = 3,
            Trabajo = 4,
            Estudio = 5,
            Otro = 6
            }
        }
    }