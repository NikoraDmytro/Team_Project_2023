﻿namespace BLL.Models.Auth;

public class SignupModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Patronymic { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    // Add other required fields
}