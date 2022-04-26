﻿namespace Leoka.Elementary.Platform.Models.Entities.MainPage;

/// <summary>
/// Класс сопоставляется с таблицей о нашей платформе на главной странице.
/// </summary>
public class AboutPlatformEntity
{
    /// <summary>
    /// PK. 
    /// </summary>
    public int AboutId { get; set; }

    /// <summary>
    /// Главный заголовок блока.
    /// </summary>
    public string AboutTitle { get; set; }

    /// <summary>
    /// Подзаголовок блока.
    /// </summary>
    public string AboutSubTitle { get; set; }

    /// <summary>
    /// Заголовок блока ученика.
    /// </summary>
    public string AboutStudentTitle { get; set; }

    /// <summary>
    /// Подзаголовок блока ученика.
    /// </summary>
    public string AboutStudentSubTitle { get; set; }

    /// <summary>
    /// Заголовок блока преподавателя.
    /// </summary>
    public string AboutMentorTitle { get; set; }

    /// <summary>
    /// Подзаголовок блока преподавателя.
    /// </summary>
    public string AboutMentorSubTitle { get; set; }

    /// <summary>
    /// Изображение преподавателей.
    /// </summary>
    public string UrlIconMentor { get; set; }

    /// <summary>
    /// Изображение студента.
    /// </summary>
    public string UrlIconStudent { get; set; }
}