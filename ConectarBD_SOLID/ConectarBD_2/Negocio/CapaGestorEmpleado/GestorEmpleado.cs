using ConectarBD_2.Negocio.CapaGestorEmpleado.Sentencias;
using ConectarBD_2.Utils.Crud.DQL;
using ConectarBD_2.Utils.Crud.DML;
using ConectarBD_2.Utils.Modelos;
using ConectarBD_2.Utils.MensajesSistema.Errores;

namespace ConectarBD_2.Negocio.CapaGestorEmpleado
    {
    public class GestorEmpleado : IGestorEmpleado
        {

        private readonly IDataQueryLanguage _dataQueryLanguage;
        private readonly IDataManipulationLanguage _dataManipulationLanguage;
        private readonly IGestorErrores _gestorErrores;

        public GestorEmpleado(IDataQueryLanguage dataQueyLanguage, IDataManipulationLanguage dataManipulationLanguage, IGestorErrores gestorErrores)
            {
            _dataQueryLanguage = dataQueyLanguage;
            _dataManipulationLanguage = dataManipulationLanguage;
            _gestorErrores = gestorErrores;
            }

        public async Task<List<T>> ConsultarEmpleados<T>() where T : Empleado
            {
            try
                {
                var resultado = await _dataQueryLanguage.Consultar<T>(SQL.ConsultarEmpleado);
                return resultado;
                }
            catch (Exception ex)
                {
                throw _gestorErrores.ManejarErrorBD("consultar los empleados", ex);
                }
            }

        public async Task<int> InsertarEmpleado<T>(T parametros) where T : Empleado
            {
            try
                {
                var resultado = await _dataManipulationLanguage.EjecutarComando(SQL.InsertarEmpleado, parametros);
                return resultado;
                }
            catch (Exception ex)
                {
                throw _gestorErrores.ManejarErrorBD("insertar un empleado", ex);
                }
            }

        public async Task<int> ActualizarEmpleado<T>(T parametros) where T : Empleado
            {
            try
                {
                var resultado = await _dataManipulationLanguage.EjecutarComando(SQL.ActualizarEmpleado, parametros);
                return resultado;
                }
            catch (Exception ex)
                {
                throw _gestorErrores.ManejarErrorBD("actualizar un empleado", ex);
                }
            }

        public async Task<int> EliminarEmpleado<T>(T parametros) where T : Empleado
            {
            try
                {
                var resultado = await _dataManipulationLanguage.EjecutarComando(SQL.EliminarEmpleado, parametros);
                return resultado;
                }
            catch (Exception ex)
                {
                throw _gestorErrores.ManejarErrorBD("eliminar un empleado", ex);
                }
            }
        }
    }
