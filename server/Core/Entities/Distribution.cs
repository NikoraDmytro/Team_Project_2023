namespace Core.Entities;

public class Distribution
{
    public int DistributionId { get; set; }
    public int SerialNum { get; set; }
    
    public int DayangId { get; set; }
    public Dayang? Dayang { get; set; }
    
    public int DivisionId { get; set; }
    public Division? Division { get; set; }
}