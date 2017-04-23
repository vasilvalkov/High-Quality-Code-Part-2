using System;
using System.Diagnostics;

namespace CompareAdvancedMaths
{
    public class DecimalComparer
    {
        private static readonly Stopwatch stopWatch = Stopwatch.StartNew();

        public static TimeSpan Sqrt()
        {
            stopWatch.Start();

            decimal type = decimal.MaxValue;

            for (int i = 0; i < 10000; i++)
            {
                Math.Sqrt((double)type);
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Log()
        {
            stopWatch.Start();

            decimal type = decimal.MaxValue;

            for (int i = 0; i < 10000; i++)
            {
                Math.Log((double)type, Math.E);
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Sinus()
        {
            stopWatch.Start();

            decimal type = 1m;

            for (int i = 0; i < 10000; i++)
            {
                Math.Sin((double)type);
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
