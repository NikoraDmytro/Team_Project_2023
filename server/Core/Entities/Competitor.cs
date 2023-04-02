namespace Core.Entities;

public class Competitor
{
    public int ApplicationNum { get; set; }
    public int? WeightingResult { get; set; }
    
    public int MembershipCardNum { get; set; }
    public Sportsman? Sportsman { get; set; }
    
    public string? Rank { get; set; }
    public Belt? Belt { get; set; }
    
    public int CompetitionId { get; set; }
    public Competition? Competition { get; set; }
}