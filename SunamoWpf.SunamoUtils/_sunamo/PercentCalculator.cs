namespace SunamoWpf._sunamo;

public class PercentCalculator
{
    public double last;
    public double onePercent;
    private double overall;
    private readonly double _hundredPercent = 100d;

    public PercentCalculator(double overallSum)
    {
        if (overallSum == 0) ThrowEx.DivideByZero();
        onePercent = _hundredPercent / overallSum;
        overall = overallSum;
    }
}