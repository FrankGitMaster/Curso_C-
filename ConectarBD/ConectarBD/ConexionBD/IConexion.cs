using Npgsql;

namespace ConectarBD.ConexionBD
    {
    public interface IConexion
        {

        Task<NpgsqlConnection> ConectarBDAsync();

        }
    }
