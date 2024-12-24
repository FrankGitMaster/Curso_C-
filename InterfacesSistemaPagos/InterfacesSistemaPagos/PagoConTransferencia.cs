namespace InterfacesSistemaPagos
    {
    internal class PagoConTransferencia : IPago
        {

        public void ProcesarPago(double monto)
            {
            Console.WriteLine($"Procesando el pago de {monto} por transferencia. ¡Pago exitoso!");
            }
        }
    }
