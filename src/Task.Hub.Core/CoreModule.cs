using Autofac;
using Task.Hub.Core.Interfaces;
using Task.Hub.Core.Services;

namespace Task.Hub.Core;

public class CoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetTaskService>().As<IGetTaskService>().InstancePerLifetimeScope();
    }
}
