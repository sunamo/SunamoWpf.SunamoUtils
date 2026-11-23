namespace SunamoWpf._sunamo.SunamoExceptions;

/// <summary>
/// Represents the throw ex type.
/// </summary>
public partial class ThrowEx
{
    /// <summary>
    /// The show exception window.
    /// </summary>
    public static Action<object> showExceptionWindow;
    /// <summary>
    /// The really throw 2.
    /// </summary>
    public static bool reallyThrow2;

    /// <summary>
    /// Is not the same t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="name1">The name 1.</param>
    /// <param name="value1">The value 1.</param>
    /// <param name="name2">The name 2.</param>
    /// <param name="value2">The value 2.</param>
    /// <returns>The is not the same t result.</returns>
    public static bool IsNotTheSame<T>(string name1, T value1, string name2, T value2)
    {
        return ThrowIsNotNull(Exceptions.IsNotTheSame(FullNameOfExecutedCode(), name1, value1, name2, value2));
    }

    /// <summary>
    /// Folder does not exists.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="additionalInfo">The additional info.</param>
    /// <returns>The folder does not exists result.</returns>
    public static bool FolderDoesNotExists(string folder, string additionalInfo = "")
    {
        return ThrowIsNotNull(Exceptions.FolderDoesNotExists(FullNameOfExecutedCode(), folder, additionalInfo));
    }

    /// <summary>
    /// Key already exists t u.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key.</param>
    /// <param name="dictionaryName">The dictionary name.</param>
    /// <returns>The key already exists t u result.</returns>
    public static bool KeyAlreadyExists<T, U>(Dictionary<T, U> dictionary, T key, string dictionaryName)
    {
        return ThrowIsNotNull(Exceptions.KeyAlreadyExists(FullNameOfExecutedCode(), dictionary, key, dictionaryName));
    }

    /// <summary>
    /// Has not index t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="maxRequiredIndex">The max required index.</param>
    /// <returns>The has not index t result.</returns>
    public static bool HasNotIndex<T>(IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        return ThrowIsNotNull(Exceptions.HasNotIndex(FullNameOfExecutedCode(), list, listName, maxRequiredIndex));
    }

