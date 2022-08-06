using Posterr.Shared.Kernel.Entity;
using Polly;

namespace Posterr.MessageBus.Contracts.Implementations
{
    public class DeliveryMessageRequest : IDeliveryMessageRequest
    {
        private readonly ILogger<DeliveryMessageRequest> _logger;
        private readonly IChatService _posterrChatService;

        public DeliveryMessageRequest(ILogger<DeliveryMessageRequest> logger, IChatService posterrChatService)
        {
            _logger = logger;
            _posterrChatService = posterrChatService;
        }

        public async Task<ApiOkReturn> DeliveryMessageAsync(MessageDto message) =>
            await Policy.Handle<Exception>()
                .Or<TimeoutException>()
                .WaitAndRetryAsync(
                    3,
                    retryAttempt => TimeSpan.FromSeconds(2),
                    (exception, timeSpan, retryCount, context) =>
                    {
                        _logger.LogWarning(exception.Message + " - retrycount: " + retryCount);
                    })
                .ExecuteAsync(() => _posterrChatService.CreateApi().DeliveryMessage(message));
    }
}
