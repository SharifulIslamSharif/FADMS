using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
    public class ReportVm
    {
        public int? Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? DealerId { get; set; }
        public int? SupplierId { get; set; }
        public int? PersonalInfosId { get; set; }
        public int? OrganizationInfosId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemCategoryId { get; set; }
    }
}
