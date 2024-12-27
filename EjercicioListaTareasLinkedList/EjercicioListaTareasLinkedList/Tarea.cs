namespace ListaTareas
    {

    class Tarea
        {

        private bool _completada;
        public string Descripcion { get; set; }
        public bool Completada { get { return _completada; } set { _completada = value; } }

        public Tarea(string descripcion)
            {
            Descripcion = descripcion;
            }

        public string GetCompletada()
            {
            if (_completada)
                {
                return "Completada";
                }
            else
                {
                return "Pendiente";
                }
            }
        }
    }