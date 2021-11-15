using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
   public class SpGetAllThanaViewModel
    {
        public int?  Id { get; set; } 

        public int? districtId { get; set; }

        public int? rangeMetroId { get; set; }

        public string thanaCode { get; set; }

        public string thanaName { get; set; }

        public string thanaNameBn { get; set; }

        public string shortName { get; set; }

        public string isActive { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }
    }
}
