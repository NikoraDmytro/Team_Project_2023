using BLL.Mappings;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Sportsman
{
    public class CreateSportsmanModel: IMapTo<Core.Entities.Sportsman>
    {
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public int UserId { get; set; }
        public int? CoachMembershipCardNum { get; set; }
        public int BeltId { get; set; }
        public Core.Entities.Belt? Belt { get; set; }
        public int? SportsCategoryId { get; set; }
        public SportsCategory? SportsCategory { get; set; }
    }
}
