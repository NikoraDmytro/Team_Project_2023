using BLL.Mappings;

namespace BLL.Models.Club;

public class CreateClubModel: IMap<Core.Entities.Club>
{
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
}