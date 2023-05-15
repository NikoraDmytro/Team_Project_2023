using Core.Entities;
using Sieve.Services;

namespace BLL.Sieve.Configurations;

public class CoachSieveConfiguration: ISieveConfiguration
{
    public void Configure(SievePropertyMapper mapper)
    {
        mapper.Property<Coach>(x => x.Phone)
            .CanFilter()
            .CanSort();

        mapper.Property<Coach>(x => x.InstructorCategory!.Name)
            .HasName("InstructorCategory")
            .CanFilter()
            .CanSort();
    }
}