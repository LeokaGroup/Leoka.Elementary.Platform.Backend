namespace Leoka.Elementary.Platform.Models.User.Output;

/// <summary>
/// Класс входной модели пользователя.
/// </summary>
public class UserOutput
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string UserEmail { get; set; }

    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime DateRegister { get; set; }

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
}