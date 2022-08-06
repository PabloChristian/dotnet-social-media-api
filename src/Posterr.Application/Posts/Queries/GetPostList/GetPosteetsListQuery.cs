using MediatR;

namespace Posterr.Application.Posteets.Queries.GetPosteetsList
{
    public class GetPosteetsListQuery : IRequest<PostListDto>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
