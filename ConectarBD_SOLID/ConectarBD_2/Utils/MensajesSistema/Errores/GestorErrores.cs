namespace ConectarBD_2.Utils.MensajesSistema.Errores
    {
    public class GestorErrores : IGestorErrores
        {

        public Exception ManejarErrorBD(string mensaje, Exception ex)
            {
            return new Exception($"Error al intentar {mensaje} de la base de datos.\n{ex}");
            }
        }
    }
