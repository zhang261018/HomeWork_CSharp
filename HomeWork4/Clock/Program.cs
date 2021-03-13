using System;
using System.Threading;
namespace LittleClock
{
    class Program
    {

        static void Main(string[] args)
        {
            Clock newClock = new Clock(new DateTime(2021,3,12,10,56,55), new DateTime(2021,3,12,10,57,5));
            newClock.Start();

            //添加终止计时方法
            Console.WriteLine("按下任意键停止。");
            Console.Read();

            newClock.Stop();
        }
    }
}
