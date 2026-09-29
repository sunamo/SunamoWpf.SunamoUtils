namespace SunamoWpf._sunamo;

internal class TF
{
    internal static
#if ASYNC
        async Task
#else
void
#endif
        AppendAllText(string content, string sf)
    {
#if ASYNC
        await
#endif
            File.AppendAllTextAsync(sf, content);
    }

    internal static async Task<string?> ReadAllText(string f)
    {
        return await File.ReadAllTextAsync(f);
    }

    internal static async Task WriteAllLines(string item2, List<string> l)
    {
        await File.WriteAllLinesAsync(item2, l);
    }

    internal static async Task WriteAllText(string csProj, string c)
    {
        await File.WriteAllTextAsync(csProj, c);
    }
}