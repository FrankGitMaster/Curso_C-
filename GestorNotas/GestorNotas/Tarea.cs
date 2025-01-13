using System;

namespace GestorNotas
    {
    class Tarea : NotaBase
        {

        public string Nombre { get; }
        public string Descripcion { get; }
        public CategoriaTarea Categoria { get; }
        public DateTime FechaHoraVencimiento { get; }

        public Tarea(string nombre, string descripcion, CategoriaTarea categoria, string fechaHoraVencimiento)
            {
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;

            // Validar la fecha de vencimiento antes de parsear, se arroja una excepcion capturada por el método CrearTarea() si el valor ingresado es inválido
            if (string.IsNullOrEmpty(fechaHoraVencimiento) || !DateTime.TryParse(fechaHoraVencimiento, out _))
                {
                throw new FormatException("La fecha de vencimiento ingresada no es válida");
                }

            FechaHoraVencimiento = DateTime.Parse(fechaHoraVencimiento);
            }


        public override string VerDetalles()
            {
            return $"{FechaHoraCreacion.ToString(txtFormatoFecha)}\n - Nombre: {Nombre}\n - Descripción: {Descripcion}\n - Categoría: {Categoria}\n - Fecha vencimiento: {FechaHoraVencimiento.ToString(txtFormatoFecha)}\n";
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
