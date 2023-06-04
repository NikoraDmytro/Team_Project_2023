using AutoMapper;
using BLL.Mappings;

namespace BLL.Models.Competition;

public class CreateCompetitionModel: IMapTo<Core.Entities.Competition>
{
    public string? Name { get; set; }
    public DateTime? WeightingDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? City { get; set; }
    public string? Status { get; set; }
    public string? Level { get; set; }
}