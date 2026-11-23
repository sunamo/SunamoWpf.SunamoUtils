namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the FS get files type.
/// </summary>
public class FSGetFiles
{
    /// <summary>
    /// Get files every folder.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="folder">The folder.</param>
    /// <param name="mask">The mask.</param>
    /// <param name="topDirectoryOnly">The top directory only.</param>
    /// <returns>The get files every folder result.</returns>
    public static List<string> GetFilesEveryFolder(ILogger logger, string folder, string mask, SearchOption topDirectoryOnly)
    {
        try
        {
            return Directory.GetFiles(folder, mask, topDirectoryOnly).ToList();
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);
            return new List<string>();
        }
    }
    /// <summary>
    /// Get files every folder.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="folder">The folder.</param>
    /// <returns>The get files every folder result.</returns>
    public static List<string> GetFilesEveryFolder(ILogger logger, string folder)
    {
        return GetFilesEveryFolder(logger, folder, "*", SearchOption.TopDirectoryOnly);
    }
}