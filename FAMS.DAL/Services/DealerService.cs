using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services
{
    public class DealerService : IDealerService
    {
        private readonly FADMSDbContext _context;

        public DealerService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DealerAddress>> GetDealerAddresses()
        {
            return await _context.dealerAddresss
                .Include(x=>x.division)
                .Include(x=>x.district)
                .Include(x=>x.thana)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<DealerSalesViewModel>> GetDealerSalseRepo(ReportVm report)
        {
            try
            {
                var result = _context.salesInvoiceDetails
                 .Include(x => x.salesInvoiceMaster)
                 .Include(x => x.salesInvoiceMaster.dealer)
                 .Include(x => x.salesInvoiceMaster.licenseInfo.personalInfo)
                 .Include(x => x.salesInvoiceMaster.licenseInfo.organizationInfo)
                 .Include(x => x.salesInvoiceMaster.salesVatType)
                 .Include(x => x.salesInvoiceMaster.licenseInfo)
                 .Include(x => x.itemSpecification.Item)
                 .Include(x => x.itemSpecification.Item.unit)
                 .Include(x => x.itemSpecification.Item.ArmType)
                 .Select(item => new DealerSalesViewModel
                 {
                     dealerId = item.salesInvoiceMaster.dealerId,
                     personalInfoId = item.salesInvoiceMaster.licenseInfo.personalInfo.Id,
                     organizationInfoId = item.salesInvoiceMaster.licenseInfo.organizationInfo.Id,
                     salesmasterId = item.salesInvoiceMasterId,
                     salesdetailsId = item.Id,
                     armsTypeId = item.itemSpecification.Item.ArmType.Id,
                     ArmTypeName = item.itemSpecification.Item.ArmType.ArmTypeName,
                     createdAt = item.createdAt,
                     itemId = item.itemSpecification.Item.Id,
                     itemName = item.itemSpecification.Item.itemName,
                     dealerName = item.salesInvoiceMaster.dealer.dealerName,
                     invoiceNumber = item.salesInvoiceMaster.invoiceNumber,
                     invoiceDate = item.salesInvoiceMaster.invoiceDate,
                     netTotal = item.lineTotal,
                     licenseNumber = item.salesInvoiceMaster.licenseInfo.licenseNumber,
                     armsType = item.itemSpecification.Item.ArmType.ArmTypeName,
                     supplierName = (item.salesInvoiceMaster.licenseInfo.organizationInfoId == null ? item.salesInvoiceMaster.licenseInfo.personalInfo.nameEnglish : item.salesInvoiceMaster.licenseInfo.organizationInfo.name)
                 })
                  .AsNoTracking();

                if (report.DealerId > 0) {
                    result = result.Where(x => x.dealerId == report.DealerId);
                }

                if (report.PersonalInfosId > 0)
                {
                    result = result.Where(x => x.personalInfoId == report.PersonalInfosId);
                }

                if (report.OrganizationInfosId > 0)
                {
                    result = result.Where(x => x.organizationInfoId == report.OrganizationInfosId);
                }

                if (report.OrganizationInfosId > 0)
                {
                    result = result.Where(x => x.organizationInfoId == report.OrganizationInfosId);
                }

                if (report.ItemId > 0)
                {
                    result = result.Where(x => x.itemId == report.ItemId);
                }
                if (report.ItemCategoryId > 0)
                {
                    result = result.Where(x => x.armsTypeId == report.ItemCategoryId);
                }
               

                var data=await result.OrderByDescending(x => x.salesmasterId)
                    .Where(x => Convert.ToDateTime(x.createdAt).Date >= report.FromDate.Date && Convert.ToDateTime(x.createdAt).Date <= report.ToDate.Date)
                .ToListAsync();
          
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IEnumerable<DealerSalesViewModel>> GetDealerWisePurchaseRepo(ReportVm report)
        {
            try
            {
                var result = _context.purchaseOrderDetails
                 .Include(x => x.purchase)
                 .Include(x => x.purchase.dealer)
                 .Include(x => x.purchase.supplier)
                 .Include(x => x.purchase.purchaseVatType)
                 .Include(x => x.itemSpecification.Item)
                 .Include(x => x.itemSpecification.Item.ArmType)
                 .Select(item => new DealerSalesViewModel
                 {

                     purchaseMasterId = item.purchaseId,
                     purchaseDetailsId = item.Id, 

                     dealerId = item.purchase.dealerId,
                     dealerName = item.purchase.dealer.dealerName,

                     supplierId = item.purchase.supplierId,
                     supplierName = item.purchase.supplier.supplierName,

                     armsTypeId = item.itemSpecification.Item.ArmType.Id,
                     armsType = item.itemSpecification.Item.ArmType.ArmTypeName,

                     createdAt = item.createdAt,

                     itemId = item.itemSpecification.Item.Id,
                     itemName = item.itemSpecification.Item.itemName,

                     lcDate = item.purchase.lcDate,
                     poNo=item.purchase.poNo,
                     netTotal = item.purchase.totalAmount,
                    
                 })
                  .AsNoTracking();

                if (report.DealerId > 0)
                {
                    result = result.Where(x => x.dealerId == report.DealerId);
                }

                if (report.SupplierId > 0)
                {
                    result = result.Where(x => x.supplierId == report.SupplierId);
                }

                if (report.ItemId > 0)
                {
                    result = result.Where(x => x.itemId == report.ItemId);
                }
                if (report.ItemCategoryId > 0)
                {
                    result = result.Where(x => x.armsTypeId == report.ItemCategoryId);
                }


                var data = await result.OrderByDescending(x => x.purchaseMasterId)
                    .Where(x => Convert.ToDateTime(x.createdAt).Date >= report.FromDate.Date && Convert.ToDateTime(x.createdAt).Date <= report.ToDate.Date)
                .ToListAsync();

                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #region dealer dashboard       
        public async Task<int> GetDealerIdByUserName(string uName)
        {
            var userid = await _context.Users.Where(x => x.UserName == uName).Select(s => s.Id).FirstOrDefaultAsync();
            return await _context.dealers.Where(x => x.ApplicationUserId == userid).Select(x => x.Id).FirstOrDefaultAsync();
        }
        public IQueryable<SpSalesViewmodel> GetTotalSalesByArmsType(int? dealerId)
        {
            return _context.spSalesViewmodels.FromSql($"SP_DealerSelsTotalByArmsType {dealerId}" );
        }
        public IQueryable<SpPurchase> GetTotalPurchaseByArmsType(int? dealerId)
        {
            return _context.spPurchases.FromSql($"SP_DealerPurchaseTotalByArmsType {dealerId}");
        }
        #endregion

        public async Task<string> CheckDealerUniqueLiByLiNumber(string lino)
        {
            var result = await _context.dealers.Where(x => x.LicenseNumber == lino).Select(x => x.LicenseNumber).FirstOrDefaultAsync();
            if (result != null)
            {
                result = "not Unique";
                return result;
            }
            return result;
        }
    }
}
