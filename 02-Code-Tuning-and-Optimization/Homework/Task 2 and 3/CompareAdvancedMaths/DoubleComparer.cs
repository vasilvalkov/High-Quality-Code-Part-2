using System;
using System.Diagnostics;

namespace CompareAdvancedMaths
{
    public class DoubleComparer
    {
        private static readonly Stopwatch stopWatch = Stopwatch.StartNew();

        public static TimeSpan Sqrt()
        {
            stopWatch.Start();

            double type = double.MaxValue;

            for (int i = 0; i < 10000; i++)
            {
                Math.Sqrt(type);
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Log()
        {
            stopWatch.Start();

            double type = double.MaxValue;

            for (int i = 0; i < 10000; i++)
            {
                Math.Log(type, Math.E);
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Sinus()
        {
            stopWatch.Start();

            double type = 1d;

            for (int i = 0; i < 10000; i++)
            {
                Math.Sin(type);
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
