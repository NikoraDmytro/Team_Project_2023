namespace Core.Entities;

public class Competition
{
    public int CompetitionId { get; set; }
    public string? Name { get; set; }
    public DateTime? WeightingDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? City { get; set; }
    public string? CompetitionLevel { get; set; }
    
    public string? CurrentStatus { get; set; }
    public CompetitionStatus? CompetitionStatus { get; set; }
    
    public ICollection<Competitor>? Competitors { get; set; }
}