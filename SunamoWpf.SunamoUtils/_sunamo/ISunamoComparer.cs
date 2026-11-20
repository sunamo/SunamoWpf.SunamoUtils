namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the i sunamo comparer t type.
/// </summary>
public interface ISunamoComparer<T>
{
    /// <summary>
    /// Desc.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>The desc result.</returns>
    int Desc(T x, T y);
    /// <summary>
    /// Asc.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>The asc result.</returns>
    int Asc(T x, T y);
}