using System;

namespace homework2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 96, 15, 27, 70, 42, 49, 65, 56, 79, 1 };
            Max(a);
            Min(a);
            SumAve(a);
           
            static void Max(double[] a)
            {
                if (a is null)
                {
                    throw new ArgumentNullException(nameof(a));
                }

                for (int i=0;i<a.Length-1; i++)
                {
                    if (a[i] >= a[i + 1])
                    {
                        double t;
                        t = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = t;
                    }
                }
                Console.WriteLine("最大值为{0}", a[a.Length-1]);
            }

            static void Min(double[] a)
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    if (a[i] <= a[i + 1])
                    {
                        double t;
                        t = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = t;
                    }
                }
                Console.WriteLine("最小值为{0}", a[a.Length - 1]);
            }


            static void SumAve(double[] a)
            {
                double sum = 0;
                double ave = 0;
                for(int i=0; i <= a.Length - 1; i++)
                {
                    sum += a[i];
                }
                ave = sum / a.Length;
                Console.WriteLine("和为{0}，平均数为{1}",sum,ave);

            }


        }

    }
}
