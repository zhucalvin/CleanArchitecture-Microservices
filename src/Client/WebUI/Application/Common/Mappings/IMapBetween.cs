using AutoMapper;

namespace Client.WebUI.Application.Common.Mappings;
public interface IMapBetween<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
        profile.CreateMap(GetType(), typeof(T));
    }
}
