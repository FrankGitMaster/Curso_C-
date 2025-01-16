using System;

namespace GestorNotas
    {
    static class ColorMensajeHelper
        {

        public static void ColorMensaje(int codigoTipoMensaje, string mensaje)
            {
            if (codigoTipoMensaje == (int)TipoMensaje.Input)
                {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" - {mensaje}");
                }
            if (codigoTipoMensaje == (int)TipoMensaje.Succes)
                {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"(\u221A) {mensaje}");
                }
            else if (codigoTipoMensaje == (int)TipoMensaje.Error)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"(x) {mensaje}");
                }
            else if (codigoTipoMensaje == (int)TipoMensaje.Alert)
                {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"(i) {mensaje}");
                }
            Console.ResetColor();
            }

        private enum TipoMensaje
            {
            Input,
            Succes,
            Error,
            Alert
            }
        }
    }
