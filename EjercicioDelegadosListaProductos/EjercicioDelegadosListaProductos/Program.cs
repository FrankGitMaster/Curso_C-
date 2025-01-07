namespace DelegadosProductos{

    class Program
    {

        public static void Main(string[] args) {

            Producto p1 = new Producto("Pan", 1000, 100);
            Producto p2 = new Producto("Arina", 2500, 20);
            Producto p3 = new Producto("Huevo", 500, 250);
            Producto p4 = new Producto("Queso", 5000, 50);
            Producto p5 = new Producto("Aceite", 2000, 25);

            Producto.ObtenerProductosBaratos();

            Producto.RetonarFunc(p2, Producto.funcInventarioProducto, "Inventario del producto ");

            Producto.actionDetallesProducto(p3);

            Producto.RangoPrecios(1000, 3000);
        }
    }
}