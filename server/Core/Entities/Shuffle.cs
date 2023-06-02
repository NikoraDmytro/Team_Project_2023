namespace Core.Entities;

public class Shuffle
{
    public int ShuffleId { get; set; }
    public int LapNum { get; set; }
    public int PairSerialNum { get; set; }
    
    public int CompetitorInBlueId { get; set; }
    public virtual Competitor? CompetitorInBlue { get; set; }
    
    public int? CompetitorInRedId { get; set; }
    public virtual Competitor? CompetitorInRed { get; set; }
}