using BLL.Mappings;
using AutoMapper;

namespace BLL.Models.Division
{
    public class DivisionModel: IMapFrom<Core.Entities.Division>
    {
        public int DivisionId { get; set; }
        public string? Name { get; set; }
        public int? MinWeight { get; set; }
        public int? MaxWeight { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string? Sex { get; set; }
        public string MinBelt { get; set; }
        public string MaxBelt { get; set; }

        public void MapFrom(Profile profile)
        {
            profile.CreateMap<Core.Entities.Division, DivisionModel>()
                .ForMember(dest => dest.Sex, src => src.MapFrom(opt => opt.Sex == Core.Entities.Sex.M ? "Ч" : "Ж"))
                .ForMember(dest => dest.MinBelt, src => src.MapFrom(opt => opt.MinBelt.Rank))
                .ForMember(dest => dest.MaxBelt, src => src.MapFrom(opt => opt.MaxBelt.Rank));
        }
    }
}
