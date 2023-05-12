using AutoMapper;
using BLL.Models.Club;
using Core.Entities;

namespace BLL.MappingProfiles;

public class ClubProfile: Profile
{
    public ClubProfile()
    {
        CreateMap<Club, ClubModel>();
        CreateMap<CreateClubModel, Club>();
    }
}