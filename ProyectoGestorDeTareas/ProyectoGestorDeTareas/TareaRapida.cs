namespace ProyectoGestorDeTareas
    {
    class TareaRapida : Tarea
        {

        public static int Counter { get; private set; }
        public int Id { get; }
        public TareaRapida(string titulo) : base(titulo)
            {
            Counter++;
            Id = Counter;
            }

        public override string VerDetallesTarea() => $"- Id: {Id}\n- Título: {Titulo}\n";
        }
    }
