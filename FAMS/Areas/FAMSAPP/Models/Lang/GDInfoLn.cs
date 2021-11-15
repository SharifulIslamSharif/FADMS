using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    [NotMapped]
    public class GDInfoLn
    {
        public string title { get; set; }
        public string GDreason { get; set; }
        public string GDnumber { get; set; }
        public string GDcomments { get; set; }
       
    }
}
