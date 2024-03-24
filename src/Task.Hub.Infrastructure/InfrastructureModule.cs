using Autofac;
using System.Reflection;
using MediatR;
using Task.Hub.Core;
using Task.Hub.Core.Entities.Interface;
using Task.Hub.Infrastructure.Data;
using Task.Hub.UseCases.Tasks;

namespace Task.Hub.Infrastructure;

public class InfrastructureModule : Autofac.Module
{
    private readonly List<Assembly> _assemblies = [];
    public InfrastructureModule(Assembly? callingAssembly = null)
    {
        AddToAssembliesIfNotNull(callingAssembly);
    }

    private void AddToAssembliesIfNotNull(Assembly? assembly)
    {
        if (assembly != null)
        {
            _assemblies.Add(assembly);
        }
    }
    protected override void Load(ContainerBuilder builder)
    {
        LoadAssemblies();
        RegisterDependencies(builder);
        RegisterMediatR(builder);
    }

    private void LoadAssemblies()
    {
        var coreAssembly = Assembly.GetAssembly(typeof(CoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(InfrastructureModule));
        var useCasesAssembly = Assembly.GetAssembly(typeof(TaskDTO));

        AddToAssembliesIfNotNull(coreAssembly);
        AddToAssembliesIfNotNull(infrastructureAssembly);
        AddToAssembliesIfNotNull(useCasesAssembly);
    }

    private void RegisterMediatR(ContainerBuilder builder)
    {
        builder
          .RegisterType<Mediator>()
          .As<IMediator>()
          .InstancePerLifetimeScope();


        var mediatrOpenTypes = new[]
        {
          typeof(IRequestHandler<,>),
        };

        foreach (var mediatrOpenType in mediatrOpenTypes)
        {
            builder
              .RegisterAssemblyTypes(_assemblies.ToArray())
              .AsClosedTypesOf(mediatrOpenType)
              .AsImplementedInterfaces();
        }
    }

    private void RegisterDependencies(ContainerBuilder builder)
    {
        builder.RegisterType<TaskDbContext>().As<IDbContext>().InstancePerLifetimeScope();
    }
}
