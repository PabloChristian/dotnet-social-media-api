using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Posterr.Application.Post.Commands.CreatePost;
using Posterr.Application.Post.Commands.CreateQuote;
using Posterr.Application.Post.Queries.GetPostByUser;
using Posterr.Application.Post.Queries.GetPostList;
using Posterr.Application.Posteets.Commands.CreateReposteet;
using Posterr.Application.Posteets.Queries.GetPosteetsByDataRange;
using Posterr.Application.Posts.Commands.CreateQuote;
using Posterr.Application.Posts.Commands.CreateRepost;
using Posterr.Application.Users.Queries;
using Posterr.Application.Users.Queries.GetUser;
using Posterr.Application.Users.Queries.GetUsersList;
using Posterr.Domain.Interface;
using Posterr.Domain.Interface.Repositories;
using Posterr.Domain.ViewModel.Post;
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

            /*
            #region Query Handlers
            services.AddScoped<IRequestHandler<GetPostByDataRangeQuery, PostListViewModel>, GetPostByDataRangeQueryHandler>();
            services.AddScoped<IRequestHandler<GetPostByUserQuery, PostListViewModel>, GetPostByUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetPostListQuery, PostListViewModel>, GetPostListQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserQuery, UserDto>, GetUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetUsersListQuery, UsersListDto>, GetUsersListQueryHandler>();
            #endregion

            #region Command Handlers
            services.AddScoped< IRequestHandler<CreatePostCommand, CreatePostViewModel>, CreatePostCommandHandler>();
            services.AddScoped< IRequestHandler<CreateQuoteCommand, CreatePostViewModel>, CreateQuoteCommandHandler>();
            services.AddScoped< IRequestHandler<CreateRepostCommand, CreatePostViewModel>, CreateRepostCommandHandler>();
            #endregion
            */
        }
    }
}
