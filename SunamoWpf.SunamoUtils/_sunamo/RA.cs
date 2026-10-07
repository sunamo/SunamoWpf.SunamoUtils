namespace SunamoWpf._sunamo;

/// <summary>
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class RA
{
    protected static List<string> valuesInKey;
    protected static RegistryKey m;
    private static bool _initialized = false;
    private static readonly object _lock = new object();

    /// <summary>
    /// EN: Initialize registry access with application name
    /// CZ: Inicializuje přístup do registru s názvem aplikace
    /// </summary>
    public static void Initialize(string applicationName)
    {
        lock (_lock)
        {
            if (_initialized) return;

            //HKEY_LOCAL_MACHINE\SOFTWARE
            var hklm = Registry.CurrentUser;
            var softwareKey = hklm.OpenSubKey("SOFTWARE", true);
            m = softwareKey.OpenSubKey(applicationName, true);
            if (m == null)
            {
                m = softwareKey.CreateSubKey(applicationName);
                valuesInKey = new List<string>();
            }
            else
            {
                valuesInKey = new List<string>(m.GetValueNames());
            }

            _initialized = true;
        }
    }
    /// <summary>
    ///     Abstraktni uz nikdy nedelej, proste musi tu metodu prekryt a oznacit za static a zavolat v statickem konstruktoru,
    ///     pokud chces ji volat ihned pri vytvoreni staticke instance nebo ji chces treba volat v F1.
    ///     Trida vraci string aby jsi ji mohl inicializovat treba A1.
    /// </summary>
    public virtual string CreateDefaultValues()
    {
        return "";
    }
    public static void WriteToKeyInt(string klic, int hodnota)
    {
        m.SetValue(klic, hodnota, RegistryValueKind.DWord);
    }
    public static int ReturnValueInt(string klic)
    {
        int result;
        var value = m.GetValue(klic);
        if (value != null)
            if (int.TryParse(value.ToString(), out result))
                return result;
        return -1;
    }
    /// <summary>
    ///     Pokud klk A1 nebude nalezen, G "".
    /// </summary>
    /// <param name="Login"></param>
    public static string ReturnValueString(string Login)
    {
        return m.GetValue(Login, "", RegistryValueOptions.None).ToString();
    }
    public static void WriteToKeyString(string klic, string hodnota)
    {
        m.SetValue(klic, hodnota, RegistryValueKind.String);
    }
    public static byte[] ReturnValueByteArray(string Login)
    {
        return (byte[])m.GetValue(Login, null, RegistryValueOptions.None);
    }
    public static void WriteToKeyByteArray(string klic, byte[] hodnota)
    {
        m.SetValue(klic, hodnota, RegistryValueKind.Binary);
    }
    public static void SaveToKeyBool(string klic, object hodnota)
    {
        m.SetValue(klic, hodnota.ToString(), RegistryValueKind.String);
    }
    public static bool ReturnValueBool(string klic)
    {
        var text = m.GetValue(klic, "").ToString();
        if (text == "True") return true;
        return false;
    }
}