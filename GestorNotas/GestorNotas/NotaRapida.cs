namespace GestorNotas
{
    class NotaRapida : NotaBase
    {

        public string Titulo { get; }
        public string Nota { get; }

        public NotaRapida(string titulo, string nota)
        {
            Titulo = titulo;
            Nota = nota;
        }

        public override string VerDetallesNota()
        {
            return $"{FechaHoraCreacion.ToString("dddd dd 'de' MMMM 'de' yyyy hh:mm")}\nTítulo: {Titulo}\nNota: {Nota}\n";
        }
    }
}
