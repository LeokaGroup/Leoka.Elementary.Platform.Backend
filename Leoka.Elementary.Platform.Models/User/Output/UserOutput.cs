using Microsoft.AspNetCore.Identity;

namespace Leoka.Elementary.Platform.Models.User.Output;

/// <summary>
/// Класс выходной модели пользователя.
/// </summary>
public class UserOutput
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime DateRegister { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }

    public string UserName { get; set; }

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
    /// Полные ФИО.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Список ошибок.
    /// </summary>
    public List<IdentityError> Errors { get; set; } = new();

    /// <summary>
    /// Флаг успешна ли регистрация.
    /// </summary>
    public bool Successed { get; set; }

    /// <summary>
    /// Флаг ошибок при регистрации.
    /// </summary>
    public bool Failure { get; set; }
}