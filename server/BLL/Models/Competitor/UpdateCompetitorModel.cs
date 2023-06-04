using Core.Entities;

namespace BLL.Models.Competitor
{
    public class UpdateCompetitorModel
    {
        public int? WeightingResult { get; set; }

        public int MembershipCardNum { get; set; }
        public Core.Entities.Sportsman? Sportsman { get; set; }

        public int BeltId { get; set; }
        public Core.Entities.Belt? Belt { get; set; }

        public int CompetitionId { get; set; }
        public virtual Competition? Competition { get; set; }
    }
}
