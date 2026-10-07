namespace SunamoWpf._sunamo;

public static class SF
{
    public const string replaceForSeparatorString = "_";
    private static readonly SerializeContentArgs s_contentArgs = new();
    private static Type type = typeof(SF);
    public static readonly char replaceForSeparatorChar = '_';
    public static string dDeli = "|";
    static SF()
    {
        s_contentArgs.separatorString = "|";
    }
    public static string separatorString
    {
        get => s_contentArgs.separatorString;
        set => s_contentArgs.separatorString = value;
    }
    public static int keyCodeSeparator => s_contentArgs.separatorChar;
    /// <summary>
    ///     Must be property - I can forget change value on three occurences.
    /// </summary>
    public static char separatorChar => s_contentArgs.separatorChar;
    //CASH
    public static List<string> ParseUpToRequiredElementsLine(string input, int requiredCount)
    {
        var elements = GetAllElementsLine(input);
        if (elements.Count > requiredCount)
            throw new Exception($"p have {elements.Count} elements, max is {requiredCount}");
        if (elements.Count < requiredCount)
            for (var index = elements.Count - 1; index < requiredCount; index++)
                elements.Add(string.Empty);
        return elements;
    }
    public static Dictionary<T1, T2> ToDictionary<T1, T2>(List<List<string>> lines)
    {
        var keyParserObject = BTS.MethodForParse<T1>();
        var valueParserObject = BTS.MethodForParse<T2>();
        var parseKey = (Func<string, T1>)keyParserObject;
        var parseValue = (Func<string, T2>)valueParserObject;
        var dict = new Dictionary<T1, T2>();
        var key = default(T1);
        var value = default(T2);
        var whereIsNotTwoEls = new Dictionary<int, List<string>>();
        var index = -1;
        foreach (var item in lines)
        {
            index++;
            if (item.Count != 2)
            {
                whereIsNotTwoEls.Add(index, item);
                continue;
            }
            key = parseKey.Invoke(item[0]);
            value = parseValue.Invoke(item[1]);
            dict.Add(key, value);
        }
        foreach (var item in whereIsNotTwoEls)
        {
            var values = item.Value.ToList();
            values.Insert(0, item.Key.ToString());
            //DebugLogger.Instance.WriteListOneRow(l2, "-");
        }
        if (whereIsNotTwoEls.Count != 0)
        {
        }
        return dict;
    }
    /// <summary>
    ///     Without last |
    /// </summary>
    /// <param name="items"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    public static string PrepareToSerializationExplicitString(IList items, string separator = "|")
    {
        //var o3 = new List<string>(o);
        //var o2 = CA.Trim(o3);
        var result = string.Join(separator, items);
        return result;
        //return vr.Substring(0, vr.Length - p1.Length);
    }
    /// <summary>
    ///     Without last |
    ///     If need to combine string and IList, lets use CA.Join
    ///     DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="separator"></param>
    /// <param name="items"></param>
    public static string PrepareToSerializationExplicit(IList items, string separator = "|")
    {
        return PrepareToSerializationExplicitString(items, separator);
    }
    /// <summary>
    ///     In inner array is elements, in outer lines.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    //public static List<List<string>> GetAllElementsFile(string file)
    //{
    //    string firstLine = null;
    //    return GetAllElementsFile(file, ref firstLine);
    //}
    public static List<string> RemoveComments(List<string> lines)
    {
        //CA.RemoveStringsEmpty2(tf);
        lines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        // Nevím vůbec co toto má znamenat ael nedává mi to smysl
        // Příště dopsat komentář pokud budu odkomentovávat
        //if (tf.Count > 0)
        //{
        //    if (tf[0].StartsWith("#"))
        //    {
        //        return tf[0];
        //    }
        //}
        //CA.RemoveStartingWith("#", tf);
        lines = lines.Where(entry => !entry.StartsWith("#")).ToList();
        return lines;
    }
    public static List<List<string>> GetAllElementsFile(string file/*, ref string firstCommentLine*/,
        string oddelovaciZnak = "|")
    {


        var (header, rows) = GetAllElementsFileAdvanced(file, oddelovaciZnak);



        //firstCommentLine = rows.FirstOrDefault(d => d.)

        if (header.Count > 0) rows.Insert(0, header);
        return rows;
    }
    public static
#if ASYNC
        async Task
#else
    void
#endif
        Dictionary<T1, T2>(string file, Dictionary<T1, T2> artists)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in artists) stringBuilder.AppendLine(PrepareToSerialization(item.Key.ToString(), item.Value.ToString()));
#if ASYNC
        await
