using System;
using System.Threading;
namespace LittleClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock newClock = new Clock(new DateTime(2021,3,12,13,42,55), new DateTime(2021,3,12,13,43,0));
            
            //创建一个新线程保持闹钟的运行
            Thread clock = new Thread(new ThreadStart(newClock.Start));
            clock.Start();

            //主线程延迟10s重置闹钟时间
            Thread.Sleep(10000);
            newClock.ResetTiming(new DateTime(2021, 3, 12, 13, 43, 10));
        }
    }
}
