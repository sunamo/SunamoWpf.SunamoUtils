namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the i select from many data type.
/// </summary>
public interface ISelectFromMany<Data>
{
    /// <summary>
    /// Add control.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="value">The value.</param>
    void AddControl(Data data, bool value);
    /// <summary>
    /// Add controls.
    /// </summary>
    void AddControls();
}