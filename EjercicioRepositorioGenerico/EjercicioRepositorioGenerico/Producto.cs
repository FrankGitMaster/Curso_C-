namespace Repositorio
{
    class Producto
    {

        private int _id;
        private string _nombre;
        private double _precio;

        public Producto(int id, string nombre, double precio)
        {
            _id = id;
            _nombre = nombre;
            _precio = precio;
        }

        public override string ToString()
        {
            return $"Id={_id}\nNombre={_nombre}\nPrecio={_precio}\n";
        }
    }
}
