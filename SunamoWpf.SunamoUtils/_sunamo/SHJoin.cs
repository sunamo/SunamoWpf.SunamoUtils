namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the SH join type.
/// </summary>
public class SHJoin
{
    /// <summary>
    /// Join dictionary.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The join dictionary result.</returns>
    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in dictionary) stringBuilder.AppendLine(item.Key + delimiter + item.Value);
        return stringBuilder.ToString();
    }
}