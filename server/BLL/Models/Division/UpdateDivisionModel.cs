using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Division
{
    public class UpdateDivisionModel
    {
        public string? Name { get; set; }
        public int? MinWeight { get; set; }
        public int? MaxWeight { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Sex Sex { get; set; }
        public int MinBeltId { get; set; }
        public virtual Core.Entities.Belt? MinBelt { get; set; }
        public int MaxBeltId { get; set; }
        public virtual Core.Entities.Belt? MaxBelt { get; set; }
    }
}
