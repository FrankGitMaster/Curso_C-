using Npgsql;

namespace ConectarBD_2.ConexionBD
    {
    public interface IConexionBD
        {

        Task<NpgsqlConnection> ConectarBDAsync();

        }
    }
