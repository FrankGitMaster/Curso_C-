using Npgsql;

namespace ConectarBD_2.ConexionBD;

public class ConexionBD : IConexionBD
    {

    private readonly string _connectionString = "Host=localhost;Port=5432;Database=empresa;User=postgres;Password=1234;";

    public async Task<NpgsqlConnection> ConectarBDAsync()
        {
        try
            {
            var conexion = new NpgsqlConnection(_connectionString);
            await conexion.OpenAsync();
            return conexion;
            }
        catch (Exception ex)
            {
            throw new Exception($"Error al intentar conectar a la base de datos.\n{ex.Message}");
            }
        }
    }

