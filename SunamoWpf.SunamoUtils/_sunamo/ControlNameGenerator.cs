namespace SunamoWpf._sunamo;

internal static class ControlNameGenerator
{
    private static Dictionary<Type, uint> s_actual = new Dictionary<Type, uint>();

    internal static string GetSeries(Type type)
    {
        if (s_actual.ContainsKey(type))
        {
            return type.Name + (++s_actual[type]).ToString();
        }

        s_actual.Add(type, 0);
        var name = type.Name + "0";
        return name;
    }
}