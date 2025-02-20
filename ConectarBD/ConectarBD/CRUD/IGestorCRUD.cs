namespace ConectarBD.CRUD;

public interface IGestorCRUD
    {

    Task<List<(int, string, long, bool, DateTime)>> ConsultarEmpleadosAsync(string sentencia);

    Task IngresarEmpleadoAsync(string sentencia, (string nombre, long sueldo, bool bonificacion, DateTime fechaContrato) parametros);

    Task ActualizarEmpleadoAsync(string sentencia, (int idEmpleado, long sueldo, bool bonificacion) parametros);

    Task EliminarEmpleadoAsync(string sentencia, int idEmpleado);

    }

