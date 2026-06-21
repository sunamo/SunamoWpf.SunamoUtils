namespace SunamoWpf._sunamo;

public class SHJoin
{
    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        var sb = new StringBuilder();
        foreach (var item in dictionary) sb.AppendLine(item.Key + delimiter + item.Value);
        return sb.ToString();
    }
}