namespace Leoka.Elementary.Platform.Core.Exceptions;

/// <summary>
/// Исключение возникает, если не передали Id возраста преподавателя в анкете ученика.
/// </summary>
public class EmptyStudentMentorAgeException : Exception
{
    public EmptyStudentMentorAgeException(string account) : base($"Не передан Id возраста преподавателя у пользователя {account}")
    {
    }
}