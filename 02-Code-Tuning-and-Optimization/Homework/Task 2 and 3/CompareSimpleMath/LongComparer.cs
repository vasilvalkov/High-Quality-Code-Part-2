using System;
using System.Diagnostics;

namespace CompareSimpleMath
{
    public class LongComparer
    {
        private static readonly Stopwatch stopWatch = Stopwatch.StartNew();

        public static TimeSpan Add()
        {
            stopWatch.Start();

            long type = default(long);

            for (int i = 0; i < 10000; i++)
            {
                type += i;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Subtract()
        {
            stopWatch.Start();

            long type = long.MaxValue;

            for (int i = 0; i < 10000; i++)
            {
                type -= i;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Increment()
        {
            stopWatch.Start();

            long type = default(long);

            for (int i = 0; i < 10000; i++)
            {
                type++;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Multiply()
        {
            stopWatch.Start();

            long type = 1L;
            long multiplier = 1L;

            for (int i = 0; i < 10000; i++)
            {
                type *= multiplier;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }

        public static TimeSpan Divide()
        {
            stopWatch.Start();

            long type = 1L;
            long divider = 1L;

            for (int i = 0; i < 10000; i++)
            {
                type /= divider;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
