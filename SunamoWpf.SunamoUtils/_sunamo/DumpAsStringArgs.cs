namespace SunamoWpf._sunamo;

/// <summary>
///     U��v� se v SunamoReflection+SUnamoLogger
/// </summary>
internal class DumpAsStringArgs : DumpAsStringHeaderArgsReflection
{
    internal DumpProvider d = DumpProvider.Yaml;
    internal string deli = " - ";
    internal string name = string.Empty;
    internal object o;

    /// <summary>
    ///     Good for fast comparing objects
    /// </summary>
    internal bool onlyValues;
}