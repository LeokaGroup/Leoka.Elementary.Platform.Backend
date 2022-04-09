﻿using Leoka.Elementary.Platform.Models.User.Output;

namespace Leoka.Elementary.Platform.Abstractions.User;

/// <summary>
/// Абстракция репозитория пользователя для работы с БД.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Метод создаст нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="contactData">Контактные данные пользователя (email или телефон).</param>
    /// <param name="roleSysName">Системное название роли.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    Task<UserOutput> CreateUserAsync(string name, string contactData, string roleSysName, string password);

    /// <summary>
    /// Метод получит Id оли по ее системному имени.
    /// </summary>
    /// <param name="sysName">Системное имя роли.</param>
    /// <returns>Id роли.</returns>
    Task<int> GetRoleIdBySysNameAsync(string sysName);
    
    /// <summary>
    /// Метод авторизует пользователя.
    /// </summary>
    /// <param name="userLogin">Email или номер телефона.</param>
    /// <param name="userPassword">Пароль.</param>
    /// <returns>Данные пользователя.</returns>
    Task<ClaimOutput> SignInAsync(string userLogin, string userPassword);
}