using System.Text.RegularExpressions;

namespace LolHandbook.ViewModels
{
    internal static class HtmlSanitizer
    {
        private static readonly Regex TagPattern = new Regex(@"<.*?>");

        internal static string Sanitize(string html)
        {
            if (html == null)
            {
                return null;
            }

            html = html.Replace("<br>", "\n");
            return TagPattern.Replace(html, "");
        }
    }
}
