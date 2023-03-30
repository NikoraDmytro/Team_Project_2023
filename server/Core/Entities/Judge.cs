namespace Core.Entities;

public class Judge
{
    public int MembershipCardNum { get; set; }
    public string? JudgeCategory { get; set; }
    
    //Every judge is a sportsman on its own
    public Sportsman? Sportsman { get; set; }
}