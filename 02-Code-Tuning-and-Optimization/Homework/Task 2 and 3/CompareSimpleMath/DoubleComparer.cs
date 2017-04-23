using System;
using System.Diagnostics;

namespace CompareSimpleMath
{
    public class DoubleComparer
    {
        private static readonly Stopwatch stopWatch = Stopwatch.StartNew();

        public static TimeSpan Add()
        {
            stopWatch.Start();

            double type = default(double);

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

            double type = double.MaxValue;

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

            double type = default(double);

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

            double type = 1d;
            double multiplier = 1d;

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

            double type = 1d;
            double divider = 1d;

            for (int i = 0; i < 10000; i++)
            {
                type /= divider;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
