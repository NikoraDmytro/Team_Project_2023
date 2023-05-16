using Core.Entities;
using Sieve.Services;

namespace BLL.Sieve.Configurations;

public class SportsmanSieveConfiguration: ISieveConfiguration
{
    public void Configure(SievePropertyMapper mapper)
    {
        mapper.Property<Sportsman>(x => x.Sex)
            .CanFilter()
            .CanSort();

        mapper.Property<Sportsman>(x => x.BirthDate)
            .CanFilter()
            .CanSort();

        mapper.Property<Sportsman>(x => x.SportsCategoryId)
            .HasName("SportsCategory")
            .CanFilter()
            .CanSort();

        mapper.Property<Sportsman>(x => x.BeltId)
            .HasName("Belt")
            .CanFilter()
            .CanSort();
    }
}