using System;
using System.Diagnostics;

namespace CompareSimpleMath
{
    public class FloatComparer
    {
        private static readonly Stopwatch stopWatch = Stopwatch.StartNew();

        public static TimeSpan Add()
        {
            stopWatch.Start();

            float type = default(float);

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

            float type = float.MaxValue;

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

            float type = default(float);

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

            float type = 1f;
            float multiplier = 1f;

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

            float type = 1f;
            float divider = 1f;

            for (int i = 0; i < 10000; i++)
            {
                type /= divider;
            }

            stopWatch.Stop();

            return stopWatch.Elapsed;
        }
    }
}
