using BLL.Mappings;

namespace BLL.Models.Sportsman;

public class CreateSportsmanModel: IMapTo<Core.Entities.Sportsman>
{
    public string? Sex { get; set; }
    public string? User { get; set; }
    public string? Belt { get; set; }
    public string? Coach { get; set; }
}