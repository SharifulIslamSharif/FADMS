using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.Dealer.Purchase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services
{
   public class PurchaseService: IPurchaseService
    {
        private readonly FADMSDbContext _context;

        public PurchaseService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PurchaseOrderMaster>> GetPurchaseOrderMasterByPurchaseType(int? dealerID)
        {
            return await _context.purchaseOrderMasters.Include(x=>x.supplier).OrderByDescending(x => x.Id).Where(x => x.purchaseType == 1 && x.dealerId==dealerID).AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<PurchaseOrderMaster>> GetImportedPurchaseOrderMaster()
        {
            return await _context.purchaseOrderMasters.Include(x => x.supplier).Include(vT => vT.purchaseVatType).Include(x=>x.dealer).Include(x => x.country).OrderByDescending(x => x.Id).Where(x => x.purchaseType == 1).AsNoTracking().ToListAsync();
        }
        public async Task<int> GetPurchaseOrderMasterTotalByDealerId(int? id)
        {
            return await _context.purchaseOrderMasters.Where(x=>x.dealerId==id).CountAsync();
        }

        public async Task<PurchaseOrderMaster> GetPurchaseOrderMasterById(int Id)
        {
            try
            {
                var data= await _context.purchaseOrderMasters.Include(x => x.supplier).Where(x => x.Id == Id).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        public async Task<string> GetPoNoByPOMId(int? Id)
        {
            try
            {
                return await _context.purchaseOrderMasters.Where(x => x.Id == Id).Select(x=>x.poNo).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public async Task<IEnumerable<PurchaseVatType>> GetPurchaseVatType()
        {
            return await _context.purchaseVatTypes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrderMaster>> GetPurchaseOrderMaster()
        {
            return await _context.purchaseOrderMasters.AsNoTracking().Include(x => x.supplier).Include(vT => vT.purchaseVatType).OrderByDescending(x => x.Id).Where(x => x.purchaseType == 0).ToListAsync();
        }


        public async Task<int> SavePurchaseOrderMaster(PurchaseOrderMaster purchaseOrderMaster)
        {
            try
            {
                if (purchaseOrderMaster.Id != 0)
                {
                    purchaseOrderMaster.updatedBy = purchaseOrderMaster.createdBy;
                    purchaseOrderMaster.updatedAt = DateTime.Now;
                    _context.purchaseOrderMasters.Update(purchaseOrderMaster);
                }
                else
                {
                    purchaseOrderMaster.createdAt = DateTime.Now;
                    _context.purchaseOrderMasters.Add(purchaseOrderMaster);
                }

                await _context.SaveChangesAsync();
                return purchaseOrderMaster.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> DeletePurchaseOrderDetailByPOId(int poId)
        {
            _context.purchaseOrderDetails.RemoveRange(_context.purchaseOrderDetails.Where(x => x.purchaseId == poId));
            return 1 == await _context.SaveChangesAsync();
        }


        public async Task<int> SavePurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail)
        {
            try
            {
                if (purchaseOrderDetail.Id != 0)
                {
                    purchaseOrderDetail.updatedBy = purchaseOrderDetail.createdBy;
                    purchaseOrderDetail.updatedAt = DateTime.Now;
                    _context.purchaseOrderDetails.Update(purchaseOrderDetail);
                }
                else
                {
                    purchaseOrderDetail.createdAt = DateTime.Now;
                    _context.purchaseOrderDetails.Add(purchaseOrderDetail);
                }

                await _context.SaveChangesAsync();
                return purchaseOrderDetail.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<PurchaseOrderDetail> GetPurchaseOrderDetailByPOId(int poId)
        {
            return _context.purchaseOrderDetails
                .Include(x=>x.purchase)
                .Include(x=>x.itemSpecification.Item)
                .Include(x => x.itemSpecification.Item.itemHsCode)
                .Include(x => x.itemSpecification.Item.unit)
                .Where(x => x.purchaseId == poId).AsNoTracking();
        }

    }
}
