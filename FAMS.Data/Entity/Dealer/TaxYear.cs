using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FADMS.Data.Entity.Dealer
{
    public class TaxYear:Base
    {
        public string taxYearName { get; set; }

        public string aliasName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? endDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? taxLimit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? allowablePerquisit { get; set; }
    }
}
