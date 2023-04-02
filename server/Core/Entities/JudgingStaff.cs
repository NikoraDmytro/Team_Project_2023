namespace Core.Entities;

public class JudgingStaff
{
    public int ApplicationNum { get; set; }
    
    public int DayangId { get; set; }
    public Dayang? Dayang { get; set; }

    public int MembershipCardNum { get; set; }
    public Judge? Judge { get; set; }
    
    public string? Role { get; set; }
    public JudgeRole? JudgeRole { get; set; }
}