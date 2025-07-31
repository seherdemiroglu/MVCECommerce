using System.Text.RegularExpressions;

namespace MVCECommerce
{
    public static class AppExtensions// extensions classlar static olmalı
    {
        public static string ToSafeUrlString(this string text) => Regex.Replace( string.Concat(text.Where(p => char.IsWhiteSpace(p) || char.IsLetterOrDigit(p)))
            .ToLower(), @"\s+","-");
    }
}
