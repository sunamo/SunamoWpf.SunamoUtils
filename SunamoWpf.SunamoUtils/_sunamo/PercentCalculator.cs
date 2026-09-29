namespace SunamoWpf._sunamo;

internal class PercentCalculator
{
    internal double last;
    internal double onePercent;
    private double overall;
    private readonly double _hundredPercent = 100d;

    internal PercentCalculator(double overallSum)
    {
        if (overallSum == 0) ThrowEx.DivideByZero();
        onePercent = _hundredPercent / overallSum;
        overall = overallSum;
    }
}