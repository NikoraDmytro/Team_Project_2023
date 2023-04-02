namespace Core.Entities;

public class Dayang
{
    public int DayangId { get; set; }

    public int CompetitionId { get; set; }
    public Competition? Competition { get; set; }
    
    public ICollection<JudgingStaff>? Judges { get; set; }
    public ICollection<Distribution>? Distributions { get; set; }
}