#endif
            File.WriteAllTextAsync(file, stringBuilder.ToString());
    }
    public static void WriteAllElementsToFile<Key, Value>(string coolPeopleShortcuts, Dictionary<Key, Value> dictionary)
    {
        var list = ListFromDictionary(dictionary);
        WriteAllElementsToFile(coolPeopleShortcuts, list).RunSynchronously();
    }
    public static async Task WriteAllElementsToFile(string VybranySouborLogu, List<List<string>> elementLines)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in elementLines) stringBuilder.AppendLine(PrepareToSerialization2(item));
        await File.WriteAllTextAsync(VybranySouborLogu, stringBuilder.ToString());
    }
    public static List<List<string>> ListFromDictionary<Key, Value>(Dictionary<Key, Value> dictionary)
    {
        var result = new List<List<string>>();
        foreach (var item in dictionary)
        {
            result.Add([item.Key.ToString(), item.Value.ToString()]);
        }
        return result;
    }
    /// <summary>
    ///     Without last |
    ///     DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="items"></param>
    /// <param name="separator"></param>
    public static string PrepareToSerialization2(IList<string> items)
    {
        return PrepareToSerializationWorker(items, true, dDeli);
    }
    ///// <summary>
    ///// Return without last
    ///// DateTime is serialize always in english format
    ///// Opposite method: DTHelperEn.ToString<>DTHelperEn.ParseDateTimeUSA
    ///// </summary>
    ///// <param name="pr"></param>
    //public static string PrepareToSerialization2(params string[] pr)
    //{
    //    var ts = new List<string>(pr);
    //    return PrepareToSerializationWorker(ts, true, separatorString);
    //}
    /// <summary>
    ///     Return without last
    ///     If need to combine string and IList, lets use CA.Join
    /// </summary>
    /// <param name="items"></param>
    public static string PrepareToSerializationExplicit2(IList<string> items, string separator = "|")
    {
        return PrepareToSerializationWorker(items, true, separator);
    }
    public static
#if ASYNC
        async Task
#else
    void
#endif
        DictionaryAppend(string path, Dictionary<int, string> toSave)
    {
        var content = await File.ReadAllTextAsync(path);
        var elementLines = ListFromDictionary(toSave);
        var dictionary = ToDictionary<int, string>(elementLines);
        var stringBuilder = new StringBuilder();
        foreach (var item in dictionary) stringBuilder.AppendLine(PrepareToSerialization(item.Key.ToString(), item.Value));
#if ASYNC
        await
#endif
            File.AppendAllTextAsync(path, stringBuilder + Environment.NewLine);
    }
    /// <param name="element"></param>
    /// <param name="line"></param>
    /// <param name="elements"></param>
    private static string GetElementAtIndex(List<List<string>> elements, int element, int line)
    {
        if (elements.Count > line)
        {
            var lineElements = elements[line];
            if (lineElements.Count > element) return lineElements[element];
        }
        return null;
    }
    public static
#if ASYNC
        async Task<List<List<string>>>
#else
 List<List<string>>
