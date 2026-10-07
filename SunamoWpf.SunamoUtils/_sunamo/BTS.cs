namespace SunamoWpf._sunamo;

public class BTS
{
    //        #region  from BTSShared64.cs
    public static int lastInt = -1;
    public static long lastLong = -1;
    public static float lastFloat = -1;
    public static double lastDouble = -1;
    private static Type type = typeof(BTS);
    public static byte lastByte = 255;
    public static bool lastBool;
    public static DateTime lastDateTime = DateTime.MinValue;
    ///// <summary>
    /////     Usage: Usage: Exceptions.ArrayElementContainsUnallowedStrings->SH.ContainsAny
    ///// <typeparam name="T"></typeparam>
    ///// <param name="c"></param>
    ///// <param name="isChar"></param>
    ///// <returns></returns>
    //public static T CastToByT<T>(string c, bool isChar)
    //{
    //    return isChar ? (T)(dynamic)c.First() : (T)(dynamic)c;
    //}
    public static string Replace(ref string text, bool replaceCommaForDot)
    {
        if (replaceCommaForDot) text = text.Replace(",", ".");
        return text;
    }
    public static bool IsFloat(string text, bool replace = false)
    {
        if (text == null) return false;
        Replace(ref text, replace);
        return float.TryParse(text.Replace(",", "."), out lastFloat);
    }
    public static bool IsDouble(string text, bool replace = false)
    {
        if (text == null) return false;
        Replace(ref text, replace);
        return double.TryParse(text.Replace(",", "."), out lastDouble);
    }
    /// <summary>
    ///     Usage: Exceptions.IsInt
    /// </summary>
    /// <param name="text"></param>
    /// <param name="excIfIsFloat"></param>
    /// <param name="replaceCommaForDot"></param>
    /// <returns></returns>
    public static bool IsInt(string text, bool excIfIsFloat = false, bool replaceCommaForDot = false)
    {
        if (text == null) return false;
        text = text.Replace(" ", "");
        Replace(ref text, replaceCommaForDot);
        var result = int.TryParse(text, out lastInt);
        if (!result)
            if (IsFloat(text))
                if (excIfIsFloat)
                    throw new Exception(text + " is float but is calling IsInt");
        return result;
    }
    public static bool IsLong(string text, bool excIfIsDouble = false, bool replaceCommaForDot = false)
    {
        if (text == null) return false;
        text = text.Replace(" ", ""); //SHReplace.ReplaceAll4(, "", " ");
        Replace(ref text, replaceCommaForDot);
        var result = long.TryParse(text, out lastLong);
        if (!result)
            if (IsDouble(text))
                if (excIfIsDouble)
                    throw new Exception(text + " is float but is calling IsInt");
        return result;
    }
    //        #endregion
    public static int FromHex(string hexValue)
    {
        return int.Parse(hexValue, NumberStyles.HexNumber);
    }
    public static Stream StreamFromString(string text)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(text);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
    public static string StringFromStream(Stream stream)
    {
        var reader = new StreamReader(stream);
        var text = reader.ReadToEnd();
        return text;
    }
    #region Parse*
    public static bool TryParseBool(string trim)
    {
        return bool.TryParse(trim, out lastBool);
    }
    #endregion
    /// <summary>
    ///     Check for null in A2
    /// </summary>
    /// <param name="tag2"></param>
    /// <param name="tag"></param>
    public static bool CompareAsObjectAndString(object tag2, object tag)
    {
        var same = false;
        if (tag2 != null)
        {
            if (tag == tag2)
                same = true;
            else if (tag.ToString() == tag2.ToString()) same = true;
        }
        return same;
    }
    /// <summary>
    ///     G zda  prvky A2 - Ax jsou hodnoty A1.
    /// </summary>
    /// <param name="hodnota"></param>
    /// <param name="paramy"></param>
    public static bool IsAllEquals(bool hodnota, params bool[] paramy)
    {
        for (var index = 0; index < paramy.Length; index++)
            if (hodnota != paramy[index])
                return false;
        return true;
    }
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="value"></param>
    public static bool IsInRange(int min, int max, int value)
    {
        if (value == 100)
        {
        }
        // Zde jsem měl opačně znaménka, teď už by to mělo být správně
        return min <= value && max >= value;
    }
    public static bool Is(bool binFp, bool value)
    {
        if (value) return !binFp;
        return binFp;
    }
    public static List<string> GetOnlyNonNullValues(params string[] args)
    {
        var result = new List<string>();
        for (var index = 0; index < args.Length; index++)
        {
            var text = args[index];
            object hodnota = args[++index];
            if (hodnota != null)
            {
                result.Add(text);
                result.Add(hodnota.ToString());
            }
        }
        return result;
    }
    #region Get*ValueForType
    public static object GetMaxValueForType(Type type)
    {
        if (type == typeof(byte))
            return byte.MaxValue;
        if (type == typeof(decimal))
            return decimal.MaxValue;
        if (type == typeof(double))
            return double.MaxValue;
        if (type == typeof(short))
            return short.MaxValue;
        if (type == typeof(int))
            return int.MaxValue;
        if (type == typeof(long))
            return long.MaxValue;
        if (type == typeof(float))
            return float.MaxValue;
        if (type == typeof(sbyte))
            return sbyte.MaxValue;
        if (type == typeof(ushort))
            return ushort.MaxValue;
        if (type == typeof(uint))
            return uint.MaxValue;
        if (type == typeof(ulong)) return ulong.MaxValue;
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMaxValueForType");
    }
    #endregion
    public static List<byte> ClearEndingsBytes(List<byte> plainTextBytes)
    {
        var bytes = new List<byte>();
        var pridavat = false;
        for (var index = plainTextBytes.Count - 1; index >= 0; index--)
            if (!pridavat && plainTextBytes[index] != 0)
            {
                pridavat = true;
                var pridat = plainTextBytes[index];
                bytes.Insert(0, pridat);
            }
            else if (pridavat)
            {
                var pridat = plainTextBytes[index];
                bytes.Insert(0, pridat);
            }
        if (bytes.Count == 0)
        {
            for (var position = 0; position < plainTextBytes.Count; position++) plainTextBytes[position] = 0;
            return plainTextBytes;
        }
        return bytes;
    }
    public static int? ParseIntNull(string text)
    {
        if (int.TryParse(text, out lastInt)) return lastInt;
        return null;
    }
    public static string ToString<T>(T value)
    {
        return value.ToString();
    }
    /// <summary>
    ///     return Func<string, T1> or null
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <returns></returns>
    public static object MethodForParse<T1>()
    {
        var type = typeof(T1);
        #region Same seria as in DefaultValueForTypeT
        #region MyRegion
        if (type == Types.tString) return new Func<string, string>(ToString);
        if (type == Types.tBool) return new Func<string, bool>(bool.Parse);
        #endregion
        #region Signed numbers
        if (type == Types.tFloat) return new Func<string, float>(float.Parse);
        if (type == Types.tDouble) return new Func<string, double>(double.Parse);
        if (type == typeof(int)) return new Func<string, int>(int.Parse);
        if (type == Types.tLong) return new Func<string, long>(long.Parse);
        if (type == Types.tShort) return new Func<string, short>(short.Parse);
        if (type == Types.tDecimal) return new Func<string, decimal>(decimal.Parse);
        if (type == Types.tSbyte) return new Func<string, sbyte>(sbyte.Parse);
        #endregion
        #region Unsigned numbers
        if (type == Types.tByte) return new Func<string, byte>(byte.Parse);
        if (type == Types.tUshort) return new Func<string, ushort>(ushort.Parse);
        if (type == Types.tUint) return new Func<string, uint>(uint.Parse);
        if (type == Types.tUlong) return new Func<string, ulong>(ulong.Parse);
        #endregion
        if (type == Types.tDateTime) return new Func<string, DateTime>(DateTime.Parse);
        if (type == Types.tGuid) return new Func<string, Guid>(Guid.Parse);
        if (type == Types.tChar) return new Func<string, char>(text => text[0]);
        #endregion
        return null;
    }
    public static bool IsDateTime(string text)
    {
        if (text == null) return false;
        return DateTime.TryParse(text, out lastDateTime);
    }
    /// <summary>
    ///     POkud bude A1 nevyparsovatelné, vrátí int.MinValue
    ///     Replace spaces
    /// </summary>
    /// <param name="entry"></param>
    public static int ParseInt(string entry)
    {
        var lastInt2 = 0;
        if (int.TryParse(entry.Replace(" ", string.Empty), out lastInt2)) return lastInt2;
        return int.MinValue;
    }
    public static bool IsBool(string trim)
    {
        if (trim == null) return false;
        return bool.TryParse(trim, out lastBool);
    }
    public static byte ParseByte(string entry)
    {
        byte lastInt2 = 0;
        if (byte.TryParse(entry, out lastInt2)) return lastInt2;
        return byte.MinValue;
    }
    public static short ParseShort(string entry)
    {
        return ParseShort(entry, short.MinValue);
    }
    public static short ParseShort(string entry, short defVal)
    {
        short lastInt2 = 0;
        if (short.TryParse(entry, out lastInt2)) return lastInt2;
        return defVal;
    }
    public static int? ParseInt(string entry, int? _default)
    {
        var lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2)) return lastInt2;
        return _default;
    }
    public static string BoolToStringEn(bool value, bool lower = false)
    {
        string result = null;
        if (value)
            result = "Yes";
        else
            result = "No";
        if (lower)
        {
            return result.ToLower();
        }
        return result;
    }
    public static object GetMinValueForType(Type idt)
    {
        if (idt == typeof(byte))
            return 1;
        if (idt == typeof(short))
            return short.MinValue;
        if (idt == typeof(int))
            return int.MinValue;
        if (idt == typeof(long))
            return long.MinValue;
        if (idt == typeof(sbyte))
            return sbyte.MinValue;
        if (idt == typeof(ushort))
            return ushort.MinValue;
        if (idt == typeof(uint))
            return uint.MinValue;
        if (idt == typeof(ulong)) return ulong.MinValue;
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMinValueForType");
    }
    /// <summary>
    ///     If has value true, return true. Otherwise return false
    /// </summary>
    /// <param name="value"></param>
    public static bool GetValueOfNullable(bool? value)
    {
        if (value.HasValue) return value.Value;
        return false;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool value, bool really)
    {
        if (really) return !value;
        return value;
    }
    #region For easy copy from BTSShared64.cs
    public static T CastToByT<T>(string text, bool isChar)
    {
        if (isChar)
            return (T)(dynamic)text.First();
        return (T)(dynamic)text;
    }
    //private static string Replace(ref string id, bool replace)
    //{
    //    return se.BTS.Replace(ref id, replace);
    //}
    //public static bool IsFloat(string id, bool replace = false)
    //{
    //    return se.BTS.IsFloat(id, replace);
    //}
    //public static bool IsInt(string id, bool excIfIsFloat = false, bool replace = false)
    //{
    //    return se.BTS.IsInt(id, excIfIsFloat, replace);
    //}
    #endregion
    #region TryParse*
    /// <summary>
    ///     For parsing from serialized file use DTHelperEn
    /// </summary>
    /// <param name="text"></param>
    /// <param name="ciForParse"></param>
    /// <param name="defaultValue"></param>
    public static DateTime TryParseDateTime(string text, CultureInfo ciForParse, DateTime defaultValue)
    {
        var result = defaultValue;
        if (DateTime.TryParse(text, ciForParse, DateTimeStyles.None, out result)) return result;
        return defaultValue;
    }
    public static uint lastUint;
    public static bool TryParseUint(string entry)
    {
        // Pokud bude A1 null, výsledek bude false
        return uint.TryParse(entry, out lastUint);
    }
    public static bool TryParseDateTime(string entry)
    {
        if (DateTime.TryParse(entry, out lastDateTime)) return true;
        return false;
    }
    public static byte TryParseByte(string text, byte _def)
    {
        var result = _def;
        if (byte.TryParse(text, out result)) return result;
        return _def;
    }
    /// <summary>
    ///     Vrací vyparsovanou hodnotu pokud se podaří vyparsovat, jinak A2
    /// </summary>
    /// <param name="text"></param>
    /// <param name="_default"></param>
    public static bool TryParseBool(string text, bool _default)
    {
        var result = _default;
        if (bool.TryParse(text, out result)) return result;
        return _default;
    }
    public static int TryParseIntCheckNull(string entry, int def)
    {
        var lastInt = 0;
        if (entry == null) return lastInt;
        if (int.TryParse(entry, out lastInt)) return lastInt;
        return def;
    }
    public static int TryParseInt(string entry, int def)
    {
        return TryParseInt(entry, def, false);
    }
    public static int TryParseInt(string entry, int def, bool throwEx)
    {
        var lastInt = 0;
        if (int.TryParse(entry, out lastInt)) return lastInt;
        if (throwEx) ThrowEx.NotInt(entry, null);
        return def;
    }
    #endregion
    #region int <> bool
    public static int BoolToInt(bool value)
    {
        return Convert.ToInt32(value);
    }
    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name="value"></param>
    public static bool IntToBool(int value)
    {
        return Convert.ToBoolean(value);
    }
    #endregion
    #region Parse*
    public static float ParseFloat(string ratingS)
    {
        var result = float.MinValue;
        ratingS = ratingS.Replace(',', '.');
        if (float.TryParse(ratingS, out result)) return result;
        return result;
    }
    /// <summary>
    ///     Vrátí false v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name="displayAnchors"></param>
    public static bool ParseBool(string displayAnchors)
    {
        var result = false;
        if (bool.TryParse(displayAnchors, out result)) return result;
        return false;
    }
    /// <summary>
    ///     Vrátí A2 v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name="displayAnchors"></param>
    public static bool ParseBool(string displayAnchors, bool def)
    {
        var result = false;
        if (bool.TryParse(displayAnchors, out result)) return result;
        return def;
    }
    public static int ParseInt(string entry, bool mustBeAllNumbers)
    {
        int parsed;
        if (!int.TryParse(entry, out parsed))
            if (mustBeAllNumbers)
                return int.MinValue;
        return parsed;
    }
    public static double ParseDouble(string entry, double _default)
    {
        //entry = SH.FromSpace160To32(entry);
        entry = entry.Replace(" ", string.Empty);
        //var ch = entry[3];
        double lastDouble2 = 0;
        if (double.TryParse(entry, out lastDouble2)) return lastDouble2;
        return _default;
    }
    public static int ParseInt(string entry, int _default)
    {
        //entry = SH.FromSpace160To32(entry);
        entry = entry.Replace(" ", string.Empty);
        //var ch = entry[3];
        var lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2)) return lastInt2;
        return _default;
    }
    public static byte ParseByte(string entry, byte def)
    {
        byte lastInt2 = 0;
        if (byte.TryParse(entry, out lastInt2)) return lastInt2;
        return def;
    }
    #endregion
    #region Is*
    public static bool IsByte(string text)
    {
        if (text == null) return false;
        return byte.TryParse(text, out lastByte);
    }
    public static bool IsByte(string text, out byte parsedByte)
    {
        if (text == null)
        {
            parsedByte = 0;
            return false;
        }
        //byte b2 = 0;
        var result = byte.TryParse(text, out parsedByte);
        //b = b2;
        return result;
    }
    #endregion
    #region *To*
    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name="value"></param>
    public static bool IntToBool(object value)
    {
        var text = value.ToString().Trim();
        if (text == string.Empty) return false;
        return Convert.ToBoolean(int.Parse(text));
    }
    private const string Yes = "Yes";
    private const string No = "No";
    private const string Ano = "Ano";
    private const string Ne = "Ne";
    private const string One = "1";
    private const string Zero = "0";
    /// <summary>
    ///     G bool repr. A1. Pro Yes true, JF.
    /// </summary>
    /// <param name="text"></param>
    public static bool StringToBool(string text)
    {
        if (text == Yes || text == bool.TrueString || text == One || text == Ano) return true;
        return false;
    }
    /// <summary>
    ///     G str rep. pro A1 - Ano/Ne
    /// </summary>
    /// <param name="v"></param>
    public static string BoolToString(bool value)
    {
        if (value) return Ano;
        return Ne;
    }

    #endregion
    #region byte[] <> string
    public static List<byte> ConvertFromUtf8ToBytes(string vstup)
    {
        return Encoding.UTF8.GetBytes(vstup).ToList();
    }
    public static string ConvertFromBytesToUtf8(List<byte> bajty)
    {
        //NH.RemoveEndingZeroPadding(bajty);
        return Encoding.UTF8.GetString(bajty.ToArray());
    }
    public static bool FalseOrNull(object get)
    {
        return get == null || get.ToString() == false.ToString();
    }
    #endregion
    #region Casting between array - cant commented because it wasnt visible between
    public static List<string> CastArrayObjectToString(object[] args)
    {
        var result = new List<string>(args.Length);
        //CA.InitFillWith(vr, args.Length);
        for (var index = 0; index < args.Length; index++) result[index] = args[index].ToString();
        return result;
    }
    public static List<string> CastArrayIntToString(int[] args)
    {
        var result = new List<string>(args.Length);
        for (var index = 0; index < args.Length; index++) result[index] = args[index].ToString();
        return result;
    }
    #endregion
    #region Castint to Array - commented, its in used only List
    //public static int[] CastArrayStringToInt(List<string> plemena)
    //    {
    //        int[] vr = new int[plemena.Length];
    //        for (int i = 0; i < plemena.Length; i++)
    //        {
    //            vr[i] = int.Parse(plemena[i]);
    //        }
    //        return vr;
    //    }
    //    public static short[] CastArrayStringToShort(List<string> plemena)
    //    {
    //        short[] vr = new short[plemena.Count];
    //        for (int i = 0; i < plemena.Count; i++)
    //        {
    //            vr[i] = short.Parse(plemena[i]);
    //        }
    //        return vr;
    //    }
    //    public static List<string> CastArrayObjectToString(string[] args)
    //    {
    //        List<string> vr = new string[args.Length];
    //        for (int i = 0; i < args.Length; i++)
    //        {
    //            vr[i] = args[i].ToString();
    //        }
    //        return vr;
    //    }
    //public static List<string> CastArrayIntToString(int[] args)
    //    {
    //        List<string> vr = new string[args.Length];
    //        for (int i = 0; i < args.Length; i++)
    //        {
    //            vr[i] = args[i].ToString();
    //        }
    //        return vr;
    //    }
    #endregion
    #region Casting to List
    public static List<int> CastToIntList<U>(IList<U> values)
    {
        return CAToNumber.ToNumber(int.Parse, values);
    }
    /// <summary>
    ///     Pokud se cokoliv nepodaří přetypovat, vyhodí výjimku
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name="values"></param>
    public static List<int> CastCollectionStringToInt(IList<string> values)
    {
        return CAToNumber.ToNumber(int.Parse, values);
    }
    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="input"></param>
    public static void RemoveNotNumber(IList input)
    {
        for (var index = input.Count - 1; index >= 0; index--)
            if (!double.TryParse(input[index].ToString(), out var _))
                input.RemoveAt(index);
    }
    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name="numbers"></param>
    public static List<int> CastCollectionShortToInt(List<short> numbers)
    {
        var result = new List<int>();
        for (var index = 0; index < numbers.Count; index++) result.Add(numbers[index]);
        return result;
    }
    public static List<short> CastCollectionIntToShort(List<int> numbers)
    {
        var result = new List<short>(numbers.Count);
        for (var index = 0; index < numbers.Count; index++) result.Add((short)numbers[index]);
        return result;
    }
    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    public static List<int> CastListShortToListInt(List<short> numbers)
    {
        return CastCollectionShortToInt(numbers);
    }
    #endregion
    #region MakeUpTo*NumbersToZero
    public static object MakeUpTo3NumbersToZero(int number)
    {
        var digitsCount = number.ToString().Length;
        if (digitsCount == 1)
            return "0" + number;
        if (digitsCount == 2) return "00" + number;
        return number;
    }
    public static object MakeUpTo2NumbersToZero(int number)
    {
        if (number.ToString().Length == 1) return "0" + number;
        return number;
    }
    #endregion
    #region Ostatní
    /// <summary>
    ///     Rok nezkracuje, počítá se standardním 4 místným
    ///     Produkuje formát standardní s metodou DateTime.ToString()
    /// </summary>
    /// <param name="dateTime"></param>
    public static string SameLenghtAllDateTimes(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return day + "." + month + "." + year + " " + hour + ":" +
               minutes + ":" + seconds; // +":" + miliseconds;
    }
    public static string SameLenghtAllDates(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        return
            day + "." + month + "." +
            year; // +"" + hour + ":" + minutes + ":" + seconds;// +":" + miliseconds;
    }
    public static string SameLenghtAllTimes(DateTime dateTime)
    {
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return hour + ":" + minutes + ":" + seconds; // +":" + miliseconds;
    }
    public static string UsaDateTimeToString(DateTime dateTime)
    {
        return dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year + " " + dateTime.Hour +
               ":" + dateTime.Minute + ":" + dateTime.Second; // +":" + miliseconds;
    }
    public static bool EqualDateWithoutTime(DateTime dt1, DateTime dt2)
    {
        if (dt1.Day == dt2.Day && dt1.Month == dt2.Month && dt1.Year == dt2.Year) return true;
        return false;
    }
    #endregion
    #region GetNumberedList*
    /// <param name="from"></param>
    /// <param name="max"></param>
    /// <param name="postfix"></param>
    public static string[] GetNumberedListFromTo(int from, int max)
    {
        max++;
        var result = new List<string>();
        for (var index = from; index < max; index++) result.Add(index.ToString());
        return result.ToArray();
    }
    public static List<string> GetNumberedListFromTo(int start, int max, string postfix = ". ")
    {
        max++;
        max += start;
        var result = new List<string>();
        for (var index = start; index < max; index++) result.Add(index + postfix);
        return result;
    }
    private static List<string> GetNumberedListFromToList(int start, int indexOdNext)
    {
        var result = new List<string>();
        var numbers = GetNumberedListFromTo(start, indexOdNext);
        foreach (object item in numbers) result.Add(item.ToString());
        return result;
    }
    #endregion
}