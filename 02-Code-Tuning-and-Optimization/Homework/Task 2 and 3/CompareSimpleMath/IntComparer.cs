using System;
using System.Diagnostics;

namespace CompareSimpleMath
{
    public class IntComparer
    {
        private static readonly Stopwatch stopWatch = Stopwatch.StartNew();

        public static TimeSpan Add()
        {
            stopWatch.Start();

            int type = default(int);

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

            int type = int.MaxValue;

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

            int type = default(int);

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

            int type = 1;
            int multiplier = 1;

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

            int type = 1;
            int divider = 1;

            for (int i = 0; i < 10000; i++)
            {
                type /= divider;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
