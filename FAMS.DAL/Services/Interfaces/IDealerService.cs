using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services.Interfaces
{
   public interface IDealerService
    {
        Task<IEnumerable<DealerAddress>> GetDealerAddresses();
        Task<IEnumerable<DealerSalesViewModel>> GetDealerSalseRepo(ReportVm report);
        Task<IEnumerable<DealerSalesViewModel>> GetDealerWisePurchaseRepo(ReportVm report);
        #region dealer dashboard
        Task<int> GetDealerIdByUserName(string uName);
        IQueryable<SpSalesViewmodel> GetTotalSalesByArmsType(int? dealerId);
        IQueryable<SpPurchase> GetTotalPurchaseByArmsType(int? dealerId);
        #endregion
        Task<string> CheckDealerUniqueLiByLiNumber(string lino);
    }
}
