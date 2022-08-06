using AutoMapper;
using Posterr.Domain.Commands;
using Posterr.Domain.Commands.Message;
using Posterr.Domain.Entity;
using Posterr.Domain.Interfaces;
using Posterr.Domain.Interfaces.Services;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Posterr.Domain.Exceptions;

namespace Posterr.Domain.CommandHandlers
{
    public class UserHandler : IRequestHandler<UserAddCommand, bool>, IRequestHandler<MessageAddCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public UserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                try
                {
                    var user = _mapper.Map<User>(request);
                    var userExisted = _userRepository.GetByExpression(x => x.UserName == request.UserName).FirstOrDefault();

                    if (userExisted != null)
                        throw new BusinessException(Properties.Resources.User_AlreadyExists);

                    await _userRepository.AddAsync(user, cancellationToken);
                    var success = await _unitOfWork.CommitAsync(cancellationToken);

                    return await Task.FromResult(success);
                }
                catch(Exception e)
                {
                    await _mediatorHandler.RaiseEvent(new DomainNotification("exception", e.Message));
                }
            }
            else
            {
                foreach (var error in request.GetErrors())
                    await _mediatorHandler.RaiseEvent(new DomainNotification(error.ErrorCode, error.ErrorMessage));
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> Handle(MessageAddCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                try
                {
                    var message = _mapper.Map<Messages>(request);
                    await _userRepository.AddAsync(message, cancellationToken);
                    var success = await _unitOfWork.CommitAsync(cancellationToken);

                    return await Task.FromResult(success);
                }
                catch (Exception e)
                {
                    await _mediatorHandler.RaiseEvent(new DomainNotification("exception", e.Message));
                }
            }
            else
            {
                foreach (var error in request.GetErrors())
                    await _mediatorHandler.RaiseEvent(new DomainNotification(error.ErrorCode, error.ErrorMessage));
            }

            return await Task.FromResult(false);
        }
    }
}
