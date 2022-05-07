namespace Leoka.Elementary.Platform.Models.Entities.Profile;

/// <summary>
/// Класс сопоставляется с таблицей списка элементов меню профиля пользователя Profile.ProfileMenuItems.
/// </summary>
public class ProfileMenuItemEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public int ProfileMenuId { get; set; }

    /// <summary>
    /// Ссылка действия элемента (если есть).
    /// </summary>
    public string ProfileItemUrl { get; set; }

    /// <summary>
    /// Название элемента меню.
    /// </summary>
    public string ProfileItemTitle { get; set; }

    /// <summary>
    /// Системное название элемента меню.
    /// </summary>
    public string ProfileItemSysName { get; set; }

    /// <summary>
    /// Позиция в списке.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Id роли.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Выделить ли элемент меню.
    /// </summary>
    public bool IsSelectItem { get; set; }

    /// <summary>
    /// Тип меню.
    /// 1 - левое.
    /// 2 - меню хидера.
    /// 3 - меню, которое выпадает у профиля.
    /// </summary>
    public int MenuType { get; set; }

    /// <summary>
    /// Путь к изображению иконки.
    /// </summary>
    public string IconUrl { get; set; }

    /// <summary>
    /// Отображать ли баланс.
    /// </summary>
    public bool IsVisibleBalance { get; set; }

    /// <summary>
    /// Является ли элемент выпадающим списком.
    /// </summary>
    public bool IsDropdown { get; set; }
}