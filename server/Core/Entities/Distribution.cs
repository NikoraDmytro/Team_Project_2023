namespace Core.Entities;

public class Distribution
{
    public int DistributionId { get; set; }
    public int SerialNum { get; set; }
    
    public int DayangId { get; set; }
    public virtual Dayang? Dayang { get; set; }
    
    public int DivisionId { get; set; }
    public virtual Division? Division { get; set; }
}