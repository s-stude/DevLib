using Autofac;
using DevLib.Infrastructure.Commands;
using JetBrains.Annotations;

namespace DevLib.Infrastructure.AutofacRegistry
{
    [UsedImplicitly]
    public class AutofacCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IComponentContext _componentContext;

        public AutofacCommandHandlerFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand
        {
            return _componentContext.Resolve<ICommandHandler<TCommand>>();
        }
    }
}