using Posterr.Shared.Kernel.Entity;
using MassTransit;

namespace Posterr.MessageBus.Consumers
{
    public class CaptureMessageFaultConsumer : IConsumer<Fault<MessageDto>>
    {
        private readonly ILogger<CaptureMessageFaultConsumer> _logger;

        public CaptureMessageFaultConsumer(ILogger<CaptureMessageFaultConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Fault<MessageDto>> context)
        {
            _logger.LogInformation($"FAULT: Message received: {context.Message}");
            await Task.CompletedTask;
        }
    }
}
