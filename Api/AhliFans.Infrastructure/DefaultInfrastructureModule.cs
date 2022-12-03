using AhliFans.Core;
using AhliFans.Infrastructure.Data;
using AhliFans.SharedKernel.Interfaces;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using AhliFans.SharedKernel.IO;
using AhliFans.SharedKernel.IO.FileManager;
using ExtCore.FileStorage.Abstractions;
using ExtCore.FileStorage.FileSystem;
using Module = Autofac.Module;

namespace AhliFans.Infrastructure;

public class DefaultInfrastructureModule : Module
{
  private readonly bool _isDevelopment = false;
  private readonly List<Assembly> _assemblies = new();

  public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
  {
    _isDevelopment = isDevelopment;
    var coreAssembly = Assembly.GetAssembly(typeof(DefaultCoreModule));
    var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
    if (coreAssembly != null)
    {
      _assemblies.Add(coreAssembly);
    }
    if (infrastructureAssembly != null)
    {
      _assemblies.Add(infrastructureAssembly);
    }
    if (callingAssembly != null)
    {
      _assemblies.Add(callingAssembly);
    }
  }

  protected override void Load(ContainerBuilder builder)
  {
    if (_isDevelopment)
    {
      RegisterDevelopmentOnlyDependencies(builder);
    }
    else
    {
      RegisterProductionOnlyDependencies(builder);
    }
    RegisterCommonDependencies(builder);
  }

  private void RegisterCommonDependencies(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
        .As(typeof(IRepository<>))
        .As(typeof(IReadRepository<>))
        .InstancePerLifetimeScope();

    builder
        .RegisterType<Mediator>()
        .As<IMediator>()
        .InstancePerLifetimeScope();

    builder.Register<ServiceFactory>(context =>
    {
      var c = context.Resolve<IComponentContext>();
      return t => c.Resolve(t);
    });

    builder.RegisterType<FileStorage>()
      .As<IFileStorage>()
      .InstancePerDependency();

    builder.RegisterType<FileExtensionContentTypeProvider>()
      .As<IContentTypeProvider>()
      .InstancePerDependency();

    builder.RegisterType<FileManager>()
      .As<IFileManager>()
      .InstancePerDependency();

    var mediatrOpenTypes = new[]
    {
              typeof(IRequestHandler<,>),
              typeof(IRequestExceptionHandler<,,>),
              typeof(IRequestExceptionAction<,>),
              typeof(INotificationHandler<>),
          };

    foreach (var mediatrOpenType in mediatrOpenTypes)
    {
      builder
      .RegisterAssemblyTypes(_assemblies.ToArray())
      .AsClosedTypesOf(mediatrOpenType)
      .AsImplementedInterfaces();
    }

    builder.RegisterType(typeof(CustomQueryRepository))
    .As(typeof(ICustomQueryRepository))
    .InstancePerLifetimeScope();
  }

  private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
  {
    // TODO: Add development only services
  }

  private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
  {
    // TODO: Add production only services
  }

}
