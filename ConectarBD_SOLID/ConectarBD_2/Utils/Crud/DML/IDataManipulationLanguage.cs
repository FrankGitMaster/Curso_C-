namespace ConectarBD_2.Utils.Crud.DML
    {
    public interface IDataManipulationLanguage
        {

        Task<int> EjecutarComando(string query, object parametros);

        }
    }
