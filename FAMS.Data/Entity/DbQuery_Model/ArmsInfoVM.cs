using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FADMS.Data.Entity.DbQuery_Model
{
    
    public class ArmsInfoVM
    {
        public int? DId { get; set; }
        public string TypeName { get; set; }
        public string NameEng { get; set; }
        public int? Total { get; set; }
    }
}
