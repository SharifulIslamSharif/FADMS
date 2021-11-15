using FADMS.Data.Entity.ArmsInfo;
using System.Collections.Generic;

namespace FADMS.Areas.ArmsInfo.Models
{
    public class ArmsTypeEntryViewModel
    {
        public int id { get; set; }
        public string armsTypeName { get; set; }

        public IEnumerable<ArmType> GetArmTypes { get; set; }
    }
}
