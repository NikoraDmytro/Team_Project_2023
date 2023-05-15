﻿namespace Core.Entities;

public class Competition
{
    public int CompetitionId { get; set; }
    public string? Name { get; set; }
    public DateTime? WeightingDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? City { get; set; }
    
    public int CompetitionLevelId { get; set; }
    public CompetitionLevel? CompetitionLevel { get; set; }
    
    public int CompetitionStatusId { get; set; }
    public CompetitionStatus? CompetitionStatus { get; set; }
    
    public ICollection<Competitor>? Competitors { get; set; }
    public ICollection<Dayang>? Dayangs { get; set; }
}