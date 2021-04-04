using System;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数：");
            int n1,n2=0;
            int i=2;
            n1 = int.Parse(Console.ReadLine());
            n2 = (int)System.Math.Sqrt(n1);
            Console.WriteLine("它的素数因子有：");
            for (; i <= n2; i++)
            {
                while (n1 % i == 0)
                {
                    Console.WriteLine("{0} ", i);
                    n1 /= i;
                }
            }
            if (n1 >= i)
                Console.WriteLine("{0} ", n1);
        }
    }
}
