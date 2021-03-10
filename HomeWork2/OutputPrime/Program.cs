using System;
using System.Collections.Generic;

namespace OutputPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 2;
            Queue<int> allPrimeFac = new Queue<int>();

            //输入并判断参数是否正确
            try
            {
                Console.WriteLine("Input an interger plz(>=2):");
                num = Convert.ToInt32(Console.ReadLine());
                if (num < 2)
                    throw new ArgumentOutOfRangeException("invaild number");
            }
            catch (Exception e)
            {
                Console.WriteLine("you need to input a correct number.");
            }

            allPrimeFac = Prime.AllPrimeFactor(num);
            //输出结果
            Console.WriteLine("All Prime Factor:");
            while (allPrimeFac.Count != 0)
                Console.Write($"{allPrimeFac.Dequeue()}\t");
        }
    }
}
