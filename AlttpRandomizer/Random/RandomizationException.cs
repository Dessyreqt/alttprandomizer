using System;

namespace AlttpRandomizer.Random
{
    public class RandomizationException : Exception
    {
        public RandomizationException(string message) : base(message)
        {
        }

        public RandomizationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
