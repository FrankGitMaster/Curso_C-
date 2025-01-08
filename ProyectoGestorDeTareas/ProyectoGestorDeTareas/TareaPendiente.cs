namespace ProyectoGestorDeTareas
{
    internal class TareaPendiente : Tarea
    {

        public static int Counter { get; private set; }
        public string Descripcion { get; }
        public ECategoria Categoria { get; }
        public EPrioridad Prioridad { get; }
        public TareaPendiente(string titulo, string descripcion, ECategoria categoria, EPrioridad prioridad) : base(titulo)
        {
            Counter++;
            Descripcion = descripcion;
            Categoria = categoria;
            Prioridad = prioridad;
        }

        public override string VerDetallesTarea() => $"DETALLES DE LA TAREA PENDIENTE:\n- Título: {Titulo}\n- Descripción: {Descripcion}\n- Categoría: {Categoria}\n- Prioridad: {Prioridad}\n";
    }
}
