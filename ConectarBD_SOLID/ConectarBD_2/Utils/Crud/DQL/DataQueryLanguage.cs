using ConectarBD_2.Infraestructura.ConexionBaseDatos;
using ConectarBD_2.Utils.MensajesSistema.Errores;
using Dapper;

namespace ConectarBD_2.Utils.Crud.DQL
    {
    public class DataQueryLanguage : IDataQueryLanguage
        {

        private readonly IConexion _conexion;
        private readonly IGestorErrores _gestorErrores;

        public DataQueryLanguage(IConexion conexion, IGestorErrores gestorErrores)
            {
            _conexion = conexion;
            _gestorErrores = gestorErrores;
            }

        public async Task<List<T>> Consultar<T>(string query)
            {
            try
                {
                await using var conexion = await _conexion.ConectarBD();
                var resultado = await conexion.QueryAsync<T>(query);
                return resultado.ToList();
                }
            catch (Exception ex)
                {
                throw _gestorErrores.ManejarErrorBD("ejecutar la consulta", ex);
                }
            }
        }
    }
