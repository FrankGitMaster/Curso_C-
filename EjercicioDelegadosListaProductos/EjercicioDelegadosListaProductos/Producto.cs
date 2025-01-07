namespace DelegadosProductos
{
    internal class Producto : IComparable<Producto>
    {

        public string Nombre { get; }
        public decimal Precio { get; }
        public int CantidadInventario { get; }
        private static List<Producto> _listaProductos = new List<Producto>();
        private static List<Producto> _productosBaratos = new List<Producto>();

        public Producto(string nombre, decimal precio, int cantidadInventario)
        {
            Nombre = nombre;
            Precio = precio;
            CantidadInventario = cantidadInventario;
            _listaProductos.Add(this);
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Precio: {Precio}, Cantidad en inventario: {CantidadInventario}";
        }

        // EJERCICIO 1  : PREDICADO
        public static void ObtenerProductosBaratos()
        {
            Console.WriteLine("Productos baratos:");
            _productosBaratos = _listaProductos.FindAll(p => p.Precio <= 1000);
            _productosBaratos.ForEach(p => Console.WriteLine(p.ToString()));
            Console.WriteLine();
        }

        // EJERCICIO 2: FUNC
        /* Func: Puedes pasarlo como argumento a otros métodos(RetonarFunc, por ejemplo).
        Esto permite que un método genérico(RetonarFunc) maneje múltiples cálculos sin definir un método para cada uno.*/
        public static Func<Producto, decimal> funcInventarioProducto = p => p.Precio * p.CantidadInventario;
        public static Func<Producto, decimal> funcAplicarDescuento = p => p.Precio - p.Precio / 2;

        public static void RetonarFunc(Producto p, Func<Producto, decimal> func, string mensaje)
        {
            Console.WriteLine($"{p.Nombre} - {mensaje}: {func(p)}\n");
        }

        // EJERCICIO 3: ACTION
        public static Action<Producto> actionDetallesProducto = p => Console.WriteLine($"{p.ToString()}\n");

        // EJERCICIO 4: PREDICADO
        public int CompareTo(Producto other)
        {
            return this.Precio.CompareTo(other.Precio);
        }

        public static void RangoPrecios(decimal precioBajo, decimal precioAlto)
        {
            Console.WriteLine($"Lista productos con precio entre {precioBajo} y {precioAlto}: ");
            List<Producto> listaRangoPrecio = _listaProductos.FindAll(producto => producto.Precio >= precioBajo && producto.Precio <= precioAlto);
            listaRangoPrecio.Sort();
            listaRangoPrecio.ForEach(p => Console.WriteLine(p.ToString()));
            Console.WriteLine();
        }
    }
}
