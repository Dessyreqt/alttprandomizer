using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
