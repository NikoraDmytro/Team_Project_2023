using BLL.Mappings;

namespace BLL.Models.Belt;

public class BeltModel: IMapFrom<Core.Entities.Belt>
{
    public int Id { get; set; }
    public string? Rank { get; set; }
}