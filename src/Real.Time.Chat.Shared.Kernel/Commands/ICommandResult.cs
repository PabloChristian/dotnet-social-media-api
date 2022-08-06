using MediatR;

namespace Posterr.Shared.Kernel.Commands
{
    public interface ICommandResult<T> : IRequest<T>
    {
        bool IsValid();
    }
}
