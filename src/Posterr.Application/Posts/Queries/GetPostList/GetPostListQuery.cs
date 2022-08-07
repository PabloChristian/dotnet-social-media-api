using MediatR;

namespace Posterr.Application.Posteets.Queries.GetPostList
{
    public class GetPostListQuery : IRequest<PostListViewModel>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
