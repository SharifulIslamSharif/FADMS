using FADMS.Data.Entity.Dealer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.FamsDealerService.Interface
{
   public interface IItemCodeService
    {
        Task<string> GetItemCode();
        Task<IEnumerable<ItemHsCode>> GetAllItemHsCode();
    }
}
