namespace InterfacesSistemaPagos
    {
    internal class PagoEnEfectivo : IPago
        {

        public void ProcesarPago(double monto)
            {
            Console.WriteLine($"Pago de {monto} en efectivo. ¡Pago exitoso!");
            }
        }
    }
