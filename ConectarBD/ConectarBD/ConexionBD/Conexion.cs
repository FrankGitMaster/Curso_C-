using ConectarBD.ConexionBD;
using Npgsql;

namespace ConectarBD
    {

    /// <summary>
    /// Clase con el método necesario para establecer la conexión con la BD
    /// </summary>
    public class Conexion : IConexion
        {

        private readonly string ConnectionString = "Host=localhost;Port=5432;Database=empresa;Username=postgres;Password=1234;";

        /// <summary>
        /// Método que abre la conexión a la BD
        /// </summary>
        /// <returns>Objeto NpgsqlConnection con la conexión abierta a la BD</returns>
        /// <exception cref="Exception">Mensaje de error en case de que no se pueda establecer la conexión con la BD</exception>
        public async Task<NpgsqlConnection> ConectarBDAsync()
            {
            try
                {
                var conexion = new NpgsqlConnection(ConnectionString);
                await conexion.OpenAsync();
                return conexion;
                }
            catch (Exception ex)
                {
                throw new Exception($"Error al intentar conectar a la BD.\n{ex.Message}");
                }
            }
        }
    }
