namespace EjercicioClaseGenericaStack
    {

    class Program
        {

        public static void Main(string[] args)
            {

            MyStack<int> stack = new MyStack<int>();
            stack.Push(77);
            stack.Push(54);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Count);
            }
        }

    class MyStack<T>
        {
        private List<T> _stack;
        public int Count => _stack.Count;
        public bool IsEmpty;

        public MyStack()
            {
            _stack = new List<T>();
            }

        public void Push(T item)
            {
            _stack.Add(item);
            }

        public T Pop()
            {
            T item = _stack[Count - 1];
            _stack.RemoveAt(Count-1);
            return item;
            }
        }
    }