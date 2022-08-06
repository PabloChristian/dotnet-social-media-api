using MediatR;

namespace Posterr.Application.Posteets.Queries.GetPosteetsList
{
    public class GetPostListQuery : IRequest<PostListViewModel>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
