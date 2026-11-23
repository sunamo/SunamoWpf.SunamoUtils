namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the TF type.
/// </summary>
public class TF
{
        /// <summary>
        /// Append all text.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="path">The path.</param>
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

    /// <summary>
    /// Read all text.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The read all text result.</returns>
    public static async Task<string?> ReadAllText(string path)
    {
        return await File.ReadAllTextAsync(path);
    }

    /// <summary>
    /// Write all lines.
    /// </summary>
    /// <param name="item2">The item 2.</param>
    /// <param name="lines">The lines.</param>
    public static async Task WriteAllLines(string item2, List<string> lines)
    {
        await File.WriteAllLinesAsync(item2, lines);
    }

    /// <summary>
    /// Write all text.
    /// </summary>
    /// <param name="csProj">The cs proj.</param>
    /// <param name="content">The content.</param>
    public static async Task WriteAllText(string csProj, string content)
    {
        await File.WriteAllTextAsync(csProj, content);
    }
}