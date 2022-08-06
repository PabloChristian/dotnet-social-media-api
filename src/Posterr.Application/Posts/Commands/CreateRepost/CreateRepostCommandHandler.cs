using MediatR;
using Microsoft.EntityFrameworkCore;
using Posterr.Application.Common.Interfaces;
using Posterr.Domain.Entities;
using Posterr.Domain.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Posterr.Application.Posteets.Commands.CreateReposteet
{
    public class CreateRepostCommandHandler : IRequestHandler<CreateRepostCommand, int>
    {
        private readonly IPosterrDbContext _context;

        public CreateRepostCommandHandler(IPosterrDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRepostCommand request, CancellationToken cancellationToken)
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
                UserName = request.UserName,
                ReposteetId = request.PosteetId,
            };

            _context.Posteets.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.PosteetId;
        }
    }
}
