using System;
using System.Text.RegularExpressions;

namespace AlttpRandomizer.IO
{
    public class FileName
    {
        public static string Fix(string input, string seed)
        {
            var retVal = input;

            retVal = retVal.Replace("<seed>", seed);
            retVal = retVal.Replace("<date>", DateTime.Now.ToString("yyyyMMdd"));
            retVal = Regex.Replace(retVal, "<.*>", "");

            return retVal;
        }
    }
}
