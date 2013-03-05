namespace DevLib.Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}