using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Common.Interfaces;
using Posterr.Domain.Entity;
using Posterr.Domain.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Posterr.Application.Post.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPosterrDbContext _context;

        public CreatePostCommandHandler(IPosterrDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var posteetsInOneDay = _context.Posteets
                .Where(p => p.UserName == request.UserName && p.Created >= today && p.Created < tomorrow)
                .AsNoTracking().Count();

            if (posteetsInOneDay == 5)
                throw new AdPosteetInvalidException(posteetsInOneDay);

            var entity = new Posteet
            {
                Post = request.Post,
                UserName = request.UserName
            };

            _context.Posteets.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.PosteetId;
        }
    }
}
