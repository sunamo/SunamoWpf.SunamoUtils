namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the SH format type.
/// </summary>
public class SHFormat
{
    /// <summary>
    /// Format 2.
    /// </summary>
    /// <param name="status">The status.</param>
    /// <param name="args">The args.</param>
    /// <returns>The format 2 result.</returns>
    public static string Format2(string status, params object[] args)
    {
        if (string.IsNullOrWhiteSpace(status)) return string.Empty;

        if (status.Contains('{') && !status.Contains("{0}")) return status;

        try
        {
            return string.Format(status, args);
        }
        catch (Exception exception)
        {
            ThrowEx.ExcAsArg(exception);
            return status;
        }
    }
    /// <summary>
    /// Format 4.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The args.</param>
    /// <returns>The format 4 result.</returns>
    public static string Format4(string format, params Object[] args)
    {
        return string.Format(format, args);
    }
}