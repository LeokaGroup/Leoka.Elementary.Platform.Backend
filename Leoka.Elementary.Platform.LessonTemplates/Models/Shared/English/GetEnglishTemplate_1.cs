using System.Xml.Serialization;
using Leoka.Elementary.Platform.LessonTemplates.Abstractions.Base;

namespace Leoka.Elementary.Platform.LessonTemplates.Models.Shared.English;

/// <summary>
/// Общая модель шаблон_1 английского.
/// </summary>
// [Serializable]
public class GetEnglishTemplate_1 : LessonTemplate
{
    /// <summary>
    /// PK.
    /// </summary>
    public long TemplateId { get; set; }

    /// <summary>
    /// Тема урока.
    /// </summary>
    [XmlElement(IsNullable = true)]
    public string LessonTheme { get; set; }

    /// <summary>
    /// Цели и задачи урока.
    /// </summary>
    [XmlElement(IsNullable = true)]
    public string GoalsObOjectives { get; set; }

    /// <summary>
    /// Обратная связь от преподавателя по проведенному уроку.
    /// </summary>
    [XmlElement(IsNullable = true)]
    public string Feedback { get; set; }

    /// <summary>
    /// Путь к файлу трека урока (дополнительный файл к материалу урока).
    /// </summary>
    [XmlElement(IsNullable = true)]
    public string TrackFileUrl { get; set; }

    /// <summary>
    /// Название файла трека.
    /// </summary>
    [XmlElement(IsNullable = true)]
    public string TrackFileName { get; set; }

    /// <summary>
    /// Дополнительные материалы (описание).
    /// </summary>
    [XmlElement(IsNullable = true)]
    public string AdditionalMaterialsText { get; set; }

    /// <summary>
    /// Путь к файлу дополнительных материалов.
    /// </summary>
    [XmlElement(IsNullable = true)]
    public string AdditionalMaterialsUrl { get; set; }
}