using System;
using System.Text.RegularExpressions;

namespace AlttpRandomizer.IO
{
    public class FileName
    {
        public static string Fix(string input, string seed, int complexity)
        {
            var retVal = input;

            retVal = retVal.Replace("<seed>", seed);
            retVal = retVal.Replace("<date>", DateTime.Now.ToString("yyyyMMdd"));
            retVal = retVal.Replace("<complexity>", complexity.ToString());
            retVal = Regex.Replace(retVal, "<.*>", "");

            return retVal;
        }
    }
}
