using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.DbQuery_Model
{
    public class TotalsArmsByType
    {
        public string TypeName { get; set; }
        public int? Total { get; set; }
    }

    public class TotalsArmsByTypeWithId
    {
        public int? Id { get; set; }
        public string TypeName { get; set; }
        public int? Total { get; set; }
    }
}
