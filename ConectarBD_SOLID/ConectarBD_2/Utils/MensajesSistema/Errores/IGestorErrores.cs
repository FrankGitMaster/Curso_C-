namespace ConectarBD_2.Utils.MensajesSistema.Errores
    {
    public interface IGestorErrores
        {

        Exception ManejarErrorBD(string mensaje, Exception ex);
        }
    }
