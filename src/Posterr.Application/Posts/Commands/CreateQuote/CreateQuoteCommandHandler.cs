using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Domain.Interfaces;
using Posterr.Domain.Entity;
using Posterr.Domain.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Posterr.Application.Post.Commands.CreateQuote;
using Posterr.Domain.Interface;

namespace Posterr.Application.Posts.Commands.CreateQuote
{
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, int>
    {
        private readonly IUnitOfWork _context;
        private const int POSTS_PER_DAY = 5;

        public CreateQuoteCommandHandler(IUnitOfWork context) => _context = context;

        public async Task<int> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var posteetsInOneDay = _context.Posts
                .Where(p => p.UserName == request.UserName && p.Created >= today && p.Created < tomorrow)
                .AsNoTracking()
                .Count();

            if (posteetsInOneDay >= POSTS_PER_DAY)
                throw new BusinessException($"A user is not allowed to post more than \"{POSTS_PER_DAY}\" posts in one day. Total posted: ${posteetsInOneDay}");

            var entity = new Post
            {
                UserName = request.UserName,
                ReposteetId = request.PosteetId,
                Post = request.QuotePost,
            };

            _context.Posteets.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.PosteetId;
        }
    }
}
