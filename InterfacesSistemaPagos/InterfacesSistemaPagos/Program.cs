namespace InterfacesSistemaPagos
    {
    class Program
        {

        public static void Main(string[] args)
            {

            do
                {
                double monto;
                Console.WriteLine("Seleccione el método de pago:\n1. Tarjeta\n2. Efectivo\n3. Transferencia");
                string? metodoSeleccionado = Console.ReadLine();
                switch (metodoSeleccionado)
                    {
                    case "1":
                        PagoConTarjeta tarjeta = new PagoConTarjeta();
                        monto = IngresarMonto();
                        tarjeta.ProcesarPago(monto);
                        break;
                    case "2":
                        PagoEnEfectivo efectivo = new PagoEnEfectivo();
                        monto = IngresarMonto();
                        efectivo.ProcesarPago(monto);
                        break;
                    case "3":
                        PagoConTransferencia transferencia = new PagoConTransferencia();
                        monto = IngresarMonto();
                        transferencia.ProcesarPago(monto);
                        break;
                    default:
                        Console.WriteLine("Ingrese un método de pago de la lista");
                        continue;
                    }
                break;
                } while (true);
            }

        public static double IngresarMonto()
            {

            double montoAPagar;
            do
                {
                Console.Write("Ingrese el monto a pagar: ");
                if (!Double.TryParse(Console.ReadLine(), out montoAPagar))
                    {
                    Console.WriteLine("Ingrese un valor númerico");
                    continue;
                    }
                else if (montoAPagar <= 0)
                    {
                    Console.WriteLine("Ingrese un monto mayor a 0");
                    continue;
                    }
                break;
                } while (true);
            return montoAPagar;
            }
        }
    }
