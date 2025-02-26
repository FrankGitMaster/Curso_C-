using ConectarBD_2.Infraestructura.ConexionBaseDatos;
using ConectarBD_2.Utils.MensajesSistema.Errores;
using Dapper;

namespace ConectarBD_2.Utils.Crud.DML
    {
    public class DataManipulationLanguage : IDataManipulationLanguage
        {

        private readonly IConexion _conexion;
        private readonly IGestorErrores _gestorErrores;

        public DataManipulationLanguage(IConexion conexion, IGestorErrores gestorErrores)
            {
            _conexion = conexion;
            _gestorErrores = gestorErrores;
            }

        public async Task<int> EjecutarComando(string query, object parametros)
            {
            try
                {
                await using var conexion = await _conexion.ConectarBD();
                var resultado = await conexion.ExecuteAsync(query, parametros);
                return resultado;
                }
            catch (Exception ex)
                {
                throw _gestorErrores.ManejarErrorBD("ejecutar el comando de manipulación", ex);
                
                }
            }
        }
    }
