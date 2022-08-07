using Posterr.Shared.Kernel.Commands;

namespace Posterr.Shared.Kernel.Handler
{
    public interface IMediatorHandler
    {
        Task<TResult> SendCommandResult<TResult>(ICommandResult<TResult> command, CancellationToken cancellationToken);
        Task RaiseEvent<T>(T @event, CancellationToken cancellationToken) where T : class;
    }
}
