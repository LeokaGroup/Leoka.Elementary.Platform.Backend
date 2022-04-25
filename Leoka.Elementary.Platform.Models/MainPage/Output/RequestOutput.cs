namespace Leoka.Elementary.Platform.Models.MainPage.Output;

/// <summary>
/// Класс выходной модели создания заявки.
/// </summary>
public class RequestOutput
{
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