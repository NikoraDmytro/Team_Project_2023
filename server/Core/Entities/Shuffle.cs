namespace Core.Entities;

public class Shuffle
{
    public int ShuffleId { get; set; }
    public int LapNum { get; set; }
    public int PairSerialNum { get; set; }
    
    public int CompetitorInBlueId { get; set; }
    public Competitor? CompetitorInBlue { get; set; }
    
    public int? CompetitorInRedId { get; set; }
    public Competitor? CompetitorInRed { get; set; }
}