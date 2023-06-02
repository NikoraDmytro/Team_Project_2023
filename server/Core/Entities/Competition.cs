namespace Core.Entities;

public class Competition
{
    public int CompetitionId { get; set; }
    public string? Name { get; set; }
    public DateTime? WeightingDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? City { get; set; }
    
    public int CompetitionLevelId { get; set; }
    public virtual CompetitionLevel? CompetitionLevel { get; set; }
    
    public int CompetitionStatusId { get; set; }
    public virtual CompetitionStatus? CompetitionStatus { get; set; }
    
    public virtual ICollection<Competitor>? Competitors { get; set; }
    public virtual ICollection<Dayang>? Dayangs { get; set; }
}