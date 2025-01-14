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

        public override string ToString()
        {
            return $"NOTA RAPIDA:\n{FechaHoraCreacion.ToString(txtFormatoFecha)}\nTítulo: {Titulo}\nNota: {Nota}\n";
        }
    }
}