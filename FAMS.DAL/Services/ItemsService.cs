using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.Dealer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services
{
   public class ItemsService: IItemsService
    {
        private readonly FADMSDbContext _context;

        public ItemsService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SpecificationCategory>> GetAllSpecificationCategory()
        {
            return await _context.specificationCategories.AsNoTracking().ToListAsync();
        }
    }
}
