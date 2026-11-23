namespace SunamoWpf._sunamo;

/// <summary>
/// Preprocessor directive helpers.
/// </summary>
public class PD
{
    static bool showMbDebug = true;
    /// <summary>
    /// The del show mb.
    /// </summary>
    public static Action<string> delShowMb = null;
    /// <summary>
    /// The write to startup log release.
    /// </summary>
    public static Action<string> WriteToStartupLogRelease;

    /// <summary>
    /// Show mb.
    /// </summary>
    /// <param name="message">The message.</param>
    public static void ShowMb(string message)
    {
        if (showMbDebug)
        {
            delShowMb(message);
        }
    }


}