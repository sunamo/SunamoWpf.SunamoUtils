namespace SunamoWpf._sunamo;

internal class CAG
{
    internal static bool IsEqualToAnyElement<T>(T p, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(p, item))
                return true;
        return false;
    }
    internal static List<T> ToList<T>(params T[] t)
    {
        return t.ToList();
    }

}