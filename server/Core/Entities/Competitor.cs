namespace Core.Entities;

public class Competitor
{
    public int ApplicationNum { get; set; }
    public int? WeightingResult { get; set; }
    
    public int MembershipCardNum { get; set; }
    public virtual Sportsman? Sportsman { get; set; }
    
    public int BeltId { get; set; }
    public virtual Belt? Belt { get; set; }
    
    public int CompetitionId { get; set; }
    public virtual Competition? Competition { get; set; }
}