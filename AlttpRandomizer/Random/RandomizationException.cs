using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
