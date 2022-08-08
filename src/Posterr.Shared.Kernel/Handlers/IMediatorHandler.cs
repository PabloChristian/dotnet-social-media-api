using MediatR;
using Posterr.Shared.Kernel.Commands;

namespace Posterr.Shared.Kernel.Handler
{
    public interface IMediatorHandler
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
        Task<TResult> SendCommandResult<TResult>(ICommandResult<TResult> command, CancellationToken cancellationToken = default);
        Task RaiseEvent<T>(T @event, CancellationToken cancellationToken = default) where T : class;
    }
}
