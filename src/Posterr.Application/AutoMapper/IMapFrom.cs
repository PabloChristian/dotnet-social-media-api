using AutoMapper;

namespace Posterr.Application.AutoMapper
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
