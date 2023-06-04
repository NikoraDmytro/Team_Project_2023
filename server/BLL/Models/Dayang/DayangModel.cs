using BLL.Mappings;
using Core.Entities;

namespace BLL.Models.Dayang
{
    public class DayangModel: IMapFrom<Core.Entities.Dayang>
    {
        public int DayangId { get; set; }

        public int CompetitionId { get; set; }
        public virtual Core.Entities.Competition? Competition { get; set; }

        public virtual ICollection<JudgingStaff>? Judges { get; set; }
        public virtual ICollection<Distribution>? Distributions { get; set; }
    }
}
