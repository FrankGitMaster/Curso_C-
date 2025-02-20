namespace AsyncAwait
    {

    class Program
        {

        //PROGRAMACIÓN ASINCRÓNICA USANDO WHEN ANY
        //Realiza funciones en paralelo.
        //public static async Task Main(string[] args)
        //    {
        //    List<int> pedidos = new List<int>() { 1, 2, 3, 4, 5 };
        //    List<Task<string>> pedidosEnProceso = new List<Task<string>>();
        //    foreach (int pedido in pedidos)
        //        {
        //        pedidosEnProceso.Add(ProcesarPedidoAsync(pedido));
        //        }
        //    while (pedidosEnProceso.Count > 0)
        //        {
        //        var pedidoListo = await Task.WhenAny(pedidosEnProceso);
        //        pedidosEnProceso.Remove(pedidoListo);
        //        Console.WriteLine(await pedidoListo);
        //        }
        //    }

        //public static async Task<string> ProcesarPedidoAsync(int pedidoId)
        //    {
        //    Console.WriteLine("Procesando pedido...");
        //    var tiempoEspera = new Random().Next(1000, 10000);
        //    await Task.Delay(tiempoEspera);
        //    return $"Pedido {pedidoId} listo en {tiempoEspera / 1000} minutos";
        //    }

        //PROGRAMACIÓN SINCRÓNICA
        //Espera a que finalice una función para iniciar con la siguiente.
        //public static void Main(string[] args)
        //    {
        //    List<string> listaPedidos = new List<string>();
        //    var pedidoListo1 = ProcesarPedido(01);
        //    var pedidoListo2 = ProcesarPedido(02);
        //    listaPedidos.Add(pedidoListo1);
        //    listaPedidos.Add(pedidoListo2);
        //    foreach (var pedido in listaPedidos)
        //        {
        //        Console.WriteLine(pedido);
        //        }
        //    }

        //public static string ProcesarPedido(int pedidoId)
        //    {
        //    Console.WriteLine("Procesando pedido...");
        //    int tiempoEspera = 0;
        //    tiempoEspera = new Random().Next(1000, 10000);
        //    Thread.Sleep(tiempoEspera);
        //    return $"Pedido {pedidoId} listo en {tiempoEspera / 1000} minutos";
        //    }

        static async Task Main(string[] args)
            {

            List<string> urls = new List<string>()
                {
                "https://website/archivo1.zip",
                "https://website/archivo2.zip",
                "https://website/archivo3.zip",
                };

            List<Task<string>> archivosEnDesacarga = new List<Task<string>>();

            foreach (var url in urls)
                archivosEnDesacarga.Add(DescargarArchivos(url));

            string[] archivosDescargados = await Task.WhenAll(archivosEnDesacarga);

            foreach(var archivo in archivosDescargados)
                Console.WriteLine(archivo + " descargado!");

            Console.WriteLine("Procesando archivos...");
            while(archivosEnDesacarga.Count > 0)
                {
                var archivoPreocesado = await Task.WhenAny(archivosEnDesacarga);
                archivosEnDesacarga.Remove(archivoPreocesado);
                string resultado = await archivoPreocesado;
                Console.WriteLine(resultado + " procesado!");
                }
            }


        public static async Task<string> DescargarArchivos(string url)
            {
            int delayDescarga = new Random().Next(0, 10000);
            Console.WriteLine("Descargando archivos...");
            await Task.Delay(delayDescarga);
            string[] archivos = url.Split('/');
            return archivos.Last();
            }

        }
    }