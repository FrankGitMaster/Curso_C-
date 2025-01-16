namespace GestorNotas
    {
    class Nota : Base
        {

        public string Titulo { get; }
        private bool _estado = false;
        public string Estado
            {
            get
                {
                if (_estado) return "Completo";
                else return "Incompleto";
                }
            }

        public Nota(string titulo)
            {
            Titulo = titulo;
            }

        public override string ToString()
            {
            return $"{FechaHoraCreacion.ToString(txtFormatoFecha)}\n - Título: {Titulo}\n - Estado: {Estado}\n";
            }
        }
    }