using System;

namespace List
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            for (Node<T> n = head; n != null; n = n.Next)
            {
                action(n.Data);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(random.Next(1000));
            }

            intlist.ForEach(n => Console.Write(n + "\t"));

            double min = double.MaxValue;
            double max = double.MinValue;
            double sum = 0;
            intlist.ForEach(n => {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
                sum += n;
            });
            Console.WriteLine();
            Console.WriteLine($"min={min},max={max},sum={sum}");
        }

    }
}
