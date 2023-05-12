using BLL.Mappings;

namespace BLL.Models.Club;

public class ClubModel: IMapFrom<Core.Entities.Club>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
}