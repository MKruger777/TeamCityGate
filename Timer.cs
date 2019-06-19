
namespace TeamCityGate
{

    using System;
    using System.Diagnostics;

    public class Timer
    {
        private Stopwatch stopWatch = new Stopwatch();

        public void Start()
        {
            stopWatch.Start();
        }

        public string Stop()
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                 ts.Hours, ts.Minutes, ts.Seconds,
                                 ts.Milliseconds / 10);
        }

        public string Now()
        {
            return String.Format("{0:00}:{1:00}:{2:00}.{3:00}",DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second ,DateTime.Now.Millisecond / 10);
        }
    }
}