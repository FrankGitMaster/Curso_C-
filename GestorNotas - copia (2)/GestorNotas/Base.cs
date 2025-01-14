using System;

namespace GestorNotas
{
    class Base
    {

        public DateTime FechaHoraCreacion { get; }
        public string txtFormatoFecha = "dddd dd 'de' MMMM 'de' yyyy h:mm:ss tt";
        public Base()
        {
            FechaHoraCreacion = DateTime.Now;
        }
    }
}