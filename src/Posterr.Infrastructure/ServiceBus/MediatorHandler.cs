﻿using MediatR;
using Posterr.Shared.Kernel.Commands;
using Posterr.Shared.Kernel.Handler;

namespace Posterr.Infrastructure.ServiceBus
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator) => _mediator = mediator;

        public Task RaiseEvent<T>(T @event) where T : class => _mediator.Publish(@event);
        public async Task<TResult> SendCommandResult<TResult>(ICommandResult<TResult> command) => await _mediator.Send(command);
    }
}