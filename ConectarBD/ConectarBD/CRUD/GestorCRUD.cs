using Npgsql;

namespace ConectarBD.CRUD
    {

    /// <summary>
    /// Clase con los métodos necesarios para ejecutar la función de un sistema CRUD
    /// </summary>
    public class GestorCRUD : IGestorCRUD
        {

        private readonly Conexion _conexion;

        /// <summary>
        /// Metodo constructor con la inyección de las dependencias necesarias para la ejecución del programa
        /// </summary>
        /// <param name="conexion">Parámetro de tipo Conexion para establecer la conexión con la BD</param>
        public GestorCRUD(Conexion conexion)
            {
            _conexion = conexion;
            }

        /// <summary>
        /// Método asíncrono para consultar los empleados de la BD
        /// </summary>
        /// <param name="sentencia">Parámetro con la sentencia SQL para realizar la consulta de los empleados en la BD</param>
        /// <returns>Lista de tipo ValueTuple con los valores de los campos de cada registro de la tabla empleado en la BD</returns>
        /// <exception cref="Exception">Mensaje de error en caso de que no se cumplan las condiciones para ejecutar la consulta</exception>
        public async Task<List<(int, string, long, bool, DateTime)>> ConsultarEmpleadosAsync(string sentencia)
            {
            List<(int, string, long, bool, DateTime)> listaEmpleados = new List<(int, string, long, bool, DateTime)>();
            try
                {
                Console.WriteLine("Conectando...");
                using (var conexion = await _conexion.ConectarBDAsync())
                    {
                    using (var command = new NpgsqlCommand(sentencia, conexion))
                    using (var reader = await command.ExecuteReaderAsync())
                        {
                        while (await reader.ReadAsync())
                            {
                            var empleado = (
                                idEmpleado: reader.GetInt32(0),
                                nombre: reader.GetString(1),
                                sueldo: reader.GetInt64(2),
                                bonificacion: reader.GetBoolean(3),
                                fechaContrato: reader.IsDBNull(4) ? DateTime.Now : reader.GetDateTime(4)
                                );

                            listaEmpleados.Add(empleado);
                            }
                        }
                    return listaEmpleados;
                    }
                }
            catch (Exception ex)
                {
                throw new Exception($"Error al intentar realizar la consulta en la BD: {ex.Message}");
                }
            }

        /// <summary>
        /// Método asíncrono para ingresar un empleado en la BD
        /// </summary>
        /// <param name="sentencia">Parámetro con la sentencia SQL para realizar la inserción del empleado de la BD</param>
        /// <param name="parametros">Parámetro de tipo ValueType con los valores del nuevo empleado a ingresar en la BD</param>
        /// <returns></returns>
        /// <exception cref="Exception">Mensaje de error en caso de que no se cumplan las condiciones para ejecutar la inserción</exception> 
        public async Task IngresarEmpleadoAsync(string sentencia, (string nombre, long sueldo, bool bonificacion, DateTime fechaContrato) parametros)
            {
            try
                {
                using (var conexion = await _conexion.ConectarBDAsync())
                    {
                    using (var command = new NpgsqlCommand(sentencia, conexion))
                        {
                        command.Parameters.AddWithValue("@nombre", parametros.nombre);
                        command.Parameters.AddWithValue("@sueldo", parametros.sueldo);
                        command.Parameters.AddWithValue("@bonificacion", parametros.bonificacion);
                        command.Parameters.AddWithValue("@fecha_contrato", parametros.fechaContrato);
                        await command.ExecuteNonQueryAsync();
                        }
                    }
                }
            catch (Exception ex)
                {
                throw new Exception($"Error al intentar ingresar el empleado en la BD.\n{ex.Message}");
                }
            }

        /// <summary>
        /// Método asíncrono para actualizar un empleado en la BD
        /// </summary>
        /// <param name="sentencia">Parámetro con la sentencia SQL para realizar la actualización del empleado de la BD</param>
        /// <param name="parametros">Parámetro de tipo ValueType con los valores del empleado a actualizar en la BD</param>
        /// <returns></returns>
        /// <exception cref="Exception">Mensaje de error en caso de que no se cumplan las condiciones para ejecutar la actualización</exception>
        public async Task ActualizarEmpleadoAsync(string sentencia, (int idEmpleado, long sueldo, bool bonificacion) parametros)
            {
            try
                {
                using (var conexion = await _conexion.ConectarBDAsync())
                    {
                    using (var command = new NpgsqlCommand(sentencia, conexion))
                        {
                        command.Parameters.AddWithValue("@IdEmpleado", parametros.idEmpleado);
                        command.Parameters.AddWithValue("@sueldo", parametros.sueldo);
                        command.Parameters.AddWithValue("@bonificacion", parametros.bonificacion);
                        var actualizar = await command.ExecuteNonQueryAsync();
                        }
                    }
                }
            catch (Exception ex)
                {
                throw new Exception($"Error al intentar actualizar el empleado en la BD.\n{ex.Message}");
                }
            }

        /// <summary>
        /// Método asíncrono para eliminar un empleado en la BD
        /// </summary>
        /// <param name="sentencia">Parámetro con la sentencia SQL para realizar la eliminación del empleado de la BD</param>
        /// <param name="idEmpleado">Parámetro de tipo int con el identificador del empleado a eliminar en la BD</param>
        /// <returns></returns>
        /// <exception cref="Exception">Mensaje de error en caso de que no se cumplan las condiciones para ejecutar la eliminación</exception>
        public async Task EliminarEmpleadoAsync(string sentencia, int idEmpleado)
            {
            string error = string.Empty;
            try
                {
                using (var conexion = await _conexion.ConectarBDAsync())
                    {
                    using (var command = new NpgsqlCommand(sentencia, conexion))
                        {
                        command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        var resultado = await command.ExecuteNonQueryAsync();
                        if (resultado.Equals(0))
                            throw new Exception($"El empleado con id {idEmpleado} no existe en la BD.\n");
                        }
                    }
                }
            catch (Exception ex)
                {
                throw new Exception($"Error al intentar eliminar el empleado de la BD.\n{ex.Message}");
                }
            }

        }
    }
