namespace Repositorio
{
    class Repositorio<T>
    {

        private List<T> _lista;
        public Repositorio()
        {
            _lista = new List<T>();
        }

        public void agregarElemento(T elemento) => _lista.Add(elemento);

        /*public void eliminarElemento(T elemento)
        {
            foreach (T e in _lista)
            {
                if (e.Equals(elemento))
                {
                    _lista.Remove(elemento);
                    break;
                }
            }
        }*/

        public void eliminarElemento(T elemento)
        {
            // _lista.Remove(elemento) devuelve false o true, no una excepción 
            bool eliminado = _lista.Remove(elemento);
            if (!eliminado)
            {
                Console.WriteLine("El elemento no fue encontrado en la lista.");
            }
        }

        public T obtenerElemento(int indice)
        {
            if (indice < 0 || indice >= _lista.Count)
            {
                throw new ArgumentOutOfRangeException("El índice está fuera del rango.");
            }
            return _lista[indice];
        }

        public List<T> obtenerTodos()
        {
            return _lista;
        }
    }
}