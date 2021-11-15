using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class SBApproveLN
    {
        [Key]
        public string employeeId { get; set; }
        public string training { get; set; }
        public string liferisk { get; set; }
      
       public string crimereportF { get; set; }

        public string trainingF { get; set; }
        public string liferiskF { get; set; }

        public string crimereport { get; set; }
        public string allcertificateapprovedletter { get; set; }
        public string otherinfo { get; set; }
        public string comments { get; set; }
        public string canprovidelicense { get; set; }




    }
}
