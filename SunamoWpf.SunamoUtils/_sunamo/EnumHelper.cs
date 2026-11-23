namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the enum helper type.
/// </summary>
public class EnumHelper
{
    /// <summary>
    /// Get values t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="IncludeNope">The include nope.</param>
    /// <param name="IncludeShared">The include shared.</param>
    /// <returns>The get values t result.</returns>
    public static List<T> GetValues<T>(bool IncludeNope, bool IncludeShared)
        where T : struct
    {
        var type = typeof(T);
        var values = Enum.GetValues(type).Cast<T>().ToList();
        T nope;
        if (!IncludeNope)
            if (Enum.TryParse("Nope", out nope))
                values.Remove(nope);

        if (!IncludeShared)
        {
            if (type.Name == "MySites")
            {
                if (Enum.TryParse("Shared", out nope)) values.Remove(nope);
            }
            else
            {
                if (Enum.TryParse("Sha", out nope)) values.Remove(nope);
            }
        }

        if (Enum.TryParse("None", out nope)) values.Remove(nope);

        return values;
    }

    /// <summary>
    /// Parse t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="web">The web.</param>
    /// <param name="_def">The def.</param>
    /// <param name="returnDefIfNull">The return def if null.</param>
    /// <returns>The parse t result.</returns>
    public static T Parse<T>(string web, T _def, bool returnDefIfNull = false)
       where T : struct
    {
        if (returnDefIfNull) return _def;
        T result;
        if (Enum.TryParse(web, true, out result)) return result;

        return _def;
    }
}