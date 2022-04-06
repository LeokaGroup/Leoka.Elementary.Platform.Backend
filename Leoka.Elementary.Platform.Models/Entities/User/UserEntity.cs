using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Leoka.Elementary.Platform.Models.Entities.User;

/// <summary>
/// Класс сопоставляется с таблицей пользователей.
/// </summary>
[Table("Users", Schema = "dbo")]
public class UserEntity : IdentityUser
{
    /// <summary>
    /// PK.
    /// </summary>
    [Key]
    [Column("UserId", TypeName = "bigint)")]
    public long UserId { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    [Column("LastName", TypeName = "varchar(100)")]
    public string LastName { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    [Column("FirstName", TypeName = "varchar(100)")]
    public string FirstName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    [Column("SecondName", TypeName = "varchar(100)")]
    public string SecondName { get; set; }

    /// <summary>
    /// Путь к иконке пользователя.
    /// </summary>
    [Column("UserIcon", TypeName = "text")]
    public string UserIcon { get; set; }

    /// <summary>
    /// Дата регистрации пользователя.
    /// </summary>
    [Column("DateRegister", TypeName = "timestamp")]
    public DateTime DateRegister { get; set; }

    [Column("RememberMe", TypeName = "boolean")]
    public bool RememberMe { get; set; }

    /// <summary>
    /// Подписан ли пользователь на рассылку.
    /// </summary>
    [Column("IsNews", TypeName = "bool")]
    public bool IsNews { get; set; }

    /// <summary>
    /// Код подтверждения почты (Guid).
    /// </summary>
    [Column("ConfirmEmailCode", TypeName = "varchar(200)")]
    public string ConfirmEmailCode { get; set; }
}