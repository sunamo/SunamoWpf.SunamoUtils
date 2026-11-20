namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the SH split type.
/// </summary>
public class SHSplit
{
    /// <summary>
    /// Split by white spaces.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="removeEmpty">The remove empty.</param>
    /// <returns>The split by white spaces result.</returns>
    public static List<string> SplitByWhiteSpaces(string text, bool removeEmpty = false)
    {
        WhitespaceCharService whitespaceChar = new();
        whitespaceChar.ConvertWhiteSpaceCodesToChars();

        if (whitespaceChar == null)
        {
            ThrowEx.Custom($"whitespaceChar.whiteSpaceChars is not initialized"); ;
        }

        text = text.RemoveInvisibleChars();
        List<string> result = null;
        if (removeEmpty)
        {
            //r = s.Split(AllChars.whiteSpaceChars.ToArray()).ToList();
            result = SplitChar(text, whitespaceChar.whiteSpaceChars.ToArray()).ToList();
        }
        else
            //r = s.Split(AllChars.whiteSpaceChars.ToArray(), StringSplitOptions.None).ToList();
            result = SplitNone(text, whitespaceChar.whiteSpaceChars.ConvertAll(item => item.ToString()).ToArray()).ToList();
        return result;
    }

    /// <summary>
    /// Split char.
    /// </summary>
    /// <param name="parametry">The parametry.</param>
    /// <param name="deli">The deli.</param>
    /// <returns>The split char result.</returns>
    public static List<string> SplitChar(string parametry, params char[] deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry,
            deli.ToList().ConvertAll(item => item.ToString()).ConvertAll(value => value.ToString()).ToArray());
    }

    /// <summary>
    /// Split.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="newLine">The new line.</param>
    /// <returns>The split result.</returns>
    public static List<string> Split(string text, params string[] newLine)
    {
        return text.Split(newLine, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    /// <summary>
    /// Split.
    /// </summary>
    /// <param name="stringSplitOptions">The string split options.</param>
    /// <param name="text">The text.</param>
    /// <param name="deli">The deli.</param>
    /// <returns>The split result.</returns>
    public static List<string> Split(StringSplitOptions stringSplitOptions, string text, params string[] deli)
    {
        if (deli == null || deli.Count() == 0) throw new Exception("NoDelimiterDetermined");
        //var ie = CA.OneElementCollectionToMulti(deli);
        //var deli3 = new List<string>IEnumerable2(ie);
        var result = text.Split(deli, stringSplitOptions).ToList();
        CA.Trim(result);
        if (stringSplitOptions == StringSplitOptions.RemoveEmptyEntries)
            result = result.Where(item => item.Trim() != string.Empty).ToList();

        return result;
    }

    /// <summary>
    /// Split none.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="newLine">The new line.</param>
    /// <returns>The split none result.</returns>
    public static List<string> SplitNone(string text, params string[] newLine)
    {
        return text.Split(newLine, StringSplitOptions.None).ToList();
    }
}