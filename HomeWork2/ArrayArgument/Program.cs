using System;

namespace ArrayArgument
{
    class Program
    {
        static void Main(string[] args)
        {
            var valTuple = new ValueTuple<int, int, double, int>();

            //参数数组
            int[] newArray = { 10, -2, 3, 1, 19, 10, 1 };

            //获得答案
            valTuple = Operation.Operations(newArray);

            //输出结果
            Console.WriteLine($"maxValue:\t{valTuple.Item1}\nminValue:\t{valTuple.Item2}\n" +
                $"average:\t{valTuple.Item3}\nsum:\t{valTuple.Item4}");
        }
    }
}
