using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class DBApproveLN
    {
        [Key]
        public string employeeId { get; set; }
        public string health { get; set; }
        public string role { get; set; }
        public string training { get; set; }

        public string healthF { get; set; }
        public string roleF { get; set; }
        public string trainingF { get; set; }
        public string preservation { get; set; }
        public string liferisk { get; set; }
      
       public string behave { get; set; }
        public string behaveF { get; set; }
        public string policreco { get; set; }
        public string megistratreco { get; set; }
        public string comments { get; set; }
        public string canprovidelicense { get; set; }




    }
}
