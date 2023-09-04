using Autofac;
using System.Reflection;

namespace SampleSession.Configs
{
    public class AutofacConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(x =>
            {
                return x.Name.EndsWith("Service") ||
                 x.Name.EndsWith("Factory") ||
                 x.Name.EndsWith("Management") ||
                 x.Name.EndsWith("Module") ||
                 x.Name.EndsWith("Repos") ||
                 x.Name.EndsWith("Middleware") ||
                 x.Name.EndsWith("Resolver");
            }).AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.Load("myUtility"))
                   .Where(x =>
                   {
                       return x.Name.EndsWith("Library") ||
                              x.Name.EndsWith("Resolver");
                   }).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("myServices"))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

        }
    }
}
