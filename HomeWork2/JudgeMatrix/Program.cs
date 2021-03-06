using System;

namespace JudgeMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用二维数组而非交错数组
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };

            //输出结果
            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                for (int j = 0; j < matrix.GetLength(1);j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("is a Toeplitz matrix ?   " + Judge.JudgeToeplitz(matrix).ToString());
        }
    }
}
