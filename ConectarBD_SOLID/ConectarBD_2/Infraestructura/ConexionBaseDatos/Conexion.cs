using ConectarBD_2.Utils.MensajesSistema.Errores;
using Npgsql;

namespace ConectarBD_2.Infraestructura.ConexionBaseDatos
    {
    public class Conexion : IConexion
        {

        private readonly string _connectionString = "Host=localhost;Port=5432;Database=empresa;Username=postgres;Password=1234;";
        private readonly IGestorErrores _gestorErrores;

        public Conexion(IGestorErrores gestorErrores)
            {
            _gestorErrores = gestorErrores;
            }

        public async Task<NpgsqlConnection> ConectarBD()
            {
            try
                {
                var conexion = new NpgsqlConnection(_connectionString);
                await conexion.OpenAsync();
                return conexion;
                }
            catch (Exception ex)
                {
                throw _gestorErrores.ManejarErrorBD("establecer la conexión", ex);
                }
            }
        }
    }
