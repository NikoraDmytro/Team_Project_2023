using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class User: IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
}