using FADMS.Data.Entity.Dealer;
using FADMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.FamsDealerService.Interface
{
   public interface IITemService
    {
        Task<int> SaveItem(Item item);
        Task<IEnumerable<ItemSpecification>> GetAllItemSpecificationByitemIdandspec(int ItemId, string spec);
        Task<bool> DeleteSpecificationDetailBySpecId(int SpecId);
        Task<int> SaveItemSpecification(ItemSpecification itemSpecification);
        Task<int> SaveDealerItem(DealerItems dealerItems);
        Task<int> SaveSpecificationDetail(SpecificationDetail specificationDetail);
        Task<IEnumerable<Item>> GetAllItem();
        Task<IEnumerable<Item>> GetAllItemByDealer(int? id);
        Task<IEnumerable<ItemSpecification>> GetAllItemSpecByDealer(int? id);
        Task<int> DeleteItemById(int? id);
        Task<int> DeleteItemSpecById(int? id);
        Task<IEnumerable<Item>> GetAllItemForRequisition();
        Task<IEnumerable<SpecificationDetailViewModel>> GetAllSpecificationDetailByitemId(int itemId);
        Task<ItemHsCode> GetAllItemHsCodeByHsCode(string HsCode);
        Task<IEnumerable<ItemSpecification>> GetItemSpecNamebyItem(int ItemId);
        Task<IEnumerable<ItemSpecification>> GetItemSpecificationByitemId(int ItemId);
        Task<ItemSpecification> GetItemSpecificationById(int? id);
    }
}
