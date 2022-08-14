using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Posterr.Domain.Interface;
using Posterr.Domain.Interface.Repositories;
using Posterr.Infrastructure.Data;
using Posterr.Infrastructure.Data.Context;
using Posterr.Infrastructure.Data.Repositories;
using Posterr.Infrastructure.ServiceBus;
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
        }

        private static void RegisterData(this IServiceCollection services)
        {
            services.AddDbContext<PosterrContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
