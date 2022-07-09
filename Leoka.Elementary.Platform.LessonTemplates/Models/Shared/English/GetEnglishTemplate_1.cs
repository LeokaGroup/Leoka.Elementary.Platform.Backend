using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;

namespace Leoka.Elementary.Platform.LessonTemplates.Models.Shared.English;

/// <summary>
/// Общая модель шаблон_1 английского.
/// </summary>
internal class GetEnglishTemplate_1 : LessonTemplate
{
    /// <summary>
    /// PK.
    /// </summary>
    public long TemplateId { get; set; }

    /// <summary>
    /// Тема урока.
    /// </summary>
    public string LessonTheme { get; set; }

    /// <summary>
    /// Цели и задачи урока.
    /// </summary>
    public string GoalsObOjectives { get; set; }

    /// <summary>
    /// Обратная связь от преподавателя по проведенному уроку.
    /// </summary>
    public string Feedback { get; set; }

    /// <summary>
    /// Путь к файлу трека урока (дополнительный файл к материалу урока).
    /// </summary>
    public string TrackFileUrl { get; set; }

    /// <summary>
    /// Название файла трека.
    /// </summary>
    public string TrackFileName { get; set; }

    /// <summary>
    /// Дополнительные материалы (описание).
    /// </summary>
    public string AdditionalMaterialsText { get; set; }

    /// <summary>
    /// Путь к файлу дополнительных материалов.
    /// </summary>
    public string AdditionalMaterialsUrl { get; set; }

    /// <summary>
    /// Id пользователя.
    /// </summary>
    public long UserId { get; set; }
}