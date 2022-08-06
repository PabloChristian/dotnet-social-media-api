using MediatR;
using System;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByDataRange
{
    public class GetPosteetsByDataRangeQuery : IRequest<PostListDto>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
