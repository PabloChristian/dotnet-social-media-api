using AutoMapper;
using Posterr.Domain.ViewModel.Post;

namespace Posterr.Application.AutoMapper.Mappers
{
    public class PostEntityToCreatePostViewModelMapper : Profile
    {
        public PostEntityToCreatePostViewModelMapper()
        {
            CreateMap<Domain.Entity.Post, CreatePostViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.PostMessage, opt => opt.MapFrom(s => s.PostMessage))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created));
        }
    }
}
