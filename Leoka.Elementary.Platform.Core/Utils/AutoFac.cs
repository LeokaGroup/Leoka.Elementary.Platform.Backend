using System.Reflection;
using Autofac;
using Leoka.Elementary.Platform.Core.Attributes;
using Module = Autofac.Module;

namespace Leoka.Elementary.Platform.Core.Utils;

public static class AutoFac
{
    private static ContainerBuilder _builder;
    private static IContainer _container;
    private static IEnumerable<Type> _typeModules;

    /// <summary>
    /// Инициализация контейнера
    /// </summary>
    /// <param name="containerBuilderHandler">Делегат для дополнительной инициализации контейнера</param>
    public static void Init(ContainerBuilder b)
    {
        // _builder = new ContainerBuilder();
        //
        // var assemblies1 =
        //     GetAssembliesFromApplicationBaseDirectory(x => 
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.Services"));
        //
        // var assemblies2 =
        //     GetAssembliesFromApplicationBaseDirectory(x => 
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.Mailings"));
        //
        // var assemblies3 =
        //     GetAssembliesFromApplicationBaseDirectory(x => 
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.FTP"));
        //
        // var assemblies4 =
        //     GetAssembliesFromApplicationBaseDirectory(x => 
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.Base"));
        //
        // var assemblies5 =
        //     GetAssembliesFromApplicationBaseDirectory(x =>
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.Integrations"));
        //
        // var assemblies6 =
        //     GetAssembliesFromApplicationBaseDirectory(x =>
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.Commerce"));
        //
        // var assemblies7 =
        //     GetAssembliesFromApplicationBaseDirectory(x =>
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.Messaging"));
        //
        // var assemblies8 =
        //     GetAssembliesFromApplicationBaseDirectory(x =>
        //         x.FullName.StartsWith("Leoka.Elementary.Platform.Configurator"));
        //
        // _builder.RegisterAssemblyTypes(assemblies1).AsImplementedInterfaces();
        // _builder.RegisterAssemblyTypes(assemblies2).AsImplementedInterfaces();
        // _builder.RegisterAssemblyTypes(assemblies3).AsImplementedInterfaces();
        // _builder.RegisterAssemblyTypes(assemblies4).AsImplementedInterfaces();
        // _builder.RegisterAssemblyTypes(assemblies5).AsImplementedInterfaces();
        // _builder.RegisterAssemblyTypes(assemblies6).AsImplementedInterfaces();
        // _builder.RegisterAssemblyTypes(assemblies7).AsImplementedInterfaces();
        // _builder.RegisterAssemblyTypes(assemblies8).AsImplementedInterfaces();
        //
        // var assemblies = assemblies1
        //     .Union(assemblies2)
        //     .Union(assemblies3)
        //     .Union(assemblies4)
        //     .Union(assemblies5)
        //     .Union(assemblies6)
        //     .Union(assemblies7)
        //     .Union(assemblies8);
        //
        // _typeModules = (from assembly in assemblies
        //     from type in assembly.GetTypes()
        //     where type.IsClass && type.GetCustomAttribute<CommonModuleAttribute>() != null
        //     select type).ToArray();
        //
        // containerBuilderHandler?.Invoke(_builder);
        //
        // foreach (var module in _typeModules)
        // {
        //     _builder.RegisterModule(Activator.CreateInstance(module) as Module);
        // }
        //
        // _container = _builder.Build();
        //
        // return _container;
        
        var assemblies1 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x => 
                x.FullName.StartsWith("Leoka.Elementary.Platform.Services"));

        var assemblies2 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x => 
                x.FullName.StartsWith("Leoka.Elementary.Platform.Mailings"));

        var assemblies3 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x => 
                x.FullName.StartsWith("Leoka.Elementary.Platform.FTP"));

        var assemblies4 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x => 
                x.FullName.StartsWith("Leoka.Elementary.Platform.Base"));

        var assemblies5 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Integrations"));

        var assemblies6 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Commerce"));

        var assemblies7 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Messaging"));

        var assemblies8 =
            AutoFac.GetAssembliesFromApplicationBaseDirectory(x =>
                x.FullName.StartsWith("Leoka.Elementary.Platform.Configurator"));

        b.RegisterAssemblyTypes(assemblies1).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies2).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies3).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies4).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies5).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies6).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies7).AsImplementedInterfaces();
        b.RegisterAssemblyTypes(assemblies8).AsImplementedInterfaces();

        var assemblies = assemblies1
            .Union(assemblies2)
            .Union(assemblies3)
            .Union(assemblies4)
            .Union(assemblies5)
            .Union(assemblies6)
            .Union(assemblies7)
            .Union(assemblies8);

        _typeModules = (from assembly in assemblies
            from type in assembly.GetTypes()
            where type.IsClass && type.GetCustomAttribute<CommonModuleAttribute>() != null
            select type).ToArray();

        // containerBuilderHandler?.Invoke(b);

        foreach (var module in _typeModules)
        {
            b.RegisterModule(Activator.CreateInstance(module) as Module);
        }
    }

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
            _container = _builder.Build();
        }

        if (!_container.IsRegistered<TService>())
        {
            return null;
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
}