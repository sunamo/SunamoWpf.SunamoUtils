namespace SunamoWpf._sunamo;

/// <summary>
/// Represents the FS get folders type.
/// </summary>
public class FSGetFolders
{
    /// <summary>
    /// Get folders every folder.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="folder">The folder.</param>
    /// <param name="mask">The mask.</param>
    /// <param name="topDirectoryOnly">The top directory only.</param>
    /// <returns>The get folders every folder result.</returns>
    public static List<string> GetFoldersEveryFolder(ILogger logger, string folder, string mask, SearchOption topDirectoryOnly)
    {
        try
        {
            return Directory.GetDirectories(folder, mask, topDirectoryOnly).ToList();
        }
        catch (Exception exception)
        {
            logger.LogError(exception.Message);
            return new List<string>();
        }
    }
    /// <summary>
    /// Get folders every folder.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="folder">The folder.</param>
    /// <returns>The get folders every folder result.</returns>
    public static List<string> GetFoldersEveryFolder(ILogger logger, string folder)
    {
        return GetFoldersEveryFolder(logger, folder, "*", SearchOption.TopDirectoryOnly);
    }
}