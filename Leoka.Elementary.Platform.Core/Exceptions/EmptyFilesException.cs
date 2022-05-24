namespace Leoka.Elementary.Platform.Core.Exceptions;

public class EmptyFilesException : Exception
{
    public EmptyFilesException() : base("Не переданы файлы!")
    {
    }
}