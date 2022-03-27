namespace Leoka.Elementary.Platform.Models.User.Input;

/// <summary>
/// Класс входной модели регистрации пользователя.
/// </summary>
public class UserInput
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string SecondName { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string UserEmail { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public string UserPassword { get; set; }

    /// <summary>
    /// Роль.
    /// </summary>
    public string UserRole { get; set; }
}