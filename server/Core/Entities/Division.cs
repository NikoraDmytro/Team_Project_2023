namespace Core.Entities;

public class Division
{
    public int DivisionId { get; set; }
    public string? Name { get; set; }
    public int? MinWeight { get; set; }
    public int? MaxWeight { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public Sex Sex { get; set; }
    
    public string? MinRank { get; set; }
    public Belt? MinBelt { get; set; }
    
    public string? MaxRank { get; set; }
    public Belt? MaxBelt { get; set; }
}