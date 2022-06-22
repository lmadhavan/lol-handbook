using System.Text.RegularExpressions;

namespace LolHandbook.ViewModels
{
    public static class HtmlSanitizer
    {
        private static readonly Regex LineBreakPattern = new Regex(@"<br ?/?>");
        private static readonly Regex TagPattern = new Regex(@"<.*?>");

        public static string Sanitize(string html)
        {
            if (html == null)
            {
                return null;
            }

            return TagPattern.Replace(LineBreakPattern.Replace(html, "\n"), "");
        }
    }
}