    /// <summary>
    /// Argument out of range exception.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="message">The message.</param>
    /// <returns>The argument out of range exception result.</returns>
    public static bool ArgumentOutOfRangeException(string argName, string message = "")
    { return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), argName, message)); }
    /// <summary>
    /// Array element contains un allowed strings.
    /// </summary>
    /// <param name="arrayName">The array name.</param>
    /// <param name="dex">The dex.</param>
    /// <param name="valueElement">The value element.</param>
    /// <param name="unallowedStrings">The unallowed strings.</param>
    /// <returns>The array element contains un allowed strings result.</returns>
    public static bool ArrayElementContainsUnAllowedStrings(
        string arrayName,
        int dex,
        string valueElement,
        params string[] unallowedStrings)
    {
        return ThrowIsNotNull(
            Exceptions.ArrayElementContainsUnallowedStrings(
                FullNameOfExecutedCode(),
                arrayName,
                dex,
                valueElement,
                unallowedStrings));
    }
    /// <summary>
    /// Bad format of element in list.
    /// </summary>
    /// <param name="elVal">The el val.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="SH_NullToStringOrDefault">The SH null to string or default.</param>
    /// <returns>The bad format of element in list result.</returns>
    public static bool BadFormatOfElementInList(
        object elVal,
        string listName,
        Func<object, string> SH_NullToStringOrDefault)
    {
        return ThrowIsNotNull(
            Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(), elVal, listName, SH_NullToStringOrDefault));
    }

    /// <summary>
    /// Bad mapped xaml.
    /// </summary>
    /// <param name="nameControl">The name control.</param>
    /// <param name="additionalInfo">The additional info.</param>
    /// <returns>The bad mapped xaml result.</returns>
    public static bool BadMappedXaml(string nameControl, string additionalInfo)
    { return ThrowIsNotNull(Exceptions.BadMappedXaml(FullNameOfExecutedCode(), nameControl, additionalInfo)); }
    /// <summary>
    /// Cannot create date time.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>The cannot create date time result.</returns>
    public static bool CannotCreateDateTime(
        int year,
        int month,
        int day,
        int hour,
        int minute,
        int seconds,
        Exception exception)
    {
        return ThrowIsNotNull(
            Exceptions.CannotCreateDateTime(FullNameOfExecutedCode(), year, month, day, hour, minute, seconds, exception));
    }
    /// <summary>
    /// Cannot move folder.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="nova">The nova.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>The cannot move folder result.</returns>
    public static bool CannotMoveFolder(string item, string nova, Exception exception)
    { return ThrowIsNotNull(Exceptions.CannotMoveFolder(FullNameOfExecutedCode(), item, nova, exception)); }
    /// <summary>
    /// Check backslash end.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The check backslash end result.</returns>
    public static bool CheckBackslashEnd(string path)
    { return ThrowIsNotNull(Exceptions.CheckBackSlashEnd(FullNameOfExecutedCode(), path)); }

    /// <summary>
    /// Custom.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <returns>The custom result.</returns>
    public static bool Custom(Exception exception, bool reallyThrow = true)
    { return Custom(Exceptions.TextOfExceptions(exception), reallyThrow); }

    /// <summary>
    /// Custom.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <param name="secondMessage">The second message.</param>
    /// <returns>The custom result.</returns>
    public static bool Custom(string message, bool reallyThrow = true, string secondMessage = "")
    {
        string joined = string.Join(" ", message, secondMessage);
        string? str = Exceptions.Custom(FullNameOfExecutedCode(), joined);
        return ThrowIsNotNull(str, reallyThrow);
    }

    /// <summary>
    /// Custom with stack trace.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>The custom with stack trace result.</returns>
    public static bool CustomWithStackTrace(Exception exception) { return Custom(Exceptions.TextOfExceptions(exception)); }
    /// <summary>
    /// Different count in lists t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="namefc">The namefc.</param>
    /// <param name="countfc">The countfc.</param>
    /// <param name="namesc">The namesc.</param>
    /// <param name="countsc">The countsc.</param>
    /// <returns>The different count in lists t result.</returns>
    public static bool DifferentCountInLists<T>(string namefc, IList<T> countfc, string namesc, IList<T> countsc)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }
    /// <summary>
    /// Different count in lists.
    /// </summary>
    /// <param name="namefc">The namefc.</param>
    /// <param name="countfc">The countfc.</param>
    /// <param name="namesc">The namesc.</param>
    /// <param name="countsc">The countsc.</param>
    /// <returns>The different count in lists result.</returns>
    public static bool DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc, namesc, countsc));
    }

    /// <summary>
    /// Different count in lists TU t u.
    /// </summary>
    /// <param name="namefc">The namefc.</param>
    /// <param name="countfc">The countfc.</param>
    /// <param name="namesc">The namesc.</param>
    /// <param name="countsc">The countsc.</param>
    /// <returns>The different count in lists TU t u result.</returns>
    public static bool DifferentCountInListsTU<T, U>(string namefc, IList<T> countfc, string namesc, IList<U> countsc)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }


    /// <summary>
    /// Directory exists.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The directory exists result.</returns>
    public static bool DirectoryExists(string path)
    { return ThrowIsNotNull(Exceptions.DirectoryExists(FullNameOfExecutedCode(), path)); }

    /// <summary>
    /// Directory wasnt found.
    /// </summary>
    /// <param name="directory">The directory.</param>
    /// <returns>The directory wasnt found result.</returns>
    public static bool DirectoryWasntFound(string directory)
    { return ThrowIsNotNull(Exceptions.DirectoryWasntFound(FullNameOfExecutedCode(), directory)); }
    /// <summary>
    /// Divide by zero.
    /// </summary>
    /// <returns>The divide by zero result.</returns>
    public static bool DivideByZero() { return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode())); }
    /// <summary>
    /// Doesnt have required type.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The doesnt have required type result.</returns>
    public static bool DoesntHaveRequiredType(string variableName)
    { return ThrowIsNotNull(Exceptions.DoesntHaveRequiredType(FullNameOfExecutedCode(), variableName)); }
    /// <summary>
    /// Duplicated elements.
    /// </summary>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="duplicatedElements">The duplicated elements.</param>
    /// <param name="message">The message.</param>
    /// <returns>The duplicated elements result.</returns>
    public static bool DuplicatedElements(string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return ThrowIsNotNull(
            Exceptions.DuplicatedElements(FullNameOfExecutedCode(), nameOfVariable, duplicatedElements, message));
    }
    /// <summary>
    /// Element cant be found.
    /// </summary>
    /// <param name="nameCollection">The name collection.</param>
    /// <param name="element">The element.</param>
    /// <returns>The element cant be found result.</returns>
    public static bool ElementCantBeFound(string nameCollection, string element)
    { return ThrowIsNotNull(Exceptions.ElementCantBeFound(FullNameOfExecutedCode(), nameCollection, element)); }


    /// <summary>
    /// Element wasnt removed.
    /// </summary>
    /// <param name="detailLocation">The detail location.</param>
    /// <param name="before">The before.</param>
    /// <param name="after">The after.</param>
    /// <returns>The element wasnt removed result.</returns>
    public static bool ElementWasntRemoved(string detailLocation, int before, int after)
    { return ThrowIsNotNull(Exceptions.ElementWasntRemoved(FullNameOfExecutedCode(), detailLocation, before, after)); }

    /// <summary>
    /// Exc as arg.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="message">The message.</param>
    /// <returns>The exc as arg result.</returns>
    public static bool ExcAsArg(Exception exception, string message = "")
    { return ThrowIsNotNull(Exceptions.ExcAsArg, exception, message); }


    /// <summary>
    /// File already exists.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The file already exists result.</returns>
    public static bool FileAlreadyExists(string path) { return ThrowIsNotNull(Exceptions.FileAlreadyExists, path); }


    /// <summary>
    /// File doesnt exists.
    /// </summary>
    /// <param name="fulLPath">The ful l path.</param>
    /// <returns>The file doesnt exists result.</returns>
    public static bool FileDoesntExists(string fulLPath)
    { return ThrowIsNotNull(Exceptions.FileExists(FullNameOfExecutedCode(), fulLPath)); }
    /// <summary>
    /// File has extension not parse able to image format.
    /// </summary>
    /// <param name="fnOri">The fn ori.</param>
    /// <returns>The file has extension not parse able to image format result.</returns>
    public static bool FileHasExtensionNotParseAbleToImageFormat(string fnOri)
    { return ThrowIsNotNull(Exceptions.FileHasExtensionNotParseAbleToImageFormat(FullNameOfExecutedCode(), fnOri)); }
    /// <summary>
    /// File system exception.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>The file system exception result.</returns>
    public static bool FileSystemException(Exception exception)
    { return ThrowIsNotNull(Exceptions.FileSystemException(FullNameOfExecutedCode(), exception)); }
    /// <summary>
    /// First letter is not upper.
    /// </summary>
    /// <param name="selectedFile">The selected file.</param>
    /// <returns>The first letter is not upper result.</returns>
    public static bool FirstLetterIsNotUpper(string selectedFile)
    { return ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, selectedFile); }
    /// <summary>
    /// Folder cannot be deleted.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>The folder cannot be deleted result.</returns>
    public static bool FolderCannotBeDeleted(string folder, Exception exception)
    { return ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(), folder, exception)); }
    /// <summary>
    /// Folder cant be removed.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <returns>The folder cant be removed result.</returns>
    public static bool FolderCantBeRemoved(string folder)
    { return ThrowIsNotNull(Exceptions.FolderCantBeRemoved(FullNameOfExecutedCode(), folder)); }

    /// <summary>
    /// Folder is not empty.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="path">The path.</param>
    /// <returns>The folder is not empty result.</returns>
    public static bool FolderIsNotEmpty(string variableName, string path)
    { return ThrowIsNotNull(Exceptions.FolderIsNotEmpty, variableName, path); }
    /// <summary>
    /// Functionality denied.
    /// </summary>
    /// <param name="functionalityName">The functionality name.</param>
    /// <returns>The functionality denied result.</returns>
    public static bool FunctionalityDenied(string functionalityName)
    { return ThrowIsNotNull(Exceptions.FunctionalityDenied(FullNameOfExecutedCode(), functionalityName)); }
    /// <summary>
    /// Has not key dictionary key value.
    /// </summary>
    /// <param name="nameDict">The name dict.</param>
    /// <param name="qsDict">The qs dict.</param>
    /// <param name="remains">The remains.</param>
    /// <returns>The has not key dictionary key value result.</returns>
    public static bool HasNotKeyDictionary<Key, Value>(string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    { return ThrowIsNotNull(Exceptions.HasNotKeyDictionary(FullNameOfExecutedCode(), nameDict, qsDict, remains)); }

    /// <summary>
    /// Has odd number of elements.
    /// </summary>
    /// <param name="listName">The list name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The has odd number of elements result.</returns>
    public static bool HasOddNumberOfElements(string listName, ICollection list)
    {
        var messageFactory = Exceptions.HasOddNumberOfElements;
        return ThrowIsNotNull(messageFactory, listName, list);
    }

    /// <summary>
    /// Have all inner same count.
    /// </summary>
    /// <param name="elements">The elements.</param>
    /// <returns>The have all inner same count result.</returns>
    public static bool HaveAllInnerSameCount(List<List<string>> elements)
    { return ThrowIsNotNull(Exceptions.HaveAllInnerSameCount(FullNameOfExecutedCode(), elements)); }

    /// <summary>
    /// Invalid exactly length.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="length">The length.</param>
    /// <param name="requiredLenght">The required lenght.</param>
    /// <returns>The invalid exactly length result.</returns>
    public static bool InvalidExactlyLength(string variableName, int length, int requiredLenght)
    {
        return ThrowIsNotNull(
            Exceptions.InvalidExactlyLength(FullNameOfExecutedCode(), variableName, length, requiredLenght));
    }

    /// <summary>
    /// Invalid parameter.
    /// </summary>
    /// <param name="valueVar">The value var.</param>
    /// <param name="nameVar">The name var.</param>
    /// <returns>The invalid parameter result.</returns>
    public static bool InvalidParameter(string valueVar, string nameVar)
    { return ThrowIsNotNull(Exceptions.InvalidParameter(FullNameOfExecutedCode(), valueVar, nameVar)); }
    /// <summary>
    /// Is empty.
    /// </summary>
    /// <param name="folders">The folders.</param>
    /// <param name="colName">The col name.</param>
    /// <param name="additionalMessage">The additional message.</param>
    /// <returns>The is empty result.</returns>
    public static bool IsEmpty(IEnumerable folders, string colName, string additionalMessage = "")
    { return ThrowIsNotNull(Exceptions.IsEmpty(FullNameOfExecutedCode(), folders, colName, additionalMessage)); }

    /// <summary>
    /// Is not allowed.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <returns>The is not allowed result.</returns>
    public static bool IsNotAllowed(string what)
    { return ThrowIsNotNull(Exceptions.IsNotAllowed(FullNameOfExecutedCode(), what)); }

    /// <summary>
    /// Is not null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable.</param>
    /// <returns>The is not null result.</returns>
    public static bool IsNotNull(string variableName, object variable)
    { return ThrowIsNotNull(Exceptions.IsNotNull(FullNameOfExecutedCode(), variableName, variable)); }
    /// <summary>
    /// Is not positive number.
    /// </summary>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="number">The number.</param>
    /// <returns>The is not positive number result.</returns>
    public static bool IsNotPositiveNumber(string nameOfVariable, int? number)
    { return ThrowIsNotNull(Exceptions.IsNotPositiveNumber(FullNameOfExecutedCode(), nameOfVariable, number)); }

    /// <summary>
    /// Is not windows path format.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <param name="raiseIsNotWindowsPathFormat">The raise is not windows path format.</param>
    /// <param name="SunamoFileSystem_IsWindowsPathFormat">The sunamo file system is windows path format.</param>
    /// <returns>The is not windows path format result.</returns>
    public static bool IsNotWindowsPathFormat(
        string argName,
        string argValue,
        bool raiseIsNotWindowsPathFormat,
        Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        return ThrowIsNotNull(
            Exceptions.IsNotWindowsPathFormat(
                FullNameOfExecutedCode(),
                argName,
                argValue,
                raiseIsNotWindowsPathFormat,
                SunamoFileSystem_IsWindowsPathFormat));
    }
    /// <summary>
    /// Is null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable.</param>
    /// <returns>The is null result.</returns>
    public static bool IsNull(string variableName, object? variable = null)
    { return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable)); }

    /// <summary>
    /// Is null or empty.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <returns>The is null or empty result.</returns>
    public static bool IsNullOrEmpty(string argName, string argValue)
    { return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, true)); }
    /// <summary>
    /// Is null or whitespace.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <returns>The is null or whitespace result.</returns>
    public static bool IsNullOrWhitespace(string argName, string argValue)
    { return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, false)); }

    /// <summary>
    /// Is the same.
    /// </summary>
    /// <param name="fst">The fst.</param>
    /// <param name="sec">The sec.</param>
    /// <returns>The is the same result.</returns>
    public static bool IsTheSame(string fst, string sec)
    { return ThrowIsNotNull(Exceptions.IsTheSame(FullNameOfExecutedCode(), fst, sec)); }
    /// <summary>
    /// Is whitespace or null.
    /// </summary>
    /// <param name="variable">The variable.</param>
    /// <param name="data">The data.</param>
    /// <returns>The is whitespace or null result.</returns>
    public static bool IsWhitespaceOrNull(string variable, object data)
    { return ThrowIsNotNull(Exceptions.IsWhitespaceOrNull(FullNameOfExecutedCode(), variable, data)); }

    /// <summary>
    /// Is windows path format.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="isWindowsPathFormat">The is windows path format.</param>
    /// <returns>The is windows path format result.</returns>
    public static bool IsWindowsPathFormat(string input, Func<string, bool> isWindowsPathFormat)
    { return ThrowIsNotNull(Exceptions.IsWindowsPathFormat(FullNameOfExecutedCode(), input, isWindowsPathFormat)); }


    /// <summary>
    /// Key not found t u.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="dictName">The dict name.</param>
    /// <param name="key">The key.</param>
    /// <returns>The key not found t u result.</returns>
    public static bool KeyNotFound<T, U>(IDictionary<T, U> dictionary, string dictName, T key)
    { return ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(), dictionary, dictName, key)); }

    /// <summary>
    /// List null or empty t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="variableName">The variable name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The list null or empty t result.</returns>
    public static bool ListNullOrEmpty<T>(string variableName, IEnumerable<T>? list)
    { return ThrowIsNotNull(Exceptions.ListNullOrEmpty(FullNameOfExecutedCode(), variableName, list)); }

    /// <summary>
    /// Locked by bit locker.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="IsLockedByBitLocker">The is locked by bit locker.</param>
    /// <returns>The locked by bit locker result.</returns>
    public static bool LockedByBitLocker(string path, Func<char, bool> IsLockedByBitLocker)
    { return ThrowIsNotNull(Exceptions.LockedByBitLocker(FullNameOfExecutedCode(), path, IsLockedByBitLocker)); }

    /// <summary>
    /// More than one element.
    /// </summary>
    /// <param name="listName">The list name.</param>
    /// <param name="count">The count.</param>
    /// <param name="moreInfo">The more info.</param>
    /// <returns>The more than one element result.</returns>
    public static bool MoreThanOneElement(string listName, int count, string moreInfo = "")
    {
        string fullName = FullNameOfExecutedCode();
        string? exc = Exceptions.MoreThanOneElement(fullName, listName, count, moreInfo);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Name is not setted.
    /// </summary>
    /// <param name="nameControl">The name control.</param>
    /// <param name="nameFromProperty">The name from property.</param>
    /// <returns>The name is not setted result.</returns>
    public static bool NameIsNotSetted(string nameControl, string nameFromProperty)
    { return ThrowIsNotNull(Exceptions.NameIsNotSetted(FullNameOfExecutedCode(), nameControl, nameFromProperty)); }
    /// <summary>
    /// No passed folders.
    /// </summary>
    /// <param name="folders">The folders.</param>
    /// <returns>The no passed folders result.</returns>
    public static bool NoPassedFolders(ICollection folders)
    { return ThrowIsNotNull(Exceptions.NoPassedFolders(FullNameOfExecutedCode(), folders)); }
    /// <summary>
    /// Not contains.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="shouldContains">The should contains.</param>
    /// <returns>The not contains result.</returns>
    public static bool NotContains(string text, params string[] shouldContains)
    { return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(), text, shouldContains)); }


    /// <summary>
    /// Not exists.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <returns>The not exists result.</returns>
    public static bool NotExists(string what)
    { return ThrowIsNotNull(Exceptions.NotExists(FullNameOfExecutedCode(), what)); }

    /// <summary>
    /// Not implemented case.
    /// </summary>
    /// <param name="notImplementedName">The not implemented name.</param>
    /// <returns>The not implemented case result.</returns>
    public static bool NotImplementedCase(object notImplementedName)
    { return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName); }
    /// <summary>
    /// Not implemented method.
    /// </summary>
    /// <returns>The not implemented method result.</returns>
    public static bool NotImplementedMethod() { return ThrowIsNotNull(Exceptions.NotImplementedMethod); }
    /// <summary>
    /// Not in range.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="list">The list.</param>
    /// <param name="isLt">The is lt.</param>
    /// <param name="isGt">The is gt.</param>
    /// <returns>The not in range result.</returns>
    public static bool NotInRange(string variableName, IEnumerable<string> list, int isLt, int isGt)
    { return ThrowIsNotNull(Exceptions.NotInRange(FullNameOfExecutedCode(), variableName, list, isLt, isGt)); }
    /// <summary>
    /// Not int.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <param name="value">The value.</param>
    /// <returns>The not int result.</returns>
    public static bool NotInt(string what, int? value)
    { return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value)); }

    /// <summary>
    /// Not supported.
    /// </summary>
    /// <returns>The not supported result.</returns>
    public static bool NotSupported() { return ThrowIsNotNull(Exceptions.NotSupported(FullNameOfExecutedCode())); }
    /// <summary>
    /// Not supported extension.
    /// </summary>
    /// <param name="extension">The extension.</param>
    /// <returns>The not supported extension result.</returns>
    public static bool NotSupportedExtension(string extension)
    { return ThrowIsNotNull(Exceptions.NotSupportedExtension, extension); }
    /// <summary>
    /// Only one element.
    /// </summary>
    /// <param name="colName">The col name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The only one element result.</returns>
    public static bool OnlyOneElement(string colName, ICollection list)
    { return ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), colName, list)); }
    /// <summary>
    /// Out of range.
    /// </summary>
    /// <param name="colName">The col name.</param>
    /// <param name="col">The col.</param>
    /// <param name="indexName">The index name.</param>
    /// <param name="index">The index.</param>
    /// <returns>The out of range result.</returns>
    public static bool OutOfRange(string colName, ICollection col, string indexName, int index)
    { return ThrowIsNotNull(Exceptions.OutOfRange(FullNameOfExecutedCode(), colName, col, indexName, index)); }
    /// <summary>
    /// Passed list instead of array t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="variableName">The variable name.</param>
    /// <param name="values">The values.</param>
    /// <param name="CA_IsListStringWrappedInArray">The CA is list string wrapped in array.</param>
    /// <returns>The passed list instead of array t result.</returns>
    public static bool PassedListInsteadOfArray<T>(
        string variableName,
        T[] values,
        Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        return ThrowIsNotNull(
            Exceptions.PassedListInsteadOfArray<T>(
                FullNameOfExecutedCode(),
                variableName,
                values.ToList(),
                CA_IsListStringWrappedInArray));
    }
    /// <summary>
    /// Repeat after time x times failed.
    /// </summary>
    /// <param name="times">The times.</param>
    /// <param name="timeoutInMs">The timeout in ms.</param>
    /// <param name="address">The address.</param>
    /// <param name="sharedAlgorithmSlastError">The shared algorithm slast error.</param>
    /// <returns>The repeat after time x times failed result.</returns>
    public static bool RepeatAfterTimeXTimesFailed(
        int times,
        int timeoutInMs,
        string address,
        int sharedAlgorithmSlastError)
    {
        return ThrowIsNotNull(
            Exceptions.RepeatAfterTimeXTimesFailed(
                FullNameOfExecutedCode(),
                times,
                timeoutInMs,
                address,
                sharedAlgorithmSlastError));
    }

    /// <summary>
    /// Start is higher than end.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <returns>The start is higher than end result.</returns>
    public static bool StartIsHigherThanEnd(int start, int end)
    { return ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(), start, end)); }
    /// <summary>
    /// String contains un allowed substrings.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="unallowedStrings">The unallowed strings.</param>
    /// <returns>The string contains un allowed substrings result.</returns>
    public static bool StringContainsUnAllowedSubstrings(string input, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(
            Exceptions.StringContainsUnallowedSubstrings(FullNameOfExecutedCode(), input, unallowedStrings));
    }

    /// <summary>
    /// Uncomment after nugets finished.
    /// </summary>
    /// <returns>The uncomment after nugets finished result.</returns>
    public static bool UncommentAfterNugetsFinished() { return Custom("Uncomment after nugets finished"); }

    /// <summary>
    /// Uri format.
    /// </summary>
    /// <param name="url">The url.</param>
    /// <param name="uhIsUri">The uh is uri.</param>
    /// <returns>The uri format result.</returns>
    public static bool UriFormat(string url, Func<string, bool> uhIsUri)
    { return ThrowIsNotNull(Exceptions.UriFormat, url, uhIsUri); }
    /// <summary>
    /// Use rlc.
    /// </summary>
    /// <returns>The use rlc result.</returns>
    public static bool UseRlc() { return ThrowIsNotNull(Exceptions.UseRlc(FullNameOfExecutedCode())); }

    /// <summary>
    /// Was already initialized.
    /// </summary>
    /// <returns>The was already initialized result.</returns>
    public static bool WasAlreadyInitialized()
    { return ThrowIsNotNull(Exceptions.WasAlreadyInitialized(FullNameOfExecutedCode())); }
    /// <summary>
    /// Was not keys handler.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="keysHandler">The keys handler.</param>
    /// <returns>The was not keys handler result.</returns>
    public static bool WasNotKeysHandler(string name, object keysHandler)
    { return ThrowIsNotNull(Exceptions.WasNotKeysHandler(FullNameOfExecutedCode(), name, keysHandler)); }
    /// <summary>
    /// Wrong extension.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="requiredExt">The required ext.</param>
    /// <returns>The wrong extension result.</returns>
    public static bool WrongExtension(string path, string requiredExt)
    { return ThrowIsNotNull(Exceptions.WrongExtension(FullNameOfExecutedCode(), path, requiredExt)); }
    /// <summary>
    /// Wrong number of elements t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="requireElements">The require elements.</param>
    /// <param name="nameCollection">The name collection.</param>
    /// <param name="collection">The collection.</param>
    /// <returns>The wrong number of elements t result.</returns>
    public static bool WrongNumberOfElements<T>(int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        return ThrowIsNotNull(
            Exceptions.WrongNumberOfElements(FullNameOfExecutedCode(), requireElements, nameCollection, collection));
    }
    /// <summary>
    /// Zero or more than one.
    /// </summary>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="list">The list.</param>
    /// <returns>The zero or more than one result.</returns>
    public static bool ZeroOrMoreThanOne(string nameOfVariable, List<string> list)
    { return ThrowIsNotNull(Exceptions.ZeroOrMoreThanOne(FullNameOfExecutedCode(), nameOfVariable, list)); }

    #region Other
    /// <summary>
    /// Full name of executed code.
    /// </summary>
    /// <returns>The full name of executed code result.</returns>
    public static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfExc = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfExc.Item1, placeOfExc.Item2, true);
        return fullName;
    }

    static string FullNameOfExecutedCode(object type, string methodName, bool fromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (fromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type type2)
        {
            typeFullName = type2.FullName ?? "Type cannot be get via type is Type type2";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type objectType = type.GetType();
            typeFullName = objectType.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throw is not null.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <returns>The throw is not null result.</returns>
    public static bool ThrowIsNotNull(string? exception, bool reallyThrow = true)
    {
        if (exception != null)
        {
            Debugger.Break();
            if (reallyThrow)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }

    #region For avoid FullNameOfExecutedCode
    /// <summary>
    /// Throw is not null.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <returns>The throw is not null result.</returns>
    public static bool ThrowIsNotNull(Exception exception, bool reallyThrow = true)
    {
        if (exception != null)
        {
            ThrowIsNotNull(exception.Message, reallyThrow);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Throw is not null a b.
    /// </summary>
    /// <param name="messageFactory">The message factory.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="message">The message.</param>
    /// <returns>The throw is not null a b result.</returns>
    public static bool ThrowIsNotNull<A, B>(Func<string, A, B, string?> messageFactory, A exception, B message)
    {
        string? exc = messageFactory(FullNameOfExecutedCode(), exception, message);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Throw is not null a.
    /// </summary>
    /// <typeparam name="A">The type A.</typeparam>
    /// <param name="messageFactory">The message factory.</param>
    /// <param name="exception">The exception.</param>
    /// <returns>The throw is not null a result.</returns>
    public static bool ThrowIsNotNull<A>(Func<string, A, string?> messageFactory, A exception)
    {
        string? exc = messageFactory(FullNameOfExecutedCode(), exception);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Throw is not null.
    /// </summary>
    /// <param name="messageFactory">The message factory.</param>
    /// <returns>The throw is not null result.</returns>
    public static bool ThrowIsNotNull(Func<string, string?> messageFactory)
    {
        string? exc = messageFactory(FullNameOfExecutedCode());
        return ThrowIsNotNull(exc);
    }

    /// <summary>Vyhodi vyjimku, pokud text v1 obsahuje nepovoleny podretezec v2.</summary>
    public static void StringContainsUnallowedSubstrings(string text, string unallowedSubstring)
    {
        StringContainsUnAllowedSubstrings(text, unallowedSubstring);
    }

    /// <summary>Vyhodi vyjimku, ze soubor fnOri ma priponu, kterou nelze zparsovat jako obrazek.</summary>
    public static void FileHasExtensionNotParseableToImageFormat(string fnOri)
    {
        FileHasExtensionNotParseAbleToImageFormat(fnOri);
    }
    #endregion
    #endregion
}