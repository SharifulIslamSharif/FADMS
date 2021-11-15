using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class DashboardViewModel
    {
        public int ArmId { get; set; }
        public string ArmTypeName { get; set; }
        public int Count { get; set; }

        public IEnumerable<SpSalesViewmodel> spSalesViewmodels { get; set; }
        public IEnumerable<SpPurchase> spPurchases { get; set; }
        public IEnumerable<SalesInvoiceDetail> salesInvoiceDetails { get; set; }
        public IEnumerable<DashboardArmsTypeViewModel> dashboardArmsTypeViewModels { get; set; }
        public IEnumerable<DashboardArmsTypeViewModel> dashboardPurchaseViewModels { get; set; }
    }
}
