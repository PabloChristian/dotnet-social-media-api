using AutoMapper;
using Posterr.Application.Posteets.Queries;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class PostEntityToViewModelMapper : Profile
    {
        public PostEntityToViewModelMapper()
        {
            CreateMap<Domain.Entity.Post, CreatePostViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Message, opt => opt.MapFrom(s => s.PostMessage))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Created));
        }
    }
}
