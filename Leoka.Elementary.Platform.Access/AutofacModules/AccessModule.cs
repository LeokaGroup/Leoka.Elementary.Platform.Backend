using Autofac;
using Leoka.Elementary.Platform.Access.Abstraction;
using Leoka.Elementary.Platform.Access.Service;

namespace Leoka.Elementary.Platform.Access.AutofacModules;

public class AccessModule : Module
{
    public static void InitModules(ContainerBuilder builder)
    {
        builder.RegisterType<RoleService>().Named<IRoleService>("RoleService");
        builder.RegisterType<RoleService>().As<IRoleService>();

        builder.RegisterType<RoleRepository>().Named<IRoleRepository>("RoleRepository");
        builder.RegisterType<RoleRepository>().As<IRoleRepository>();
    }
}