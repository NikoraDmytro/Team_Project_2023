using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Belt
{
    public class BeltModel: IMapFrom<Core.Entities.Belt>
    {
        public int Id { get; set; }
        public string? Rank { get; set; }
    }
}
