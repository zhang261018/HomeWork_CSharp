using System;
using System.Collections.Generic;
using System.Timers;
using System.Text;

namespace LittleClock
{
    class Clock
    {
        private DateTime time;      //存储当前时间
        private DateTime timing;    //存储目标时间
        private Timer timers;       //计时器

        //构造函数（当前时间，目标时间）
        public Clock(DateTime time, DateTime timing)
        {
            this.time = time;
            this.timing = timing;
            timers = new Timer(1000);            
        }
        //启动闹钟
        public void Start()
        {
            timers.Enabled = true;
            timers.AutoReset = true;
            timers.Elapsed += Tick;
            timers.Elapsed += Alarm;
        }
        public void Stop()
        {
            timers.Enabled = false;
        }
        //Tick，Alarm
        public void Tick(object sender, ElapsedEventArgs s)
        {
            time = time.AddSeconds(1);
            Console.WriteLine("Tick!");
        }
        public void Alarm(object sender, ElapsedEventArgs s)
        {
            if (time.Hour == timing.Hour && time.Minute == timing.Minute && time.Second == timing.Second)
            {
                Console.WriteLine("Time is up! Time is up!");
            }
        }
    }
}
