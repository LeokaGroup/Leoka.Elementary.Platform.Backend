namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникнет, если не были заполнены обязательные поля. 
/// </summary>
public class EmptyRequiredFieldsException : Exception
{
    public EmptyRequiredFieldsException() : base("Не все обязательные поля заполнены")
    {
    }
}