using ConectarBD_2.ConexionBD;

namespace ConectarBD_2.Utilidades.CRUD
    {
    public class GestorCrudConsultas
        {

        private readonly IConexionBD _conexionBD;

        public GestorCrudConsultas(IConexionBD conexionBD)
            {
            _conexionBD = conexionBD;
            }

        public void Consultar<T>(string query, T parametros)
            {
            try
                {
                using(var conexion = _conexionBD.ConectarBDAsync())
                    {
                    IEnumerable<T> resultado  = conexion.Query<T>(query);
                    }
                }
            catch (Exception ex)
                {
                throw;
                }
            }

        }
    }
