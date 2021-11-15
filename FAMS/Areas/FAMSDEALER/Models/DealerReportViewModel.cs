using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.Purchase;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class DealerReportViewModel
    {
        public int? Type { get; set; }
        //public DateTime FromDate { get; set; }
        //public DateTime ToDate { get; set; }
        public int? DealerId { get; set; }
        public int? SupplierId { get; set; }
        public int? PersonalInfosId { get; set; }
        public int? OrganizationInfosId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemCategoryId { get; set; }

        public DateTime? fromDdate { get; set; }
        public DateTime? toDate { get; set; }
        public Dealer dealer { get; set; }

        public IEnumerable<Supplier> suppliers { get; set; }
       
        public IEnumerable<PersonalInfo> personalInfos { get; set; }
        public IEnumerable<OrganizationInfo> organizationInfos { get; set; }
        public IEnumerable<DashboardArmsTypeViewModel> salesInvoiceDetails { get; set; }
        public IEnumerable<DashboardArmsTypeViewModel>  purchaseOrderDetails { get; set; }
        public IEnumerable<Dealer>  dealers { get; set; }
        public IEnumerable<Item>  items { get; set; }
        public IEnumerable<ArmType>  armTypes { get; set; }

        public IEnumerable<DealerSalesViewModel> salesInvoiceDetailReport { get; set; }
        public IEnumerable<DealerSalesViewModel> purchaseDetailReport { get; set; }
    }


}
