using System;

namespace Repositorio
{

    class AppRepositorio
    {

        public static void Main(string[] args)
        {

            Repositorio<string> paises = new Repositorio<string>();
            paises.agregarElemento("Colombia");
            paises.agregarElemento("Chile");
            paises.agregarElemento("Brasil");

            Repositorio<int> loteria = new Repositorio<int>();
            loteria.agregarElemento(77);
            loteria.agregarElemento(98);
            loteria.agregarElemento(62);

            Producto pan = new Producto(1, "Pan", 2000);
            Producto queso = new Producto(2, "Queso", 5000);
            Producto gaseosa = new Producto(3, "Gaseosa", 4500);
            Repositorio<Producto> productos = new Repositorio<Producto>();
            productos.agregarElemento(pan);
            productos.agregarElemento(queso);
            productos.agregarElemento(gaseosa);

            //loteria.eliminarElemento(77);
            try
            {
                Console.WriteLine(productos.obtenerElemento(3));
            }catch(Exception ex)
            {
                Console.WriteLine("Capturada");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Todo good");
            /*foreach (Producto e in productos.obtenerTodos())
            {
                Console.WriteLine(e);
            }*/
        }
    }
}
