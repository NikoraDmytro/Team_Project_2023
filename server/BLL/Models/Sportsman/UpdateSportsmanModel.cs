﻿namespace BLL.Models.Sportsman;

public class UpdateSportsmanModel
{
    public int MembershipCardNum { get; set; }
    public DateTime BirthDate { get; set; }
    public string Sex { get; set; }
    public string Belt { get; set; }
    public string ClubName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
}