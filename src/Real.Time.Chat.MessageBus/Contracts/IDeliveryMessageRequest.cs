using Posterr.Shared.Kernel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.MessageBus.Contracts
{
    public interface IDeliveryMessageRequest
    {
        Task<ApiOkReturn> DeliveryMessageAsync(MessageDto message);
    }
}
