namespace SunamoWpf._sunamo;

///// <summary>
///// EN: Application-wide static properties. Must be initialized via SunamoWpfInitializer.Initialize() before use.
///// CZ: Statické vlastnosti celé aplikace. Musí být inicializovány přes SunamoWpfInitializer.Initialize() před použitím.
///// </summary>
//internal class ThisApp
//{
//    internal static string Name;
//    internal static string EventLogName;
//    internal static string Project;

//    internal static event Action<TypeOfMessageWpf, string> StatusSetted;
//    internal static void Success(string v, params string[] o)
//    {
//        SetStatus(TypeOfMessageWpf.Success, v, o);
//    }
//    internal static void Info(string v, params string[] o)
//    {
//        SetStatus(TypeOfMessageWpf.Information, v, o);
//    }
//    internal static void Error(string v, params string[] o)
//    {
//        SetStatus(TypeOfMessageWpf.Error, v, o);
//    }
//    internal static void Appeal(string v, params string[] o)
//    {
//        SetStatus(TypeOfMessageWpf.Appeal, v, o);
//    }

//    internal static void Warning(string v, params string[] o)
//    {
//        SetStatus(TypeOfMessageWpf.Warning, v, o);
//    }

//    internal static void SetStatus(TypeOfMessageWpf st, string status, params string[] args)
//    {
//        var format = /*string.Format*/ string.Format(status, args);
//        if (format.Trim() != string.Empty)
//        {
//            if (StatusSetted == null)
//            {
//                // For unit tests
//                //////////DebugLogger.Instance.WriteLine(st + ": " + format);
//            }
//            else
//            {
//                StatusSetted(st, format);
//            }
//        }
//    }
//}