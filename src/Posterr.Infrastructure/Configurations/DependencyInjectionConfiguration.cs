using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Posterr.Application.Services;
using Posterr.Domain.CommandHandlers;
using Posterr.Domain.Commands;
using Posterr.Domain.Commands.Message;
using Posterr.Domain.Interfaces;
using Posterr.Domain.Interfaces.Services;
using Posterr.Infrastructure.Data;
using Posterr.Infrastructure.Data.Context;
using Posterr.Infrastructure.Data.Repositories;
using Posterr.Infrastructure.ServiceBus;
using Posterr.Shared.Kernel.Entity;
using Posterr.Shared.Kernel.Handler;
using Posterr.Shared.Kernel.Notifications;

namespace Posterr.Infrastructure.InversionOfControl
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterData();
            services.RegisterHandlers();
            services.RegisterApplicationServices();
        }

        private static void RegisterData(this IServiceCollection services)
        {
            services.AddDbContext<PosterrContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<UserAddCommand, bool>, UserHandler>();
            services.AddScoped<IRequestHandler<MessageAddCommand, bool>, UserHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
