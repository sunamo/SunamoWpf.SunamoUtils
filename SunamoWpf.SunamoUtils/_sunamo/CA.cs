namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the CA type.
/// </summary>
public class CA
{
    /// <summary>
    /// Replace.
    /// </summary>
    /// <param name="files_in">The files in.</param>
    /// <param name="what">The what.</param>
    /// <param name="forWhat">The for what.</param>
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        for (var index = 0; index < files_in.Count; index++) files_in[index] = Replace(files_in[index], what, forWhat);
        //CAChangeContent.ChangeContent2(null, files_in, Replace, what, forWhat);
    }

    private static string Replace(string text, string from, string replacement)
    {
        return text.Replace(from, replacement);
    }

    /// <summary>
    /// Trim.
    /// </summary>
    /// <param name="items">The items.</param>
    /// <returns>The trim result.</returns>
    public static List<string> Trim(List<string> items)
    {
        for (var index = 0; index < items.Count; index++) items[index] = items[index].Trim();
        return items;
    }
    /// <summary>
    /// Init fill with.
    /// </summary>
    /// <param name="datas">The datas.</param>
    /// <param name="pocet">The pocet.</param>
    /// <param name="initWith">The init with.</param>
    public static void InitFillWith(List<string> datas, int pocet, string initWith = "")
    {
        InitFillWith<string>(datas, pocet, initWith);
    }

    /// <summary>
    /// Init fill with t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="datas">The datas.</param>
    /// <param name="pocet">The pocet.</param>
    /// <param name="initWith">The init with.</param>
    public static void InitFillWith<T>(List<T> datas, int pocet, T initWith)
    {
        for (var index = 0; index < pocet; index++) datas.Add(initWith);
    }

    /// <summary>
    /// Is all the same t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="ext">The ext.</param>
    /// <param name="items">The items.</param>
    /// <returns>The is all the same t result.</returns>
    public static bool IsAllTheSame<T>(T ext, IList<T> items)
    {
        for (var index = 0; index < items.Count; index++)
            if (!EqualityComparer<T>.Default.Equals(items[index], ext))
                return false;
        return true;
    }

    /// <summary>
    /// Remove strings empty.
    /// </summary>
    /// <param name="mySites">The my sites.</param>
    /// <returns>The remove strings empty result.</returns>
    public static List<string> RemoveStringsEmpty(List<string> mySites)
    {
        for (int index = mySites.Count - 1; index >= 0; index--)
        {
            if (mySites[index] == string.Empty)
            {
                mySites.RemoveAt(index);
            }
        }
        return mySites;
    }

    /// <summary>
    /// To bool.
    /// </summary>
    /// <param name="numbers">The numbers.</param>
    /// <returns>The to bool result.</returns>
    public static List<bool> ToBool(List<int> numbers)
    {
        var booleans = new List<bool>(numbers.Count);
        foreach (var item in numbers) booleans.Add(item == 1 ? true : false);
        return booleans;
    }

    /// <summary>
    /// To list string.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <returns>The to list string result.</returns>
    public static List<string> ToListString(params string[] values)
    {
        return values.ToList();
    }

    /// <summary>
    /// With end slash.
    /// </summary>
    /// <param name="folders">The folders.</param>
    /// <returns>The with end slash result.</returns>
    public static List<string> WithEndSlash(List<string> folders)
    {
        var list = folders;
        if (list == null) list = folders.ToList();
        for (var index = 0; index < list.Count; index++) list[index] = list[index].TrimEnd('\\') + "\\";
        return folders;
    }
}