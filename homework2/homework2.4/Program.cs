using System;

namespace homework2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[,]
            {
                {1,2,3,4 },
                {5,1,2,3 },
                {9,5,1,2 }
            };
            bool b = isToeplitzMatrix(a);
            Console.WriteLine(b);
           bool isToeplitzMatrix(int[,] matrix)
            {
                int n = matrix.GetLength(0);int m = matrix.GetLength(1);
                for(int i = 1; i < n; i++)
                {
                    for(int j = 1; j < m; j++)
                    {
                        if (matrix[i - 1, j - 1] != matrix[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

        }
    }
}
