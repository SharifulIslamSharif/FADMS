using FADMS.DAL.FamsDealerService.Interface;
using FADMS.Data;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.FamsDealerService
{
    public class ItemService : IITemService
    {
        private readonly FADMSDbContext _context;

        public ItemService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveItem(Item item)
        {
            try
            {
                if (item.Id != 0) { _context.items.Update(item); }
                else { _context.items.Add(item); }
                await _context.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public async Task<IEnumerable<ItemSpecification>> GetAllItemSpecificationByitemIdandspec(int ItemId, string spec)
        {
            return await _context.itemSpecifications.AsNoTracking().Where(x => x.itemId == ItemId && x.specificationName == spec).ToListAsync();
        }

        public async Task<bool> DeleteSpecificationDetailBySpecId(int SpecId)
        {
            _context.specificationDetails.RemoveRange(_context.specificationDetails.Where(x => x.itemSpecificationId == SpecId));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<int> SaveItemSpecification(ItemSpecification itemSpecification)
        {
            try
            {
                if (itemSpecification.Id != 0)
                    _context.itemSpecifications.Update(itemSpecification);
                else
                    _context.itemSpecifications.Add(itemSpecification);
                await _context.SaveChangesAsync();
                return itemSpecification.Id;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<DealerItems>> GetDealerItemByitemId(int? itemId)
        {
            return await _context.dealerItems.Where(x => x.ItemId == itemId).AsNoTracking().ToListAsync();
        }

        public async Task<int> SaveDealerItem(DealerItems dealerItems)
        {
            try
            {
                if (dealerItems.Id != 0)
                    _context.dealerItems.Update(dealerItems);
                else
                    _context.dealerItems.Add(dealerItems);
                await _context.SaveChangesAsync();
                return dealerItems.Id;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveSpecificationDetail(SpecificationDetail specificationDetail)
        {
            if (specificationDetail.Id != 0)
                _context.specificationDetails.Update(specificationDetail);
            else
                _context.specificationDetails.Add(specificationDetail);
            await _context.SaveChangesAsync();
            return specificationDetail.Id;


        }

        public async Task<IEnumerable<Item>> GetAllItem()
        {
            return await _context.items.Include(a => a.ArmType).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Item>> GetAllItemByDealer(int? id)
        {
            return await _context.items.Include(x=>x.ArmType).Where(x=>x.DealerId== id).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<ItemSpecification>> GetAllItemSpecByDealer(int? id)
        {
            return await _context.itemSpecifications.Include(x=>x.ArmType).Where(x=>x.DealerId== id).AsNoTracking().ToListAsync();
        }
        public async Task<int> DeleteItemById(int? id)
        {
            try
            {
                var item = await _context.items.Where(x => x.Id == id).FirstOrDefaultAsync();
                var spec = await _context.itemSpecifications.Where(x => x.Id == id).FirstOrDefaultAsync();
                _context.itemSpecifications.Remove(spec);
                _context.items.Remove(item);
                await _context.SaveChangesAsync();
                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> DeleteItemSpecById(int? id)
        {
            try
            {
                var spec = await _context.itemSpecifications.Where(x => x.Id == id).FirstOrDefaultAsync();
                var item = await _context.items.Where(x => x.Id == spec.itemId).FirstOrDefaultAsync();
                _context.itemSpecifications.Remove(spec);
                _context.items.Remove(item);
                await _context.SaveChangesAsync();
                return spec.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Item>> GetAllItemForRequisition()
        {
            List<Item> ItemgetList = new List<Item>();
            ItemgetList = await _context.items.Include(a => a.unit).Include(a => a.itemHsCode).AsNoTracking().ToListAsync();
            return ItemgetList;
        }
       

        public async Task<IEnumerable<SpecificationDetailViewModel>> GetAllSpecificationDetailByitemId(int itemId)
        {
            // int specid = 0;
            List<SpecificationDetailViewModel> data = new List<SpecificationDetailViewModel>();
            IEnumerable<SpecificationDetail> specificationDetails = _context.specificationDetails.Where(x => x.itemSpecification.itemId == itemId).Include(x => x.itemSpecification);



            IQueryable<SpecificationDetailViewModel> result = from sd in _context.specificationDetails
                                                              join i in _context.itemSpecifications on sd.itemSpecificationId equals i.Id
                                                              join c in _context.specificationCategories on sd.specificationCategoryId equals c.Id
                                                              where i.itemId == itemId
                                                              select new SpecificationDetailViewModel
                                                              {
                                                                  Id = sd.Id,
                                                                  specificationName = i.specificationName,
                                                                  specificationCategoryName = c.specificationCategoryName,
                                                                  specificationCategoryId = sd.specificationCategoryId,
                                                                  value = sd.value

                                                              };

            return await result.ToListAsync();
            //return data.Distinct().ToList();//.ToListAsync();

        }

        public async Task<ItemHsCode> GetAllItemHsCodeByHsCode(string HsCode)
        {
            return await _context.itemHsCodes.Include(x => x.taxYear).Include(x => x.vatCategory).Include(x => x.vatTable).Include(x => x.vATSchedule).Where(x => x.hsCode == HsCode).AsNoTracking().FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<ItemSpecification>> GetItemSpecNamebyItem(int ItemId)
        {
            List<ItemSpecification> data = new List<ItemSpecification>();
            IEnumerable<ItemSpecification> specificationDetails = await _context.itemSpecifications.Where(x => x.itemId == ItemId).ToListAsync();
            foreach (ItemSpecification spec in specificationDetails)
            {
                data.Add(new ItemSpecification
                {
                    Id = spec.Id,
                    specificationName = spec.specificationName

                });
            }
            return data.ToList();
        }

        public async Task<IEnumerable<ItemSpecification>> GetItemSpecificationByitemId(int ItemId)
        {
            return await _context.itemSpecifications.Include(x => x.Item).Where(x => x.itemId == ItemId).AsNoTracking().ToListAsync();
            //var result = await (from s in _context.itemSpecifications
            //                    join i in _context.items on s.itemId equals i.Id
            //                    join u in _context.units on i.unitId equals u.Id
            //                    where s.itemId == ItemId

            //                    select new ItemSpecification
            //                    {
            //                        Id = s.Id,
            //                        itemId=i.Id,
            //                        specificationName = s.specificationName,
            //                        unitName = u.unitName
            //                    }).ToListAsync();
            //return result;
        }
        public async Task<ItemSpecification> GetItemSpecificationById(int? id)
        {
            return await _context.itemSpecifications.Include(x => x.ArmType).Where(x => x.Id == id).FirstOrDefaultAsync();
            
        }

    }
}
