namespace Pila
    {

    class Program
        {

        public static void Main(string[] args)
            {


            Pila<int> pilaEnteros = new Pila<int>();
            pilaEnteros.Apilar(26);
            pilaEnteros.Apilar(77);
            pilaEnteros.Apilar(54);
            Console.WriteLine(pilaEnteros.Desapilar());
            Console.WriteLine(pilaEnteros.Mirar());


            }
        }

    class Pila<T>
        {

        private List<T> _pila = new List<T>();
        /*
        Propiedad Calculada (=>):
        Dinámico: El valor de Conteo siempre refleja el estado actual de _pila.Count.
        Cada vez que accedes a la propiedad, se evalúa => _pila.Count, lo que significa que cualquier cambio en la lista _pila (como agregar o quitar elementos) se reflejará automáticamente.
        No almacena un valor, solo expone el cálculo.
         */
        private int Conteo => _pila.Count;

        public T Apilar(T elemento)
            {
            _pila.Add(elemento);
            return elemento;
            }

        public T Desapilar()
            {

            if (EstaVacia())
                {
                throw new Exception("Pila vacáa");
                }
            else
                {
                T elementoEliminado = _pila[Conteo - 1];
                _pila.Remove(elementoEliminado);
                return elementoEliminado;
                }
            }

        public T Mirar()
            {
            if (EstaVacia())
                {
                throw new Exception("Pila vacía");
                }
            else
                {
                T elementoCima = _pila[Conteo - 1];
                return elementoCima;
                }
            }

        public bool EstaVacia()
            {
            return Conteo == 0;
            }
        }
    }