using ConectarBD_2.Infraestructura.ConexionBaseDatos;
using ConectarBD_2.Negocio.CapaGestorEmpleado;
using ConectarBD_2.Utils.Crud.DQL;
using ConectarBD_2.Utils.Crud.DML;
using Microsoft.Extensions.DependencyInjection;
using ConectarBD_2.Utils.Modelos;
using ConectarBD_2.Utils.MensajesSistema.Errores;

namespace ConectarBD_2
    {

    public class Program
        {
        public static IConexion conexion;
        public static IDataQueryLanguage consultasBD;

        public static async Task Main()
            {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConexion, Conexion>()
                .AddScoped<IDataQueryLanguage, DataQueryLanguage>()
                .AddScoped<IDataManipulationLanguage, DataManipulationLanguage>()
                .AddScoped<IGestorEmpleado, GestorEmpleado>()
                .AddScoped<IGestorErrores, GestorErrores>()
                .BuildServiceProvider();

            try
                {
                var gestorEmpleado = serviceProvider.GetService<IGestorEmpleado>();
                //INSERTAR
                //var empleadoNuevo = new Empleado { Nombre = "El Otro Nuevo 4", Sueldo = 777777, Bonificacion = true, FechaContrato = DateTime.Parse("01/01/2100") };
                //var resultadoInsercion = await gestorEmpleado.InsertarEmpleado(empleadoNuevo);
                //Console.WriteLine($"Se insertó {resultadoInsercion} nuevo/s empleado/s");

                //ACTUALIZAR
                //var empleadoActualizado = new Empleado { IdEmpleado = 17, Nombre = "Homero", Sueldo = 50000000, Bonificacion = true, FechaContrato = DateTime.Parse("01/01/2025") };
                //var resultadoActualizacion = await gestorEmpleado.ActualizarEmpleado(empleadoActualizado);
                //Console.WriteLine($"Se actualizó {resultadoActualizacion} empleado/s");

                //ELIMINAR
                //var empleadoEliminado = new Empleado { IdEmpleado = 20 };
                //var resultadoEliminacion = await gestorEmpleado.EliminarEmpleado(empleadoEliminado);
                //Console.WriteLine($"Se eliminó {resultadoEliminacion} empleado/s");

                //CONSULTAR
                var resultadoConsulta = await gestorEmpleado.ConsultarEmpleados<Empleado>();
                foreach (var e in resultadoConsulta)
                    {
                    Console.WriteLine(e.IdEmpleado);
                    Console.WriteLine(e.Nombre);
                    Console.WriteLine(e.Sueldo);
                    Console.WriteLine(e.Bonificacion);
                    Console.WriteLine(e.FechaContrato + "\n");
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                }
            }
        }
    }