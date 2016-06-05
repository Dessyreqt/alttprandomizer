using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlttpRandomizer.Net
{
    public class RandomizerVersion
    {
        public static string Current = "3";
        public static bool Debug = false;

        public static string CurrentDisplay
        {
            get
            {
                var retVal = Current;

                if (retVal.Contains("P"))
                {
                    retVal = string.Format("{0})", retVal.Replace("P", " (preview "));
                }

                return retVal;
            }
        }

        private const int checkVersion = 3;
        private static readonly string updateAddress = "http://dessyreqt.github.io/alttprandomizer/?" + DateTime.Now.Ticks;

        public static void CheckUpdate()
        {
            try
            {
                var response = GetResponse(updateAddress);

                if (string.IsNullOrWhiteSpace(response))
                    return;

                const string pattern = "Current Version: (?<version>\\S+)";
                var match = Regex.Match(response, pattern);

                if (match.Success)
                {
                    var currentVersion = match.Groups["version"].Value;
                    int currentVersionNum;

                    if (int.TryParse(currentVersion, out currentVersionNum))
                    {
                        if (checkVersion < currentVersionNum)
                        {
                            var result =
                                MessageBox.Show(
                                    string.Format(
                                        "You have v{0} and the current version is v{1}. Would you like to update?",
                                        Current,
                                        currentVersion), "Version Update", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                                Help.ShowHelp(null, updateAddress);
                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                // check for update failed, do nothing here
            }
        }

        private static string GetResponse(string address)
        {
            if (!address.Contains("dessyreqt.github.io/alttprandomizer"))
                return "";

            var webBrowser = new WebBrowser { ScrollBarsEnabled = false, ScriptErrorsSuppressed = true };
            webBrowser.Navigate(address);
            while (webBrowser.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

            return webBrowser.Document.Body.InnerHtml;
        }
    }
}
