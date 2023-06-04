using AutoMapper;
using BLL.Mappings;

namespace BLL.Models.Sportsman;

public class CreateSportsmanModel: IMapTo<Core.Entities.Sportsman>
{
    public int MembershipCardNum { get; set; }
    public DateTime BirthDate { get; set; }
    public string Sex { get; set; }
    public string Belt { get; set; }
    public string ClubName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }

    public void MapTo(Profile profile)
    {
        profile.CreateMap<CreateSportsmanModel, Core.Entities.Sportsman>()
            .ForMember(dest => dest.Sex,
                src => src.MapFrom(opt => opt.Sex == "Ч" ? Core.Entities.Sex.M : Core.Entities.Sex.F))
            .ForMember(dest => dest.Belt, opt => opt.Ignore());
    }
}