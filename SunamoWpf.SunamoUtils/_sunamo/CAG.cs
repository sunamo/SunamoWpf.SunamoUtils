namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the CAG type.
/// </summary>
public class CAG
{
    /// <summary>
    /// Is equal to any element t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="element">The element.</param>
    /// <param name="list">The list.</param>
    /// <returns>The is equal to any element t result.</returns>
    public static bool IsEqualToAnyElement<T>(T element, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(element, item))
                return true;
        return false;
    }
    /// <summary>
    /// To list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="items">The items.</param>
    /// <returns>The to list t result.</returns>
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }

}