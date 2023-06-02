namespace Core.Entities;

public class Dayang
{
    public int DayangId { get; set; }

    public int CompetitionId { get; set; }
    public virtual Competition? Competition { get; set; }
    
    public virtual ICollection<JudgingStaff>? Judges { get; set; }
    public virtual ICollection<Distribution>? Distributions { get; set; }
}