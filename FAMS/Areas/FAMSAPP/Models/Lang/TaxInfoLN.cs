using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    [NotMapped]
    public class TaxInfoLN
    {
   
        public string title { get; set; }
        public string cheakbox { get; set; }
        public string employeeId { get; set; }
        public string taxSubmitDate { get; set; }

        public string description { get; set; }
        public string tin { get; set; }
        public string amount { get; set; }
    }
}
