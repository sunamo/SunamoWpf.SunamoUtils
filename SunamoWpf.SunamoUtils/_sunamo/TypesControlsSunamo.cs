namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the types controls sunamo type.
/// </summary>
public class TypesControlsSunamo
{
    /// <summary>
    /// Is initialized directly in PathEditor to avoid referencing not used assembly
    /// In default is type's object to avoid exception in waterfall type checking
    /// </summary>
    public static Type tPathEditor = typeof(Object);
    /// <summary>
    /// The check box list UC constant.
    /// </summary>
    public const string CheckBoxListUC = "SunamoWpf.Controls.Collections.CheckBoxListUC";
}