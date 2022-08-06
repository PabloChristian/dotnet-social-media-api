using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.MessageBus.Handlers
{
    public class UnhandledExceptionLogger
    {
        private readonly ILogger _logger;

        public UnhandledExceptionLogger(ILogger logger) => _logger = logger;
    }
}
