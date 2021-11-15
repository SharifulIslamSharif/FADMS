using FADMS.Data.Entity.ArmsInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class ArmsTypeViewModel
    {
        public int armsTypeId { get; set; }
        public string ArmTypeName { get; set; }
        public string ArmTypeNameBn { get; set; }

        public IEnumerable<ArmType> armTypes { get; set; }
    }
}
