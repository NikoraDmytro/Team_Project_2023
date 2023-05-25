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

        mapper.Property<Coach>(x => x.InstructorCategoryId)
            .HasName("InstructorCategory")
            .CanFilter()
            .CanSort();

        mapper.Property<Coach>(x => x.Sportsman!.Belt)
            .HasName("Belt")
            .CanFilter()
            .CanSort();

        mapper.Property<Coach>(x => x.Sportsman!.User!.FirstName)
            .HasName("FirstName")
            .CanFilter()
            .CanSort();

        mapper.Property<Coach>(x => x.Sportsman!.User!.LastName)
            .HasName("LastName")
            .CanFilter()
            .CanSort();

        mapper.Property<Coach>(x => x.Sportsman!.BirthDate)
            .HasName("BirthDate")
            .CanFilter()
            .CanSort();
    }
}