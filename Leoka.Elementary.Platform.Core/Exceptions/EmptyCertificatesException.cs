namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не переданы сертификаты.
/// </summary>
public class EmptyCertificatesException : Exception
{
    public EmptyCertificatesException() : base("Не переданы сертификаты!")
    {
    }
}