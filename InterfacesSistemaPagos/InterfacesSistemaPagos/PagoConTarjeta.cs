namespace InterfacesSistemaPagos
    {
    internal class PagoConTarjeta : IPago
        {

        public void ProcesarPago(double monto)
            {
            Console.WriteLine($"Procesando el pago de {monto} con tarjeta. ¡Pago exitoso!");
            }
        }
    }
