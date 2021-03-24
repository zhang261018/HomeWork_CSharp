using System;
using System.Collections.Generic;
using System.Timers;
using System.Text;
using System.Threading;

namespace LittleClock
{
    public class Clock
    {
        //private bool work;
        //Thread start;
        //Thread stop;

        private DateTime time;      //存储当前时间
        private DateTime timing;    //存储定时时间

        public delegate void AlarmHander();
        public event AlarmHander TimeElapse;

        //构造函数（当前时间，目标时间）
        public Clock(DateTime time, DateTime timing)
        {
            this.time = time;
            this.timing = timing;

            AlarmHander alarm = this.Tick;
            alarm += this.Alarm;

            TimeElapse += alarm;
        }

        //启动闹钟
        public void Start()
        {
            // this.work = true;
            while(true)
            {
                TimeElapse();
                Thread.Sleep(1000);
            }
        }

        //public void Stop()
        //{
        //    this.work = false;
        //}

        //重新设置时间
        public void ResetTiming(DateTime newTime)
        {
            Console.WriteLine("reset alarm time: " + newTime.ToString("yyyy-MM-dd-HH-mm-ss"));
            timing = newTime;
        }

        //Tick，Alarm
        public void Tick()
        {
            time = time.AddSeconds(1);
            Console.WriteLine("Tick!\t" + time.ToString("yyyy-MM-dd-HH-mm-ss"));
        }
        public void Alarm()
        {
            if (time.Hour == timing.Hour && time.Minute == timing.Minute && time.Second == timing.Second)
            {
                Console.WriteLine("Time is up! Time is up!");
            }
        }
    }
}
