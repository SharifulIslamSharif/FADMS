using FADMS.Data.Entity.Dealer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services.Interfaces
{
   public interface IItemsService
    {
        Task<IEnumerable<SpecificationCategory>> GetAllSpecificationCategory();
    }
}
