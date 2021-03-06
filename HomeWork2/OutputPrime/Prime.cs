using System;
using System.Collections.Generic;
using System.Text;

namespace OutputPrime
{
    class Prime
    {
        //1按非质数处理，返回一个存储结果的泛型队列
        public static Queue<int> AllPrimeFactor(int num)
        {
            int i = 2;
            Queue<int> allPrimeFac = new Queue<int>();

            //每到一个因子判断是否为质数并输出
            for (; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0 && JudgePrime(i))
                {
                    allPrimeFac.Enqueue(i);
                    if (JudgePrime(num / i))
                        allPrimeFac.Enqueue(num / i);
                }
            }

            return allPrimeFac;
        }

        //遍历判断是否为质数
        public static bool JudgePrime(int num)
        {
            if (num == 2)
                return true;

            //遍历到sqrt(num)前的数字，若可整除则不为质数
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
    }
}
