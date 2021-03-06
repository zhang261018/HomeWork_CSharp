using System;
using System.Collections.Generic;

namespace OutputPrime_Sieve
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            //保存100以内所有质数的队列
            Queue<int> primeIn100 = Prime.Sieve(100);

            //输出结果
            while (primeIn100.Count != 0)
            {
                count++;
                Console.Write($"{primeIn100.Dequeue()}" + ((count % 5 == 0) ? "\n" : "\t"));
            }
        }
    }
}
