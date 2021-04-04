using System;

namespace homework2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[99] ;

            for(int i = 0; i < 99; i++)
            {
                a[i] = i + 2;
            }
            
            for(int j = 2; j < 51; j++)
            {
                for(int i = 0; i < 99; i++)
                {
                    if (a[i] != j)
                    {
                        if (a[i] % j == 0) { a[i] = 0; }
                    }
                }
            }

            for(int i = 0; i < 99; i++)
            {
                if (a[i] != 0) { Console.WriteLine("{0} ", a[i]); }
                 
            }

        }
    }
}
