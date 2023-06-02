namespace Core.Entities;

public class JudgingStaff
{
    public int ApplicationNum { get; set; }
    
    public int DayangId { get; set; }
    public virtual Dayang? Dayang { get; set; }

    public int MembershipCardNum { get; set; }
    public virtual Judge? Judge { get; set; }
    
    public int JudgeRoleId { get; set; }
    public virtual JudgeRole? JudgeRole { get; set; }
}