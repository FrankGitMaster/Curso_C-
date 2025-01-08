namespace ProyectoGestorDeTareas
{
    abstract class Tarea
    {

        public string Titulo { get; }
        public string Descripcion { get; }
        public Tarea(string titulo, string descripcion)
        {
            Titulo = titulo;
            Descripcion = descripcion;
        }

        public abstract string VerDetallesTarea();
    }
}
