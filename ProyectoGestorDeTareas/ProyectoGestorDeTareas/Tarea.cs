namespace ProyectoGestorDeTareas
{
    abstract class Tarea
    {

        public string Titulo { get; }
        public Tarea(string titulo)
        {
            Titulo = titulo;
        }

        public abstract string VerDetallesTarea();
    }
}
