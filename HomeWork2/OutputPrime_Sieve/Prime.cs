using System;
using System.Collections.Generic;
using System.Text;

namespace OutputPrime_Sieve
{
    class Prime
    {
        public static Queue<int> Sieve(int num)
        {
            //除0与1外，0表示是质数，1表示不是质数
            int[] allNums = new int[num + 1];
            Queue<int> prime = new Queue<int>();

            //置质数倍数为1
            for (int i = 2; i <= num; i++)
            {
                if (allNums[i] == 0)
                {
                    prime.Enqueue(i);
                    for (int j = 2; i * j <= num; j++)
                        allNums[i * j] = 1;
                }
            }

            return prime;
        }
    }
}
