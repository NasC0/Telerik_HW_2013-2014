/* 07. Using delegates write a class Timer that has can execute certain method at each t seconds. */

namespace _07.TimerClassWithDelegates
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class Timer
    {
        public delegate void MethodToExecute();

        public Timer(int milliseconds, int secondsToRun)
        {
            this.Interval = milliseconds;
            this.TimeToRun = secondsToRun;
        }

        public int Interval { get; set; }

        public int TimeToRun { get; set; }

        public MethodToExecute ExecuteMethod { get; set; }

        public void Execute()
        {
            long overallTimeToRun = this.TimeToRun * 1000;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (overallTimeToRun > sw.ElapsedMilliseconds)
            {
                this.ExecuteMethod();
                Thread.Sleep(this.Interval);
            }
        }
    }
}
