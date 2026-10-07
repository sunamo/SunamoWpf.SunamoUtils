namespace SunamoWpf._sunamo;

class TemplateLogger
{
    internal void FileDontExists(string selectedFile)
    {
        throw new NotImplementedException();
    }

    internal void FolderDontExists(string text)
    {
        throw new NotImplementedException();
    }

    internal void HaveUnallowedValue(string tbTos)
    {
        throw new NotImplementedException();
    }

    internal void MustHaveValue(string message)
    {
        throw new NotImplementedException();
    }

    internal void SuccessfullyResized(string message)
    {
        throw new NotImplementedException();
    }
}

internal class InitApp
{
    internal static TemplateLogger TemplateLogger { get; set; }
}