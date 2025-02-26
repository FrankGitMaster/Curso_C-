namespace ConectarBD_2.Utils.Crud.DQL
    {
    public interface IDataQueryLanguage
        {

        Task<List<T>> Consultar<T>(string query);
        }
    }