using System;
using System.Collections.Generic;
using System.Text;

namespace OutputPrime
{
    class Prime
    {
        //可以再次改进，在for循环中不再处理已经处理过的i的倍数
        public static Queue<int> AllPrimeFactor(int num)
        {
            Queue<int> allPrimeFac = new Queue<int>();

            //在处理了i之后一定不会出现num依旧是num倍数的情况，从而跳过了所有的非质数i的情况
            for (int i = 2; i * i <= num;i++)
            {   
                while (num % i == 0)
                {
                    if (!allPrimeFac.Contains(i))
                        allPrimeFac.Enqueue(i);
                    num /= i;
                }
            }
            //防止漏掉本身最后剩余一个质数的情况
            if (num >= 2)
                allPrimeFac.Enqueue(num);

            return allPrimeFac;
        }
    }
}
