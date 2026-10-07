namespace SunamoWpf._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
internal sealed partial class Exceptions
{
    #region Other
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }
    internal static string? IsNotTheSame<T>(string before, string name1, T value1, string name2, T value2)
    {
        if (!EqualityComparer<T>.Default.Equals(value1, value2))
        {
            return $"{before}{name1}({value1}) differs from {name2}({value2})";
        }
        return null;
    }
    internal static string? HasNotIndex<T>(string before, IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        if (list.Count() <= maxRequiredIndex)
        {
            return $"{before}{listName} dont have only {list.Count()} items but is required {maxRequiredIndex} indexes";
        }
        return null;
    }
    internal static string TextOfExceptions(Exception exception)
    {
        return exception.GetAllMessages();
    }
    internal static Tuple<string, string, string> PlaceOfException(
bool fillAlsoFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceText = stackTrace.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var index = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; index < lines.Count; index++)
        {
            var item = lines[index];
            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }
    internal static void TypeAndMethodName(string line, out string type, out string methodName)
    {
        var afterAt = line.Split("at ")[1].Trim();
        var signature = afterAt.Split("(")[0];
        var parts = signature.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        type = string.Join(".", parts);
    }
    internal static string CallingMethod(int frameIndex = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(frameIndex)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion
    #region IsNullOrWhitespace
    internal static string? IsNullOrWhitespace(string before, string argName, string argValue, bool notAllowOnlyWhitespace)
    {
        string addParams;
        if (argValue == null)
        {
            addParams = AddParams();
            return CheckBefore(before) + argName + " is null" + addParams;
        }
        if (argValue == string.Empty)
        {
            addParams = AddParams();
            return CheckBefore(before) + argName + " is empty (without trim)" + addParams;
        }
        if (notAllowOnlyWhitespace && argValue.Trim() == string.Empty)
        {
            addParams = AddParams();
            return CheckBefore(before) + argName + " is empty (with trim)" + addParams;
        }
        return null;
    }
    readonly static StringBuilder sbAdditionalInfoInner = new();
    readonly static StringBuilder sbAdditionalInfo = new();
    internal static string AddParams()
    {
        sbAdditionalInfo.Insert(0, Environment.NewLine);
        sbAdditionalInfo.Insert(0, "Outer:");
        sbAdditionalInfo.Insert(0, Environment.NewLine);
        sbAdditionalInfoInner.Insert(0, Environment.NewLine);
        sbAdditionalInfoInner.Insert(0, "Inner:");
        sbAdditionalInfoInner.Insert(0, Environment.NewLine);
        var addParams = sbAdditionalInfo.ToString();
        var addParamsInner = sbAdditionalInfoInner.ToString();
        return addParams + addParamsInner;
    }
    #endregion
    #region OnlyReturnString 
    internal static string? FolderIsNotEmpty(string before, string variableName, string path)
    {
        return before + $"Folder {path} is not empty. Variable name: {variableName}";
    }
    internal static string? NotInRange(string before, string variableName, IEnumerable<string> list, int isLt, int isGt)
    {
        return before + $"{variableName} with items {string.Join(",", list)} is out of range, it is < {isLt} or > {isGt}";
    }
    internal static string? NotSupportedExtension(string before, string extension)
    {
        return before + $"Extension {extension} is not supported";
    }
    internal static string? UseRlc(string before)
    {
        return CheckBefore(before) + "Don't implement, use methods in rlc";
    }
    internal static string? RepeatAfterTimeXTimesFailed(string before, int times, int timeoutInMs, string address,
    int sharedAlgorithmslastError)
    {
        return CheckBefore(before) +
        $"Loading uri {address} failed {times} ({timeoutInMs} ms timeout) HTTP Error: {sharedAlgorithmslastError}";
    }
    internal static string? NotValidXml(string before, string path, Exception exception)
    {
        return CheckBefore(before) + path + " is not valid xml. " + TextOfExceptions(exception);
    }
    internal static string? IsNotAllowed(string before, string what)
    {
        return CheckBefore(before) + what + " is not allowed.";
    }
    internal static string? BadFormatOfElementInList(string before, object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return CheckBefore(before) + " Bad format of element" + " " + SH_NullToStringOrDefault(elVal) +
        " in list " + listName;
    }
    internal static string? IsTheSame(string before, string fst, string sec)
    {
        return CheckBefore(before) + $"{fst} and {sec} has the same value";
    }
    internal static string? DivideByZero(string before)
    {
        return CheckBefore(before) + " is dividing by zero.";
    }
    internal static string? AnyElementIsNullOrEmpty(string before, string nameOfCollection, IEnumerable<int> nulled)
    {
        return CheckBefore(before) + $"In {nameOfCollection} has indexes " + string.Join(",", nulled) +
        " with null value";
    }
    internal static string? NotEvenNumberOfElements(string before, string nameOfCollection)
    {
        return CheckBefore(before) + nameOfCollection + " have odd elements count";
    }
    internal static string? InvalidExactlyLength(string before, string variableName, int length, int requiredLenght)
    {
        if (length != requiredLenght)
        {
            return CheckBefore(before) + variableName + $" have length {length}, required {requiredLenght}";
        }
        return null;
    }
    internal static string? FileHasExtensionNotParseAbleToImageFormat(string before, string fnOri)
    {
        return CheckBefore(before) + "File " + fnOri + " has wrong file extension";
    }
    internal static string? WrongCountInList(string before, int numberOfElementsWithoutPause, int numberOfElementsWithPause,
    int arrLength)
    {
        return CheckBefore(before) + string.Format("Array should have {0} or {1} elements, have {2}", numberOfElementsWithoutPause,
        numberOfElementsWithPause, arrLength);
    }
    internal static string? FileExists(string before, string fulLPath)
    {
        return CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }
    internal static string? FileWasntFoundInDirectory(string before, string path)
    {
        return CheckBefore(before) + "NotFound" + ": " + path;
    }
    internal static string? NotSupported(string before)
    {
        return CheckBefore(before) + "Not supported";
    }
    internal static string? ToManyElementsInCollection(string before, int max, int actual, string nameCollection)
    {
        return CheckBefore(before) + actual + " elements in " + nameCollection + ", maximum is " + max;
    }
    internal static string? FunctionalityDenied(string before, string functionalityName)
    {
        return CheckBefore(before) + $"Functionality {functionalityName} is denied";
    }
    internal static string? MoreCandidates(string before, IEnumerable<string> list, string item)
    {
        return CheckBefore(before) + "Under" + " " + item + " is more candidates: " + Environment.NewLine +
        string.Join(Environment.NewLine, list);
    }
    internal static string? BadMappedXaml(string before, string nameControl, string additionalInfo)
    {
        return CheckBefore(before) + $"Bad mapped XAML in {nameControl}. {additionalInfo}";
    }
    internal static string? ElementCantBeFound(string before, string nameCollection, string element)
    {
        return CheckBefore(before) + element + "cannot be found in " + nameCollection;
    }
    internal static string? DoesntHaveRequiredType(string before, string variableName)
    {
        return CheckBefore(before) + variableName + "does not have required type" + ".";
    }
    internal static string? ArgumentOutOfRangeException(string before, string paramName, string message)
    {
        return CheckBefore(before) + $"{paramName} is out of range, another info: {message}";
    }
    internal static string? Custom(string before, string message)
    {
        return CheckBefore(before) + message;
    }
    internal static string? FolderCannotBeDeleted(string before, string folder, Exception exception)
    {
        return CheckBefore(before) + $"{folder} cannot be deleted, another info: " + TextOfExceptions(exception);
    }
    internal static string? CannotCreateDateTime(string before, int year, int month, int day, int hour, int minute, int seconds,
Exception exception)
    {
        return CheckBefore(before) +
        $"Cannot create DateTime with: year: {year} month: {month} day: {day} hour: {hour} minute: {minute} seconds: {seconds} " +
        TextOfExceptions(exception);
    }
    internal static string? CannotMoveFolder(string before, string item, string nova, Exception exception)
    {
        return CheckBefore(before) + $"Cannot move folder from {item} to {nova} " + TextOfExceptions(exception);
    }
    internal static string? ExcAsArg(string before, Exception exception, string message)
    {
        return CheckBefore(before) + message + string.Empty + TextOfExceptions(exception);
    }
    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }
    internal static string? NotExists(string before, string what)
    {
        return CheckBefore(before) + what + " not exists";
    }
    #endregion
    internal static string? KeyAlreadyExists<T, U>(string before, Dictionary<T, U> dictionary, T key, string dictionaryName)
    {
        if (dictionary.ContainsKey(key))
        {
            return before + $"Key {key} already exists in {dictionaryName}";
        }
        return null;
    }
    internal static string? FileAlreadyExists(string before, string path)
    {
        if (File.Exists(path))
        {
            return CheckBefore(before) + path + " already exists";
        }
        return null;
    }
    internal static string? ListNullOrEmpty<T>(string before, string variableName, IEnumerable<T>? list)
    {
        if (list == null)
        {
            return CheckBefore(before) + variableName + " is null";
        }
        bool isEmpty = true;
        foreach (var item in list)
        {
            isEmpty = false;
            break;
        }
        if (isEmpty)
        {
            return CheckBefore(before) + variableName + " is empty!";
        }
        return null;
    }
    internal static string? LockedByBitLocker(string before, string path, Func<char, bool> IsLockedByBitLocker)
    {
        if (IsLockedByBitLocker != null)
        {
            var firstChar = path[0];
            if (IsLockedByBitLocker(firstChar))
            {
                return CheckBefore(before) + $"Drive {firstChar}:\\ is locked by BitLocker";
            }
        }
        return null;
    }
    internal static string? NotInt(string before, string what, int? value)
    {
        return !value.HasValue ? CheckBefore(before) + what + " is not with value " + value + " valid integer number" : null;
    }
    internal static string? HasOddNumberOfElements(string before, string listName, ICollection list)
    {
        return list.Count % 2 == 1 ? CheckBefore(before) + listName + " has odd number of elements " + list.Count : null;
    }
    internal static string? WrongExtension(string before, string path, string requiredExt)
    {
        return System.IO.Path.GetExtension(path) != requiredExt ? CheckBefore(before) + path + "don't have " + requiredExt + " extension" : null;
    }
    internal static string? WrongNumberOfElements<T>(string before, int requireElements, string nameCollection,
    IEnumerable<T> collection)
    {
        var count = collection.Count();
        return count != requireElements ? CheckBefore(before) + $" {nameCollection} has {count}, it's required {requireElements}" : null;
    }
    internal static string? DirectoryWasntFound(string before, string directory)
    {
        return !Directory.Exists(directory)
        ? CheckBefore(before) + " Directory" + " " + directory +
        " wasn't found."
        : null;
    }
    internal static string? PassedListInsteadOfArray<T>(string before, string variableName, IEnumerable<T> values, Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        if (CA_IsListStringWrappedInArray(values))
            return CheckBefore(before) + $" {variableName} is IEnumerable<string>, was passed IEnumerable<string> into params";
        return null;
    }
    internal static string? IsWhitespaceOrNull(string before, string variable, object data)
    {
        var isNull = false;
        var isWhitespace = false;
        if (data == null)
            isNull = true;
        else if ((data.ToString() ?? string.Empty).Trim() == string.Empty) isWhitespace = true;
        return isNull || isWhitespace ? CheckBefore(before) + variable + (isNull ? " is null" : " is whitespace") : null;
    }
    internal static string? UncommentNextRows(string before)
    {
        return CheckBefore(before) + "Uncomment next rows";
    }
    internal static string? OutOfRange(string before, string colName, ICollection col, string indexName, int index)
    {
        return col.Count <= index
        ? CheckBefore(before) + $"{index} (variable {indexName}) is out of range in {colName}"
        : null;
    }
    internal static string? HaveAllInnerSameCount(string before, List<List<string>> elements)
    {
        var first = elements[0].Count;
        List<int> wrongCount = [];
        for (var index = 1; index < elements.Count; index++)
            if (first != elements[index].Count)
                wrongCount.Add(index);
        return wrongCount.Count > 0
        ? CheckBefore(before) + $"Elements {string.Join(',', wrongCount)} have different count than 0 (first)"
        : null;
    }
    internal static string? DirectoryExists(string before, string fulLPath)
    {
        return Directory.Exists(fulLPath)
        ? null
        : CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }
    internal static string? CheckBackslashEnd(string before, string path)
    {
        if (path.Length != 0)
            if (path[^1] != '\\')
                return CheckBefore(before) + " string has not been in path format" + "!";
        return null;
    }
    internal static string? IsNotNull(string before, string variableName, object variable)
    {
        return variable != null ? CheckBefore(before) + variableName + " must be null." : null;
    }
    internal static string? ArrayElementContainsUnallowedStrings(string before, string arrayName, int dex,
    string valueElement, params string[] unallowedStrings)
    {
        var foundedUnallowed = unallowedStrings.Where(item => valueElement.Contains(item)).ToList();
        return foundedUnallowed.Count != 0
        ? CheckBefore(before) + "Element of" + " " + arrayName + " on index " + dex +
        " with value " + valueElement + " contains unallowed string(" + foundedUnallowed.Count + "): " +
        string.Join(',', unallowedStrings)
        : null;
    }
    internal static string? StartIsHigherThanEnd(string before, int start, int end)
    {
        return start > end ? CheckBefore(before) + $"Start {start} is higher than end {end}" : null;
    }
    internal static string? WasNotKeysHandler(string before, string name, object keysHandler)
    {
        return keysHandler == null
        ? CheckBefore(before) + name + " " + "was not IKeysHandler"
        : null;
    }
    internal static string? FolderCantBeRemoved(string before, string folder)
    {
        return CheckBefore(before) + "Cannot delete folder" + ": " + folder;
    }
    internal static string? ElementWasntRemoved(string before, string detailLocation, int before2, int after)
    {
        return before2 == after
        ? CheckBefore(before) + "Element was not removed during" + ": " +
        detailLocation
        : null;
    }
    internal static string? NoPassedFolders(string before, ICollection folders)
    {
        return folders.Count == 0 ? CheckBefore(before) + "No passed folder into" : null;
    }
    internal static string? FileSystemException(string text, Exception exception)
    {
        return exception != null ? CheckBefore(text) + " " + TextOfExceptions(exception) : null;
    }
    internal static string? InvalidParameter(string before, string valueVar, string nameVar)
    {
        return valueVar != WebUtility.UrlDecode(valueVar)
        ? CheckBefore(before) + valueVar + " is url encoded " + nameVar
        : null;
    }
    internal static string? MoreThanOneElement(string before, string listName, int count, string moreInfo = "")
    {
        return count > 1
        ? CheckBefore(before) + listName + " has " + count + " elements, which is more than 1. " + moreInfo
        : null;
    }
    internal static string? NameIsNotSetted(string before, string nameControl, string nameFromProperty)
    {
        return string.IsNullOrWhiteSpace(nameFromProperty)
        ? CheckBefore(before) + nameControl + " " + "does not have setted name"
        : null;
    }
    internal static string? OnlyOneElement(string before, string colName, ICollection list)
    {
        return list.Count == 1 ? CheckBefore(before) + colName + " has only one element" : null;
    }
    internal static string? StringContainsUnallowedSubstrings(string before, string input,
    params string[] unallowedStrings)
    {
        List<string> foundedUnallowed = [];
        foreach (var item in unallowedStrings)
            if (input.Contains(item))
                foundedUnallowed.Add(item);
        return foundedUnallowed.Count > 0
        ? CheckBefore(before) + input + " contains unallowed chars: " +
        string.Join(string.Empty, unallowedStrings)
        : null;
    }
    internal static string? IsNull(string before, string variableName, object? variable)
    {
        return variable == null ? CheckBefore(before) + variableName + " " + "is null" + "." : null;
    }
    internal static string? NotImplementedCase(string before, object notImplementedName)
    {
        var suffix = string.Empty;
        if (notImplementedName != null)
        {
            suffix = " for ";
            if (notImplementedName.GetType() == typeof(Type))
                suffix += ((Type)notImplementedName).FullName;
            else
                suffix += notImplementedName.ToString();
        }
        return CheckBefore(before) + "Not implemented case" + suffix + " . internal program error. Please contact developer" +
        ".";
    }
    internal static string? NotContains(string before, string originalText, params string[] shouldContains)
    {
        List<string> notContained = [];
        foreach (var item in shouldContains)
            if (!originalText.Contains(item))
                notContained.Add(item);
        return notContained.Count == 0
        ? null
        : CheckBefore(before) + "Original text dont contains: " + string.Join(",", notContained) + ". Original text: " + originalText;
    }
    internal static string? HasNotKeyDictionary<Key, Value>(string before, string nameDict, IDictionary<Key, Value> qsDict,
    Key remains)
    {
        return !qsDict.ContainsKey(remains) ? CheckBefore(before) + nameDict + " does not contains key " + remains : null;
    }
    internal static string? IsEmpty(string before, IEnumerable folders, string colName,
    string additionalMessage = "")
    {
        return !folders.OfType<object>().Any()
        ? CheckBefore(before) + colName + " has no elements. " + additionalMessage
        : null;
    }
    internal static string? UriFormat(string before, string url, Func<string, bool> uhIsUri)
    {
        if (uhIsUri(url))
        {
            return null;
        }
        return CheckBefore(before) + "Is not correct url format: " + url;
    }
    internal static string? IsWindowsPathFormat(string before, string input, Func<string, bool> isWindowsPathFormat)
    {
        if (isWindowsPathFormat(input))
            return CheckBefore(before) + input + "is path but only key is expected";
        return null;
    }
    internal static string? IsNotWindowsPathFormat(string before, string argName, string argValue, bool raiseIsNotWindowsPathFormat, Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        if (raiseIsNotWindowsPathFormat)
        {
            var badFormat = !SunamoFileSystem_IsWindowsPathFormat(argValue);
            if (badFormat)
                return CheckBefore(before) + " " + argName + " is not in Windows path format";
        }
        return null;
    }
    internal static string WasAlreadyInitialized(string before)
    {
        return before + " was already initialized!";
    }
    internal static string? DifferentCountInLists(string before, string namefc, int countfc, string namesc, int countsc)
    {
        if (countfc != countsc)
            return CheckBefore(before) + " different count elements in collection" + " " +
            string.Concat(namefc + "-" + countfc) + " vs. " +
            string.Concat(namesc + "-" + countsc);
        return null;
    }
    internal static string? FirstLetterIsNotUpper(string before, string text)
    {
        return text.Length == 0 ? null :
        char.IsLower(text[0]) ? CheckBefore(before) + "First letter is not upper: " + text : null;
    }
    internal static string? KeyNotFound<T, U>(string before, IDictionary<T, U> dictionary, string dictName, T key)
    {
        return !dictionary.ContainsKey(key)
        ? CheckBefore(before) + key + " is not exists in dictionary" + " " + dictName
        : null;
    }
    internal static string? DuplicatedElements(string before, string nameOfVariable, List<string> duplicatedElements,
    string message = "")
    {
        return duplicatedElements.Count != 0
        ? CheckBefore(before) + $"Duplicated elements in {nameOfVariable} list: " + string.Join(',', [.. duplicatedElements]) +
        " " + message
        : null;
    }
    internal static string? ZeroOrMoreThanOne(string before, string nameOfVariable, List<string> list)
    {
        return list.Count == 0 || list.Count > 1
        ? CheckBefore(before) + $"{list.Count} elements in {nameOfVariable} which is zero or more than one"
        : null;
    }
    internal static string? IsNotPositiveNumber(string before, string nameOfVariable, int? number)
    {
        return !number.HasValue ? CheckBefore(before) + nameOfVariable + " is not int" :
        number.Value > 0 ? null : CheckBefore(before) + nameOfVariable + " is int but not > 0";
    }
    internal static string? CheckBackSlashEnd(string before, string path)
    {
        if (!path.EndsWith('\\')) return CheckBefore(before) + " " + path + " don't end with \\";
        return null;
    }
    internal static string? FolderDoesNotExists(string before, string folder, string additionalInfo)
    {
        if (!Directory.Exists(folder))
        {
            return before + $"Folder {folder} does not exists. {additionalInfo}";
        }
        return null;
    }
}