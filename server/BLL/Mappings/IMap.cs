using AutoMapper;

namespace BLL.Mappings;

public interface IMap<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
}