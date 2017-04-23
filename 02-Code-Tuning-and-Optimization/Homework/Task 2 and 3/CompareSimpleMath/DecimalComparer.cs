using System;
using System.Diagnostics;

namespace CompareSimpleMath
{
    public class DecimalComparer
    {
        private static readonly Stopwatch stopWatch = Stopwatch.StartNew();

        public static TimeSpan Add()
        {
            stopWatch.Start();

            decimal type = default(decimal);

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

            decimal type = decimal.MaxValue;

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

            decimal type = default(decimal);

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

            decimal type = 1m;
            decimal multiplier = 1m;

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

            decimal type = 1m;
            decimal divider = 1m;

            for (int i = 0; i < 10000; i++)
            {
                type /= divider;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
