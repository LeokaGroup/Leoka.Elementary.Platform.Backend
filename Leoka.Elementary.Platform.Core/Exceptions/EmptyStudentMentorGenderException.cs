namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не передали Id пола преподавателя в анкете ученика.
/// </summary>
public class EmptyStudentMentorGenderException : Exception
{
    public EmptyStudentMentorGenderException(string account) : base($"Не передан Id пола преподавателя у пользователя {account}")
    {
    }
}