using ConectarBD_2.Utils.Modelos;

namespace ConectarBD_2.Negocio.CapaGestorEmpleado;

public interface IGestorEmpleado
    {

    Task<List<T>> ConsultarEmpleados<T>() where T : Empleado;

    Task<int> InsertarEmpleado<T>(T parametros) where T : Empleado;

    Task<int> ActualizarEmpleado<T>(T parametros) where T : Empleado;

    Task<int> EliminarEmpleado<T>(T parametros) where T : Empleado;
    }

