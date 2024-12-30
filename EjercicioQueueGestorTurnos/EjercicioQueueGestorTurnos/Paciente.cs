namespace GestorTurnos
{
    class Paciente
    {

        private static int _setId = 1;
        public int Id { get; }
        public string Nombre { get; }
        public int Edad { get; }
        public bool TerceraEdad { get => Edad >= 60; }
        public EEps Eps { get; }
        private static List<Paciente> _listaPacientes = new List<Paciente>();

        public Paciente(string nombre, int edad, EEps eps)
        {
            Id = _setId++;
            Nombre = nombre;
            Edad = edad;
            Eps = eps;
            _listaPacientes.Add(this);
        }

        public static List<Paciente> GetListaPacientes()
        {
            return _listaPacientes;
        }

        public override string ToString()
        {
            return $"* PACIENTE:\n - Id: {Id}\n - Nombre: {Nombre}\n - Edad: {Edad}\n - Tercera edad: {(TerceraEdad ? "Sí" : "No")}\n - Eps: {Eps}\n";
        }
    }
}
