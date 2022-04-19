namespace Leoka.Elementary.Platform.Models.Entities.Request;

/// <summary>
/// Класс сопоставляется с таблицей заявок.
/// </summary>
public class RequestEntity
{
    /// <summary>
    /// PK.
    /// </summary>
    public long RequestId { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string RequestFirstName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string RequestLastName { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string RequestEmail { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string RequestPhoneNumber { get; set; }

    /// <summary>
    /// Сообщение заявки.
    /// </summary>
    public string RequestMessage { get; set; }

    /// <summary>
    /// Текст кнопки.
    /// </summary>
    public string RequestButtonText { get; set; }

    /// <summary>
    /// Заголовок заявки.
    /// </summary>
    public string RequestTitle { get; set; }

    /// <summary>
    /// Подзаголовок заявки.
    /// </summary>
    public string RequestSubTitle { get; set; }
}