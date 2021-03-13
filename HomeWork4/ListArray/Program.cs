using System;
namespace ListArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0, max = int.MinValue, min = int.MaxValue;
            GenericList<int> newList = new GenericList<int>(new int[]{ 2, 3, 6, 4, 2, 6, 2, 1, 9, 5, 3, 4, 1, 10, 7 });

            //创造委托对象action
            Action<int> action =
                x => { if (x >= max) max = x; };
            action +=
                x => { if (x <= min) min = x; };
            action +=
                x => { sum += x; };
            action += x => Console.Write($"{x} ");

            //调用实现的ForEach函数
            newList.ForEach(action);

            //输出结果
            Console.WriteLine($"\nin this array:\nthe sum of the num:{sum}\nthe MaxValue:{max}\nthe minValue:{min}");
        }
    }
}
