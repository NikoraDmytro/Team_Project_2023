using BLL.Mappings;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Competitor
{
    public class CompetitorModel: IMapFrom<Core.Entities.Competitor>
    {
        public int ApplicationNum { get; set; }
        public int? WeightingResult { get; set; }

        public int MembershipCardNum { get; set; }
        public Core.Entities.Sportsman? Sportsman { get; set; }

        public int BeltId { get; set; }
        public Core.Entities.Belt? Belt { get; set; }

        public int CompetitionId { get; set; }
        public virtual Core.Entities.Competition? Competition { get; set; }
    }
}
