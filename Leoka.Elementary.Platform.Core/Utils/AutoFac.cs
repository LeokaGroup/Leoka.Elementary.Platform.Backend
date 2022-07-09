﻿using System.Reflection;
using Autofac;
using AutoMapper;
using Leoka.Elementary.Platform.Core.Attributes;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Core.Mapper;
using Microsoft.EntityFrameworkCore;
using Module = Autofac.Module;

namespace Leoka.Elementary.Platform.Core.Utils;

public static class AutoFac
{
    private static ContainerBuilder _builder;
    private static IContainer _container;
    private static IEnumerable<Type> _typeModules;

    /// <summary>
    /// Метод инициализирует контейнер начальными регистрациями.
    /// </summary>
    public static void Init(ContainerBuilder b)
    {
        RegisterAllAssemblyTypes(b);
    }

    /// <summary>
    /// Метод получит все сборки для сканирования.
    /// </summary>
    /// <param name="condition">Условие сканирования, например конкретная сборка.</param>
    /// <returns>Массив сборок.</returns>
    public static Assembly[] GetAssembliesFromApplicationBaseDirectory(Func<AssemblyName, bool> condition)
    {
        var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        Func<string, bool> isAssembly = file =>
            string.Equals(Path.GetExtension(file), ".dll", StringComparison.OrdinalIgnoreCase);

        return Directory.GetFiles(baseDirectoryPath)
            .Where(isAssembly)
            .Where(f => condition(AssemblyName.GetAssemblyName(f)))
            .Select(Assembly.LoadFrom)
            .ToArray();
    }

    /// <summary>
    /// Метод сканирует все сборки и регистрирует все модули, которые найдет в них.
    /// </summary>
    /// <param name="builder">Билдер контейнера, который наполнять регистрациями.</param>
    private static void RegisterAllAssemblyTypes(ContainerBuilder b)
    {
        var assemblies1 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Services"));

        var assemblies2 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Mailings"));

        var assemblies3 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.FTP"));

        var assemblies4 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Base"));

        var assemblies5 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Integrations"));

        var assemblies6 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Commerce"));

        var assemblies7 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Messagings"));

        var assemblies8 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Configurator"));

        var assemblies9 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Access"));
        
        var assemblies10 =
            GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.LessonTemplates"));

        b.RegisterAssemblyTypes(assemblies1).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies2).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies3).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies4).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies5).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies6).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies7).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies8).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies9).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies10).AsImplementedInterfaces();

        var assemblies = assemblies1
            .Union(assemblies2)
            .Union(assemblies3)
            .Union(assemblies4)
            .Union(assemblies5)
            .Union(assemblies6)
            .Union(assemblies7)
            .Union(assemblies8)
            .Union(assemblies9)
            .Union(assemblies10);

        RegisterMapper(b);

        _typeModules = (from assembly in assemblies
            from type in assembly.GetTypes()
            where type.IsClass && type.GetCustomAttribute<CommonModuleAttribute>() != null
            select type).ToArray();

        foreach (var module in _typeModules)
        {
            b.RegisterModule(Activator.CreateInstance(module) as Module);
        }
    }

    /// <summary>
    /// Получить сервис
    /// </summary>
    /// <typeparam name="TService">Тип сервиса</typeparam>
    /// <param name="notException">Не выдавать исключение если не удалось получить объект По умолчанию false</param> 
    /// <returns>Экземпляр запрашиваемого сервиса</returns>
    public static TService Resolve<TService>() where TService : class
    {
        if (_container == null)
        {
            _builder = new ContainerBuilder();

            RegisterAllAssemblyTypes(_builder);
            RegisterDbContext(_builder);
            RegisterMapper(_builder);
            
            _container = _builder.Build();
        }

        var service = _container.Resolve<TService>();

        return service;
    }

    public static ILifetimeScope CreateLifetimeScope()
    {
        if (_container == null)
        {
            _builder = new ContainerBuilder();
            _container = _builder.Build();
        }

        RegisterAllAssemblyTypes(_builder);
        RegisterDbContext(_builder);
        RegisterMapper(_builder);

        return _container.BeginLifetimeScope();
    }

    /// <summary>
    /// Получить сервис по уникальному имени
    /// </summary>
    /// <typeparam name="TService">Экземпляр запрашиваемого сервиса</typeparam>
    /// <param name="serviceName">Уникальное имя запрашиваемого типа</param>
    /// <param name="notException">Не выдавать исключение если не удалось получить объект По умолчанию false</param>
    /// <returns></returns>
    public static TService ResolveNamedScoped<TService>(this ILifetimeScope scope, string serviceName)
        where TService : class
    {
        if (!_container.IsRegisteredWithName<TService>(serviceName))
        {
            return null;
        }

        var service = _container.ResolveNamed<TService>(serviceName);

        return service;
    }

    /// <summary>
    /// Метод регистрирует контекст БД.
    /// </summary>
    /// <param name="builder">Билдер контейнера, который наполнять регистрациями.</param>
    private static void RegisterDbContext(ContainerBuilder builder)
    {
        var optionsBuilder = new DbContextOptions<PostgreDbContext>();
        builder.RegisterType<PostgreDbContext>()
            .WithParameter("options", optionsBuilder)
            .InstancePerLifetimeScope();
    }

    private static void RegisterMapper(ContainerBuilder builder)
    {
        builder.RegisterType<MappingProfile>().As<Profile>();
        builder.Register(c => new MapperConfiguration(cfg =>
        {
            foreach (var profile in c.Resolve<IEnumerable<Profile>>())
            {
                cfg.AddProfile(profile);
            }
        })).AsSelf().SingleInstance();

        builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
    }
}