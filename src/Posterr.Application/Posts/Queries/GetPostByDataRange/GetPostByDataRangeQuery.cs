using MediatR;
using Posterr.Domain.ViewModel.Post;
using System;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByDataRange
{
    public class GetPostByDataRangeQuery : IRequest<PostListViewModel>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
