using System;
using System.Collections.Generic;

namespace AlttpRandomizer.Random
{
    public class SeedRandom
    {
        private int inext;
        private int inextp;
        private readonly int[] SeedArray = new int[56];

        public SeedRandom() : this(Environment.TickCount)
        {
        }

        public SeedRandom(int Seed)
        {
            int num = (Seed == -2147483648) ? 2147483647 : Math.Abs(Seed);
            int num2 = 161803398 - num;
            SeedArray[55] = num2;
            int num3 = 1;
            for (int i = 1; i < 55; i++)
            {
                int num4 = 21 * i % 55;
                SeedArray[num4] = num3;
                num3 = num2 - num3;
                if (num3 < 0)
                {
                    num3 += 2147483647;
                }
                num2 = SeedArray[num4];
            }
            for (int j = 1; j < 5; j++)
            {
                for (int k = 1; k < 56; k++)
                {
                    SeedArray[k] -= SeedArray[1 + (k + 30) % 55];
                    if (SeedArray[k] < 0)
                    {
                        SeedArray[k] += 2147483647;
                    }
                }
            }
            inext = 0;
            inextp = 21;
        }

        protected virtual double Sample()
        {
            return InternalSample() * 4.6566128752457969E-10;
        }

        private int InternalSample()
        {
            int num = inext;
            int num2 = inextp;
            if (++num >= 56)
            {
                num = 1;
            }
            if (++num2 >= 56)
            {
                num2 = 1;
            }
            int num3 = SeedArray[num] - SeedArray[num2];
            if (num3 == 2147483647)
            {
                num3--;
            }
            if (num3 < 0)
            {
                num3 += 2147483647;
            }
            SeedArray[num] = num3;
            inext = num;
            inextp = num2;
            return num3;
        }

        public virtual int Next()
        {
            return InternalSample();
        }

        private double GetSampleForLargeRange()
        {
            int num = InternalSample();
            bool flag = InternalSample() % 2 == 0;
            if (flag)
            {
                num = -num;
            }
            double num2 = num;
            num2 += 2147483646.0;
            return num2 / 4294967293.0;
        }

        public virtual int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "minValue must be less than maxValue.");
            }
            long num = maxValue - (long)minValue;
            if (num <= 2147483647L)
            {
                return (int)(Sample() * num) + minValue;
            }
            return (int)((long)(GetSampleForLargeRange() * num) + minValue);
        }

        public virtual int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue must be positive.");
            }
            return (int)(Sample() * maxValue);
        }

        public virtual double NextDouble()
        {
            return Sample();
        }

        public virtual void NextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(InternalSample() % 256);
            }
        }

        public List<T> RandomizeList<T>(List<T> list)
        {
            var startList = new List<T>();
            startList.AddRange(list);
            var retVal = new List<T>();

            while (startList.Count > 0)
            {
                var item = startList[Next(startList.Count)];
                retVal.Add(item);
                startList.Remove(item);
            }

            return retVal;
        }
    }
}
