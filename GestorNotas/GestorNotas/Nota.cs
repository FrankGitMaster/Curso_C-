namespace GestorNotas
{
    class Nota : NotaBase
    {

        public string Titulo { get; }
        public string Estado { get; }

        public Nota(string titulo, string estado)
        {
            Titulo = titulo;
            Estado = estado; // el estado se asigna por defecto a "Incompleto"
        }

        public override string VerDetallesNota()
        {
            return $" - {FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy hh:mm")}\n - Título: {Titulo}\n - Estado: {Estado}\n";
        }
    }
}