#endif
        AppendAllText(string path, string line)
    {
        var content = (await
                File.ReadAllLinesAsync(path)).ToList();
        CA.Trim(content);
        //content += Environment.NewLine + line + Environment.NewLine;
        content.Add(line);
        var result = GetAllElementsLines(content);
#if ASYNC
        await
#endif
            File.WriteAllLinesAsync(path, content);
        return result;
    }
    private static List<List<string>> GetAllElementsLines(List<string> lines)
    {
        string firstLine = null;
        return GetAllElementsLines(lines, ref firstLine);
    }
    private static List<List<string>> GetAllElementsLines(List<string> lines, ref string firstLIne)
    {
        lines = RemoveComments(lines);
        var result = new List<List<string>>();

        firstLIne = lines[0];

        foreach (var var in lines)
            if (!string.IsNullOrWhiteSpace(var))
                result.Add(GetAllElementsLine(var));
        return result;
    }
    /// <summary>
    ///     If index won't founded, return null.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="line"></param>
    public static string GetElementAtIndexFile(string file, int element, int line)
    {
        var elements = GetAllElementsFile(file);
        return GetElementAtIndex(elements, element, line);
    }
    /// <summary>
    ///     G null if first element on any lines A2 dont exists
    /// </summary>
    /// <param name="file"></param>
    /// <param name="element"></param>
    public static List<string> GetFirstWhereIsFirstElement(string file, string element)
    {
        var elementsLines = GetAllElementsFile(file);
        for (var index = 0; index < elementsLines.Count; index++)
            if (elementsLines[index][0] == element)
                return elementsLines[index];
        return null;
    }
    /// <summary>
    ///     G null if first element on any lines A2 dont exists
    /// </summary>
    /// <param name="file"></param>
    /// <param name="element"></param>
    public static List<string> GetLastWhereIsFirstElement(string file, string element)
    {
        var elementsLines = GetAllElementsFile(file);
        for (var index = elementsLines.Count - 1; index >= 0; index--)
            if (elementsLines[index][0] == element)
                return elementsLines[index];
        return null;
    }
    /// <summary>
    ///     Read text with first delimitech which automatically delimite
    /// </summary>
    /// <param name="fileNameOrPath"></param>
    public static void ReadFileOfSettingsOther(string fileNameOrPath, Func<string, string> appDataCiReadFileOfSettingsOther)
    {
        // COmmented, app data not should be in *.web. pass directly as arg
        List<string> lines = null;
        lines = SHGetLines.GetLines(appDataCiReadFileOfSettingsOther(fileNameOrPath));
        if (lines.Count > 1)
        {
            int delimiterInt;
            if (int.TryParse(lines[0], out delimiterInt)) separatorString = ((char)delimiterInt).ToString();
        }
    }
    public static async Task WriteAllElementsToFile(string VybranySouborLogu, List<string>[] elementLines)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in elementLines) stringBuilder.AppendLine(PrepareToSerialization2(item));
        await File.WriteAllTextAsync(VybranySouborLogu, stringBuilder.ToString());
    }
    /// <summary>
    ///     Without last |
    ///     DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="items"></param>
    public static string PrepareToSerialization(params string[] items)
    {
        return PrepareToSerializationWorker(items.ToList(), true, dDeli);
    }
    ///// <summary>
    ///// Return without last
    ///// DateTime is serialize always in english format
    ///// Opposite method: DTHelperEn.ToString<>DTHelperEn.ParseDateTimeUSA
    ///// </summary>
    ///// <param name="pr"></param>
    //public static string PrepareToSerialization2(params string[] pr)
    //{
    //    var ts = new List<string>(pr);
    //    return PrepareToSerializationWorker(ts, true, separatorString);
    //}
    /// <summary>
    ///     DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="items"></param>
    /// <param name="removeLast"></param>
    /// <param name="separator"></param>
    private static string PrepareToSerializationWorker(IList<string> items, bool removeLast, string separator)
    {
        var list = items.ToList();
        if (separator == replaceForSeparatorString)
            throw new Exception("replaceForSeparatorString is the same as separator");
        CA.Replace(list, separator, replaceForSeparatorString);
        CA.Replace(list, Environment.NewLine, "");
        CA.Trim(list);
        var result = string.Join(separator, list);
        if (removeLast)
            if (result.Length > 0)
                return result.Substring(0, result.Length - 1);
        return result;
    }
    /// <summary>
    ///     Get all elements from A1
    ///     A2 byl object ale dal jsem ho jako string
    ///     nemůžu to dávat jako object protože SHSplit.Split musí být typový. Např. když mám allWhiteChars který je List
    ///     <object> a po přenesení do params string[] mi vytvoří new string[]{}
    /// </summary>
    /// <param name="var"></param>
    public static List<string> GetAllElementsLine(string var, string oddelovaciZnak = null)
    {
        if (oddelovaciZnak == null) oddelovaciZnak = "|";
        // Musí tu být none, protože pak když někde nic nebylo, tak mi to je nevrátilo a progran vyhodil IndexOutOfRangeException
        return SHSplit.Split(var, oddelovaciZnak);
    }
    /// <summary>
    ///     In result A1 is not
    /// </summary>
    /// <param name="file"></param>
    /// <param name="hlavicka"></param>
    /// <param name="oddelovaciZnak"></param>
    public static (List<string> header, List<List<string>> rows)
        GetAllElementsFileAdvanced(string file,
            string oddelovaciZnak = "|")
    {
        if (oddelovaciZnak == null) oddelovaciZnak = "|";
        var hlavicka = new List<string>();
        var separator = oddelovaciZnak;
        var result = new List<List<string>>();
        // Sync protože mám v deklaraci out
        var lines = File.ReadAllLines(file).ToList();
        CA.Trim(lines);
        if (lines.Count > 0)
        {
            hlavicka = GetAllElementsLine(lines[0], oddelovaciZnak);
            var musiByt = lines[0].Split(new[] { separator }, StringSplitOptions.None).Length - 1;
            //int nalezeno = 0;
            var jedenRadek = new StringBuilder();
            for (var index = 1; index < lines.Count; index++)
            {
                if (lines[index].Trim().Length == 0) continue;
                //nalezeno += SH.OccurencesOfStringIn(lines[i], oz);
                jedenRadek.AppendLine(lines[index]);
                //if (nalezeno == musiByt)
                //{
                //nalezeno = 0;
                var columns = GetAllElementsLine(jedenRadek.ToString(), oddelovaciZnak);
                CA.Trim(columns);
                jedenRadek.Clear();
                result.Add(columns);
                //}
            }
        }
        return (hlavicka, result);
    }
}