namespace Core.Entities;

public class Judge
{
    public int MembershipCardNum { get; set; }
    
    //Every judge is a sportsman on its own
    public virtual Sportsman? Sportsman { get; set; }
    
    public int JudgeCategoryId { get; set; }
    public virtual JudgeCategory? JudgeCategory { get; set; }
}
