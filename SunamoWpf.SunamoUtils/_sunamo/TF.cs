namespace SunamoWpf._sunamo;

public class TF
{
    public static
#if ASYNC
        async Task
#else
void
#endif
        AppendAllText(string content, string path)
    {
#if ASYNC
        await
#endif
            File.AppendAllTextAsync(path, content);
    }

    public static async Task<string?> ReadAllText(string path)
    {
        return await File.ReadAllTextAsync(path);
    }

    public static async Task WriteAllLines(string item2, List<string> lines)
    {
        await File.WriteAllLinesAsync(item2, lines);
    }

    public static async Task WriteAllText(string csProj, string content)
    {
        await File.WriteAllTextAsync(csProj, content);
    }
}