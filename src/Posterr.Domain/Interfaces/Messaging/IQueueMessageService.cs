using Posterr.Shared.Kernel.Entity;

namespace Posterr.Domain.Interfaces.Messaging
{
    public interface IQueueMessageService
    {
        Task SendMessageAsync(MessageDto messageDto);
    }
}
