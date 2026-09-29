namespace SunamoWpf._sunamo;

internal class RandomHelper
{
    internal static byte RandomColorPart(bool light)
    {
        return RandomColorPart(light, 127f);
    }

    private static readonly Random random = new();
    private static readonly float s_lightColorBase = 256 - 229;
    private static readonly Random s_rnd = new(Guid.NewGuid().GetHashCode());

    internal static byte RandomByte(int od, int toInclude)
    {
        return (byte)s_rnd.Next(od, toInclude + 1);
    }

    internal static T RandomEnum<T>()
    {
        Array values = Enum.GetValues(typeof(T));
        Random random = new Random();
        T randomEnum = (T)values.GetValue(random.Next(values.Length));
        return randomEnum;
    }

    private static float RandomFloatBetween0And1()
    {
        return RandomFloat(1, 0);
    }

    internal static float RandomFloat(int p, int maxP)
    {


        Random random = new Random();
        double rozsah = maxP - p;
        double nahodneDouble = random.NextDouble() * rozsah + p;
        return (float)nahodneDouble;
    }
    internal static byte RandomColorPart(bool light, float add)
    {
        if (light)
        {
            var r = RandomFloatBetween0And1();
            r *= s_lightColorBase;
            return (byte)(r + add);
        }

        return RandomByte(0, 255);
    }


}