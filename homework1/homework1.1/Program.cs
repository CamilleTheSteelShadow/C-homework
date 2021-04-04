using System;

namespace homework1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个整数：");
            string num1 = Console.ReadLine();
            int a = int.Parse(num1);
            Console.WriteLine("请输入第二个整数；");
            string num2 = Console.ReadLine();
            int b = int.Parse(num2);
            Console.WriteLine("请选择运算符：+，-，*，/，%");
            string fun = Console.ReadLine();
            GetResult(fun,a,b);
        }

        static void GetResult(string fun,int a,int b)
        {
            int result = 0;
            switch (fun)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
                case "%":
                    result = a % b;
                    break;
                default:
                    Console.WriteLine("符号输入有误，请重新输入");
                    string str = Console.ReadLine();
                    GetResult(str, a, b);
                    return;

            }
            Console.WriteLine($"结果:{result}");
        }
    }
}
