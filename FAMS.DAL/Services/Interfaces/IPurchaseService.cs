using FADMS.Data.Entity.Dealer.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services.Interfaces
{
   public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseOrderMaster>> GetPurchaseOrderMasterByPurchaseType(int? dealerID);
        Task<IEnumerable<PurchaseOrderMaster>> GetImportedPurchaseOrderMaster();
        Task<PurchaseOrderMaster> GetPurchaseOrderMasterById(int Id);
        Task<IEnumerable<PurchaseVatType>> GetPurchaseVatType();
        Task<IEnumerable<PurchaseOrderMaster>> GetPurchaseOrderMaster();
        Task<int> SavePurchaseOrderMaster(PurchaseOrderMaster purchaseOrderMaster);
        Task<bool> DeletePurchaseOrderDetailByPOId(int poId);
        Task<int> SavePurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail);
        IQueryable<PurchaseOrderDetail> GetPurchaseOrderDetailByPOId(int poId);

        Task<int> GetPurchaseOrderMasterTotalByDealerId(int? id);
        Task<string> GetPoNoByPOMId(int? Id);
    }
}
