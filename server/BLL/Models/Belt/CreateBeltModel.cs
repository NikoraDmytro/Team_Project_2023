using BLL.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Belt
{
    public class CreateBeltModel: IMapTo<Core.Entities.Belt>
    {
        public int Id { get; set; }
    }
}
