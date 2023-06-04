using BLL.Mappings;

namespace BLL.Models.User;

public class CreateUserModel: IMapTo<Core.Entities.User>
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
}