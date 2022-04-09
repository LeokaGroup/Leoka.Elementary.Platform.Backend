using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leoka.Elementary.Platform.Models.Entities.User;

/// <summary>
/// Класс сопоставляется с таблицей пользователей.
/// </summary>
[Table("Users", Schema = "dbo")]
public class UserEntity 
{
    /// <summary>
    /// PK.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    /// <summary>
    /// PK.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("UserCode", TypeName = "text")]
    public string UserCode { get; set; }

    /// <summary>
    /// Логин пользователя.
    /// </summary>
    [Column("UserName", TypeName = "varchar(150)")]
    public string UserName { get; set; }
    
    /// <summary>
    /// Email пользователя.
    /// </summary>
    [Column("Email", TypeName = "varchar(150)")]
    public string Email { get; set; }

    [Column("EmailConfirmed", TypeName = "bool")]
    public bool EmailConfirmed { get; set; }

    [Column("PasswordHash", TypeName = "text")]
    public string PasswordHash { get; set; }

    [Column("PhoneNumber", TypeName = "varchar(150)")]
    public string PhoneNumber { get; set; }

    [Column("PhoneNumberConfirmed", TypeName = "bool")]
    public bool PhoneNumberConfirmed { get; set; }

    [Column("LockoutEnabled", TypeName = "bool")]
    public bool LockoutEnabled { get; set; }

    [Column("LockoutEnd", TypeName = "timestamp")]
    public DateTime LockoutEnd { get; set; }

    [Column("TwoFactorEnabled", TypeName = "bool")]
    public bool TwoFactorEnabled { get; set; }
}