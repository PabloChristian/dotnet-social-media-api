using MediatR;

namespace Posterr.Application.Posteets.Queries.GetPosteetsByUser
{
    public class GetPostByUserQuery : IRequest<PostListViewModel>
    {
        public Guid UserName { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
