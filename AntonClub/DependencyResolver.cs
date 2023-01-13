using OpenTools.Mediator.Abstrations;
using System.Reflection;

namespace AntonClub;

public class DependencyResolver : IDependencyResolver
{
    private readonly IServiceProvider serviceProvider;

    public DependencyResolver(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void RegisterFrom(Assembly assembly)
    {
        throw new NotImplementedException();
    }

    public IQueryHandler<TQuery, TResult> Resolve<TQuery, TResult>() where TQuery : IQuery<TResult>
    {
        using var scope = serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
    }

    public ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand
    {
        using var scope = serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
    }
    
    void IDependencyResolver.Register<TQuery, TResult, TQueryHandler>()
    {
        throw new NotImplementedException();
    }

    void IDependencyResolver.Register<TCommand, TCommandHandler>()
    {
        throw new NotImplementedException();
    }
}
