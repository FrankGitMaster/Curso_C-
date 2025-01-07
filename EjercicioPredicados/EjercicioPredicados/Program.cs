namespace Predicados
    {

    class Program
        {

        public static void Main(string[] args)
            {

            Producto p1 = new Producto("Pan", 2000);
            Producto p2 = new Producto("Azucar", 7000);
            Producto p3 = new Producto("Arina", 3500);
            Producto p4 = new Producto("Soda", 10000);

        /*  public static bool GetProductoMayor(Producto producto)
                {
                if(producto.Precio > 5000)
                    {
                    return true;
                    }
                else
                    {
                    return false;
                    }
                }*/

            // Con expresión lambda
            Predicate<Producto> buscarMayorA = producto => producto.Precio > 5000;
            //List<Producto> listaProductosMayores = Producto.GetListaProductos().FindAll(buscarMayorA);
            List<Producto> listaProductosMayores = Producto.GetListaProductos().FindAll(buscarMayorA);

            Console.WriteLine("Productos con precio mayor a 5000:");

            //foreach (Producto producto in listaProductosMayores) Console.WriteLine(producto.ToString());

            // Con expresión lambda
            listaProductosMayores.ForEach(producto => Console.WriteLine(producto.ToString()));
            }
        }

    class Producto
        {

        public string Nombre { get; }
        public decimal Precio { get; }
        private static List<Producto> _listaProductos = new List<Producto>();

        public Producto(string nombre, decimal precio)
            {
            Nombre = nombre;
            Precio = precio;
            _listaProductos.Add(this);
            }

        public static List<Producto> GetListaProductos() => _listaProductos;

        /*        public static void GetTodosLosProductos()
                    {
                    foreach (Producto producto in _listaProductos)
                        {
                        Console.WriteLine(producto.ToString());
                        }
                    }*/

        // Con expresión lambda
        public static void GetTodosLosProductos() => _listaProductos.ForEach(producto => Console.WriteLine(producto.ToString()));

        public override string ToString() => $"Nombre: {Nombre}\nPrecio: {Precio}\n";
        }
    }