namespace SunamoWpf._sunamo;

internal class SHGetLines
{
    internal static List<string> GetLines(string text)
    {
        var parts = text.Split(new[] { "\r\n", "\n\r" }, StringSplitOptions.None).ToList();
        SplitByUnixNewline(parts);
        return parts;
    }

    private static void SplitByUnixNewline(List<string> lines)
    {
        SplitBy(lines, "\r");
        SplitBy(lines, "\n");
    }

    private static void SplitBy(List<string> lines, string separator)
    {
        for (var index = lines.Count - 1; index >= 0; index--)
        {
            if (separator == "\r")
            {
                var windowsParts = lines[index].Split(new[] { "\r\n" }, StringSplitOptions.None);
                var oldMacParts = lines[index].Split(new[] { "\n\r" }, StringSplitOptions.None);

                if (windowsParts.Length > 1)
                    ThrowEx.Custom("cannot contain any \r\n, pass already split by this pattern");
                else if (oldMacParts.Length > 1) ThrowEx.Custom("cannot contain any \n\r, pass already split by this pattern");
            }

            var parts = lines[index].Split(new[] { separator }, StringSplitOptions.None);

            if (parts.Length > 1) InsertOnIndex(lines, parts.ToList(), index);
        }
    }

    private static void InsertOnIndex(List<string> lines, List<string> insertedLines, int index)
    {
        insertedLines.Reverse();

        lines.RemoveAt(index);

        foreach (var item in insertedLines) lines.Insert(index, item);
    }
}