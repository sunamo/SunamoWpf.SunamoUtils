namespace SunamoWpf._sunamo;

///// <summary>
///// Preprocessor directives
///// </summary>
internal class PD
{
    static bool showMbDebug = true;
    internal static Action<string> delShowMb = null;
    internal static Action<string> WriteToStartupLogRelease;

    internal static void ShowMb(string v)
    {
        if (showMbDebug)
        {
            delShowMb(v);
        }
    }


}