using Npgsql;

namespace ConectarBD_2.Infraestructura.ConexionBaseDatos
    {
    public interface IConexion
        {

        Task<NpgsqlConnection> ConectarBD();
        }
    }
