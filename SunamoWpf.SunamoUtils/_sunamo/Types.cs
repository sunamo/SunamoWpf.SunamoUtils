namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the types type.
/// </summary>
public class Types
{
    /// <summary>
    /// The t object.
    /// </summary>
    public static readonly Type tObject = typeof(object);
    /// <summary>
    /// The t string builder.
    /// </summary>
    public static readonly Type tStringBuilder = typeof(StringBuilder);
    /// <summary>
    /// The t i enumerable.
    /// </summary>
    public static readonly Type tIEnumerable = typeof(IEnumerable);
    /// <summary>
    /// The t string.
    /// </summary>
    public static readonly Type tString = typeof(string);
    /// <summary>
    /// The t float.
    /// </summary>
    public static readonly Type tFloat = typeof(float);
    /// <summary>
    /// The t double.
    /// </summary>
    public static readonly Type tDouble = typeof(double);
    /// <summary>
    /// The t int.
    /// </summary>
    public static readonly Type tInt = typeof(int);
    /// <summary>
    /// The t long.
    /// </summary>
    public static readonly Type tLong = typeof(long);
    /// <summary>
    /// The t short.
    /// </summary>
    public static readonly Type tShort = typeof(short);
    /// <summary>
    /// The t decimal.
    /// </summary>
    public static readonly Type tDecimal = typeof(decimal);
    /// <summary>
    /// The t sbyte.
    /// </summary>
    public static readonly Type tSbyte = typeof(sbyte);
    /// <summary>
    /// The t byte.
    /// </summary>
    public static readonly Type tByte = typeof(byte);
    /// <summary>
    /// The t ushort.
    /// </summary>
    public static readonly Type tUshort = typeof(ushort);
    /// <summary>
    /// The t uint.
    /// </summary>
    public static readonly Type tUint = typeof(uint);
    /// <summary>
    /// The t ulong.
    /// </summary>
    public static readonly Type tUlong = typeof(ulong);
    /// <summary>
    /// The t date time.
    /// </summary>
    public static readonly Type tDateTime = typeof(DateTime);
    /// <summary>
    /// The t binary.
    /// </summary>
    public static readonly Type tBinary = typeof(byte[]);
    /// <summary>
    /// The t char.
    /// </summary>
    public static readonly Type tChar = typeof(char);
    /// <summary>
    /// The all basic types.
    /// </summary>
    public static readonly List<Type> allBasicTypes = new()
{
tObject, tString, tStringBuilder, tInt, tDateTime,
tDouble, tFloat, tChar, tBinary, tByte, tShort, tBinary, tLong, tDecimal, tSbyte, tUshort, tUint, tUlong
};
    /// <summary>
    /// The list.
    /// </summary>
    public static readonly Type list = typeof(IList);
    #region Same seria as in DefaultValueForTypeT
    /// <summary>
    /// The t bool.
    /// </summary>
    public static readonly Type tBool = typeof(bool);
    #region Signed numbers
    #endregion
    #region Unsigned numbers
    #endregion
    /// <summary>
    /// The t guid.
    /// </summary>
    public static readonly Type tGuid = typeof(Guid);
    #endregion
}