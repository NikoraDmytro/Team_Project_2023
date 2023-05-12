using BLL.Mappings;

namespace BLL.Models.User;

public class UserModel: IMap<Core.Entities.User>
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
}