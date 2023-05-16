using Core.Entities;
using Sieve.Services;

namespace BLL.Sieve.Configurations;

public class ClubSieveConfiguration: ISieveConfiguration
{
    public void Configure(SievePropertyMapper mapper)
    {
        mapper.Property<Club>(x => x.Name)
            .CanFilter()
            .CanSort();

        mapper.Property<Club>(x => x.Address)
            .CanFilter()
            .CanSort();

        mapper.Property<Club>(x => x.City)
            .CanFilter()
            .CanSort();
    }
}