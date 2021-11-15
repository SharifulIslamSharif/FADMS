using FADMS.DAL.FamsDealerService.Interface;
using FADMS.Data;
using FADMS.Data.Entity.Dealer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.FamsDealerService
{
    public class ItemCodeService:IItemCodeService
    {
        private readonly FADMSDbContext _context;

        public ItemCodeService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<string> GetItemCode()
        {
            var data = await _context.itemCodeViewModels.FromSql(@"getitemcode").AsNoTracking().ToListAsync();
            return data.FirstOrDefault().itemCode;
        }

        public async Task<IEnumerable<ItemHsCode>> GetAllItemHsCode()
        {
            return await _context.itemHsCodes.Include(x => x.taxYear).Include(x => x.vatCategory).Include(x => x.vatTable).Include(x => x.vATSchedule).AsNoTracking().ToListAsync();
        }
    }
}
