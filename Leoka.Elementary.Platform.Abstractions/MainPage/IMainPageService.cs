﻿using Leoka.Elementary.Platform.Models.Common.Output;
using Leoka.Elementary.Platform.Models.MainPage.Output;

namespace Leoka.Elementary.Platform.Abstractions.MainPage;

/// <summary>
/// Абстракция главной страницы.
/// </summary>
public interface IMainPageService
{
    /// <summary>
    /// Метод получит список полей хидера.
    /// </summary>
    /// <returns>Список полей хидера.</returns>
    Task<IEnumerable<HeaderOutput>> GetHeaderItemsAsync();

    /// <summary>
    /// Метод получит список полей футера.
    /// </summary>
    /// <returns>Список полей футера.</returns>
    Task<IEnumerable<FooterOutput>> GetFooterItemsAsync();

    /// <summary>
    /// Метод получит данные для фона студента.
    /// </summary>
    /// <returns>Данные для фона студента.</returns>
    Task<MainFonStudentOutput> GetMainFonStudentAsync();

    /// <summary>
    /// Метод получит данные записи на урок.
    /// <param name="typeRole">Тип роли.
    /// 1 - для главной страницы ученика.
    /// 2 - для главной страницы преподавателя.</param>
    /// </summary>
    /// <returns>Данные записи на урок.</returns>
    Task<ReceptionOutput> GetReceptionAsync(int typeRole);

    /// <summary>
    /// Метод получит данные блока с чего начать.
    /// </summary>
    /// <param name="typeRole">Тип роли.</param>
    /// <returns>Данные блока.</returns>
    Task<BeginOutput> GetBeginItemsAsync(int typeRole);
    
    /// <summary>
    /// Метод получит данные для блока умного класса.
    /// </summary>
    /// <returns>Данные для блока.</returns>
    Task<SmartClassStudentOutput> GetSmartClassAsync();

    /// <summary>
    /// Метод получит данные для блока вопросов.
    /// </summary>
    /// <returns>Список вопросов с вариантами ответов.</returns>
    Task<IEnumerable<BestQuestionOutput>> GetBestQuestionsAsync();
    
    /// <summary>
    /// Метод получит данные для заголовков блока списка вопросов.
    /// </summary>
    /// <returns>Данные для заголовков блока списка вопросов.</returns>
    Task<OptionOutput> GetTitleOptionAsync();
    
    /// <summary>
    /// Метод получит данные для блока о нашей платформе.
    /// </summary>
    /// <returns>Данные блока.</returns>
    Task<AboutOutput> GetAboutAsync();

    /// <summary>
    /// Метод получит данные для блока создания заявки.
    /// </summary>
    /// <returns>Данные блока.</returns>
    Task<RequestOutput> GetRequestAsync();
    
    /// <summary>
    /// Метод получит данные блока преподавателя.
    /// </summary>
    /// <returns>Данные блока.</returns>
    Task<MentorOutput> GetMentorAsync();
    
    /// <summary>
    /// Метод получит данные для блока преподавателя на главной странице преподавателя.
    /// </summary>
    /// <returns>Данные блока преподавателя.</returns>
    Task<MainMentorOutput> GetMainMentorAsync();
}