namespace SunamoWpf._sunamo;

internal class NH
{
    internal static List<T> Sort<T>(params T[] items)
    {
        var sorted = new List<T>(items);
        sorted.Sort();
        return sorted;
    }
}