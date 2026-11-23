namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the random helper type.
/// </summary>
public class RandomHelper
{
    /// <summary>
    /// Random color part.
    /// </summary>
    /// <param name="light">The light.</param>
    /// <returns>The random color part result.</returns>
    public static byte RandomColorPart(bool light)
    {
        return RandomColorPart(light, 127f);
    }

    private static readonly Random random = new();
    private static readonly float s_lightColorBase = 256 - 229;
    private static readonly Random s_rnd = new(Guid.NewGuid().GetHashCode());

    /// <summary>
    /// Random byte.
    /// </summary>
    /// <param name="min">The min.</param>
    /// <param name="toInclude">The to include.</param>
    /// <returns>The random byte result.</returns>
    public static byte RandomByte(int min, int toInclude)
    {
        return (byte)s_rnd.Next(min, toInclude + 1);
    }

    /// <summary>
    /// Random enum t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <returns>The random enum t result.</returns>
    public static T RandomEnum<T>()
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

    /// <summary>
    /// Random float.
    /// </summary>
    /// <param name="min">The min.</param>
    /// <param name="maxP">The max p.</param>
    /// <returns>The random float result.</returns>
    public static float RandomFloat(int min, int maxP)
    {


        Random random = new Random();
        double rozsah = maxP - min;
        double nahodneDouble = random.NextDouble() * rozsah + min;
        return (float)nahodneDouble;
    }
    /// <summary>
    /// Random color part.
    /// </summary>
    /// <param name="light">The light.</param>
    /// <param name="add">The add.</param>
    /// <returns>The random color part result.</returns>
    public static byte RandomColorPart(bool light, float add)
    {
        if (light)
        {
            var randomValue = RandomFloatBetween0And1();
            randomValue *= s_lightColorBase;
            return (byte)(randomValue + add);
        }

        return RandomByte(0, 255);
    }


}