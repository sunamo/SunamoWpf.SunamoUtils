namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the SH type.
/// </summary>
public class SH
{
    private static bool IsInFirstXCharsTheseLetters(string text, int count, params char[] letters)
    {
        for (var index = 0; index < count; index++)
            foreach (var item in letters)
                if (text[index] == item)
                    return true;
        return false;
    }

    private static string ShortForLettersCount(string text, int p_2, out bool pridatTriTecky)
    {
        pridatTriTecky = false;
        // Vše tu funguje výborně
        text = text.Trim();
        var length = text.Length;
        var jeDelsiA1 = p_2 <= length;


        if (jeDelsiA1)
        {
            if (IsInFirstXCharsTheseLetters(text, p_2, ' '))
            {
                var dexMezery = 0;
                var candidate = text; //p.Substring(p.Length - zkratitO);
                var end = candidate.Length;

                var napocitano = 0;
                for (var index = 0; index < end; index++)
                {
                    napocitano++;

                    if (candidate[index] == ' ')
                    {
                        if (napocitano >= p_2) break;

                        dexMezery = index;
                    }
                }

                candidate = candidate.Substring(0, dexMezery + 1);
                if (candidate.Trim() != "") pridatTriTecky = true;
                //d = d ;
                return candidate;
                //}
            }

            pridatTriTecky = true;
            return text.Substring(0, p_2);
        }

        return text;
    }

    /// <summary>
    /// Short for letters count.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="p_2">The p 2.</param>
    /// <returns>The short for letters count result.</returns>
    public static string ShortForLettersCount(string text, int p_2)
    {
        var pridatTriTecky = false;
        return ShortForLettersCount(text, p_2, out pridatTriTecky);
    }

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="fileFullPath">The file full path.</param>
    /// <param name="key">The key.</param>
    /// <returns>The contains result.</returns>
    public static bool Contains(string fileFullPath, string key)
    {
        return fileFullPath.Contains(key);
    }
    /// <summary>
    /// Count lines.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The count lines result.</returns>
    public static int CountLines(string text)
    {
        return Regex.Matches(text, Environment.NewLine).Count;
    }
    /// <summary>
    /// Detect newline.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The detect newline result.</returns>
    public static string DetectNewline(string text)
    {
        if (text.Contains("\r\n")) return "\r\n";
        return "\n";
    }

    /// <summary>
    /// Get last part by string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="returnFromString">The return from string.</param>
    /// <returns>The get last part by string result.</returns>
    public static string GetLastPartByString(string input, string returnFromString)
    {
        var dex = input.LastIndexOf(returnFromString);
        if (dex == -1) return input;
        var start = dex + returnFromString.Length;
        if (start < input.Length) return input.Substring(start);
        return input;
    }

    /// <summary>
    /// Get parts by location.
    /// </summary>
    /// <param name="pred">The pred.</param>
    /// <param name="rest">The rest.</param>
    /// <param name="text">The text.</param>
    /// <param name="separator">The separator.</param>
    public static void GetPartsByLocation(out string pred, out string rest, string text, char separator)
    {
        var dex = text.IndexOf(separator);
        GetPartsByLocation(out pred, out rest, text, dex);
    }

    /// <summary>
    /// Get parts by location.
    /// </summary>
    /// <param name="pred">The pred.</param>
    /// <param name="rest">The rest.</param>
    /// <param name="text">The text.</param>
    /// <param name="pozice">The pozice.</param>
    public static void GetPartsByLocation(out string pred, out string rest, string text, int pozice)
    {
        if (pozice == -1)
        {
            pred = text;
            rest = "";
        }
        else
        {
            pred = text.Substring(0, pozice);
            if (text.Length > pozice + 1)
                rest = text.Substring(pozice + 1);
            else
                rest = string.Empty;
        }
    }

    /// <summary>
    /// List to string.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The list to string result.</returns>
    public static string ListToString(object value, string delimiter = null)
    {
        if (value == null) return "(null)";

        string text;
        var valueType = value.GetType();

        if (value is IList && valueType != Types.tString && valueType != Types.tStringBuilder &&
            !(value is IList<char>))
        {
            if (delimiter == null) delimiter = Environment.NewLine;

            var enumerable = value; //CA.ToListStringIEnumerable2((IList)value);
            // I dont know why is needed SHReplace.Replace delimiterS(,) for space
            // This setting remove , before RoutedEventArgs etc.
            //CA.SHReplace.Replace(enumerable, delimiterS, "");
            text = string.Join(delimiter, enumerable);
        }
        //else if (valueType == Types.tDateTime)
        //{
        //    //DTHelperEn.ToString(
        //    text = ((DateTime)value).ToLongTimeString();
        //}
        else
        {
            text = value.ToString();
        }

        return text;
    }

    /// <summary>
    /// Postfix if not empty.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="postfix">The postfix.</param>
    /// <returns>The postfix if not empty result.</returns>
    public static string PostfixIfNotEmpty(string text, string postfix)
    {
        if (text.Length != 0)
            if (!text.EndsWith(postfix))
                return text + postfix;
        return text;
    }

    /// <summary>
    /// Prefix if not started with.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="http">The http.</param>
    /// <param name="skipWhitespaces">The skip whitespaces.</param>
    /// <returns>The prefix if not started with result.</returns>
    public static string PrefixIfNotStartedWith(string item, string http, bool skipWhitespaces = false)
    {
        string whitespaces = string.Empty;

        if (skipWhitespaces)
        {
            whitespaces = WhiteSpaceFromStart(item);
            item = item.Substring(whitespaces.Length);
        }

        if (!item.StartsWith(http))
        {
            return whitespaces + http + item;
        }

        return whitespaces + item;
    }

    /// <summary>
    /// White space from start.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The white space from start result.</returns>
    public static string WhiteSpaceFromStart(string text)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in text)
        {
            if (char.IsWhiteSpace(item))
            {
                stringBuilder.Append(item);
            }
            else
            {
                break;
            }
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Remove prefix.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="prefix">The prefix.</param>
    /// <returns>The remove prefix result.</returns>
    public static bool RemovePrefix(ref string text, string prefix)
    {
        if (text.StartsWith(prefix))
        {
            text = text.Substring(prefix.Length);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Text after.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="after">The after.</param>
    /// <returns>The text after result.</returns>
    public static string TextAfter(string item, string after)
    {
        var dex = item.IndexOf(after);
        if (dex != -1) return item.Substring(dex + after.Length);
        return string.Empty;
    }
}