using ConectarBD.CRUD;
using ConectarBD.Sentencias;

namespace ConectarBD
    {

    class Program
        {

        static async Task Main()
            {

            Conexion conexion = new Conexion();
            var ejecutarConsulta = new GestorCRUD(conexion);

            //CONSULTAR
            try
                {
                Task<List<(int idEmpleado, string nombre, long sueldo, bool bonificacion, DateTime fechaContrato)>> resultado = ejecutarConsulta.ConsultarEmpleadosAsync(SQL.ConsultarEmpleados);
                var listaEmpleados = await resultado;
                foreach (var empleado in listaEmpleados)
                    {
                    Console.WriteLine(
                        "ID: " + empleado.idEmpleado + "\n" +
                        "NOMBRE: " + empleado.nombre + "\n" +
                        "SUELDO: " + empleado.sueldo + "\n" +
                        "BONIFICACION: " + (empleado.bonificacion is true ? "Sí" : "No") + "\n" +
                        "FECHA CONTRATO: " + empleado.fechaContrato + "\n"
                        );
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.ToString());
                }

            //INGRESAR
            var parametrosNuevoEmpleado = (nombre: "Fredy", sueldo: 500000, bonificacion: true, fechaContrato: DateTime.Parse("07/08/1998"));
            /*try
                {
                await ejecutarConsulta.IngresarEmpleadoAsync(SQL.IngresarEmpleado, parametrosNuevoEmpleado);
                Console.WriteLine("Empleado ingresado con éxito!");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.ToString());
                }*/

            //ACTUALIZAR
            var parametrosActualizarEmpleado = (idEmpleado: 16, sueldo: 0, bonificacion: false);
            /*try
                {
                await ejecutarConsulta.ActualizarEmpleadoAsync(SQL.ActualizarEmpleado, parametrosActualizarEmpleado);
                Console.WriteLine("Empleado actualizado con éxito!");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.ToString());
                }*/

            //ELIMINAR
            /*try
                {
                await ejecutarConsulta.EliminarEmpleadoAsync(SQL.EliminarEmpleado, 16);
                Console.WriteLine("Empleado eliminado con éxito!");
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.ToString());
                }*/

            }
        }
    }