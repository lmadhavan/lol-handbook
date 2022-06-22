using System.Text.RegularExpressions;

namespace LolHandbook.ViewModels
{
    public static class HtmlSanitizer
    {
        private static readonly Regex TagPattern = new Regex(@"<.*?>");

        public static string Sanitize(string html)
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
