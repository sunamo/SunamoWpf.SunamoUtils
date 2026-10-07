namespace SunamoWpf._sunamo;

public class CAG
{
    public static bool IsEqualToAnyElement<T>(T element, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        return false;
    }
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }

}