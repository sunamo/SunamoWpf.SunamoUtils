namespace SunamoWpf._sunamo;

internal class CharHelper
{
    internal static string OnlyDigits(string text)
    {
        return OnlyAccepted(text, char.IsDigit);
    }
    internal static string OnlyAccepted(string text, Func<char, bool> isDigit, bool not = false)
    {
        var stringBuilder = new StringBuilder();
        var result = false;
        foreach (var item in text)
        {
            result = isDigit.Invoke(item);
            if (not) result = !result;
            if (result) stringBuilder.Append(item);
        }
        return stringBuilder.ToString();
    }
}