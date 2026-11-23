namespace SunamoWpf._sunamo;
/// <summary>
///     U��v� se v SunamoReflection+SUnamoLogger
/// </summary>
public class DumpAsStringArgs : DumpAsStringHeaderArgsReflection
{
    /// <summary>
    /// The d.
    /// </summary>
    public DumpProvider d = DumpProvider.Yaml;
    /// <summary>
    /// The deli.
    /// </summary>
    public string deli = " - ";
    /// <summary>
    /// The name.
    /// </summary>
    public string name = string.Empty;
    /// <summary>
    /// The o.
    /// </summary>
    public object o;

    /// <summary>
    ///     Good for fast comparing objects
    /// </summary>
    public bool onlyValues;
}