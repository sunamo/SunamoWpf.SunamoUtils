namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the CA to number type.
/// </summary>
public class CAToNumber
{
    /// <summary>
    /// To number t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="parseInt">The parse int.</param>
    /// <param name="cells">The cells.</param>
    /// <param name="minValue">The min value.</param>
    /// <returns>The to number t result.</returns>
    public static List<T> ToNumber<T>(Func<string, T> parseInt, List<string> cells, T minValue)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// To number u.
    /// </summary>
    /// <typeparam name="U">The type U.</typeparam>
    /// <param name="parse">The parse.</param>
    /// <param name="items">The items.</param>
    /// <returns>The to number u result.</returns>
    public static List<int> ToNumber<U>(Func<ReadOnlySpan<byte>, NumberStyles, IFormatProvider, int> parse, IList<U> items)
    {
        throw new NotImplementedException();
    }
}