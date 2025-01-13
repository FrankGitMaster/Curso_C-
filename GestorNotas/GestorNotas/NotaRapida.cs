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

        public override string VerDetalles()
        {
            return $"NOTARAPIDA:\n{FechaHoraCreacion.ToString(txtFormatoFecha)}\nTítulo: {Titulo}\nNota: {Nota}\n";
        }

        public override string ToString()
            {
            return VerDetalles();
            }
        }
}
