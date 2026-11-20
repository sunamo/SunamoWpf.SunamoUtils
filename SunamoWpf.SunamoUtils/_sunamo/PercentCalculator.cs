namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the percent calculator type.
/// </summary>
public class PercentCalculator
{
    /// <summary>
    /// The last.
    /// </summary>
    public double last;
    /// <summary>
    /// The one percent.
    /// </summary>
    public double onePercent;
    private double overall;
    private readonly double _hundredPercent = 100d;

    /// <summary>
    /// Initializes a new instance of the percent calculator class.
    /// </summary>
    /// <param name="overallSum">The overall sum.</param>
    public PercentCalculator(double overallSum)
    {
        if (overallSum == 0) ThrowEx.DivideByZero();
        onePercent = _hundredPercent / overallSum;
        overall = overallSum;
    }
}