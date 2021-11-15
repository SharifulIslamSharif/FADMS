using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services
{
   public class SalesService: ISalesService
    {
        private readonly FADMSDbContext _context;

        public SalesService(FADMSDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SalesInvoiceMaster>> GetAllSalesInvoiceMaster()
        {
            return await _context.salesInvoiceMasters.Include(x=>x.salesVatType).Include(x =>x.licenseInfo).OrderByDescending(x => x.Id).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<SalesInvoiceMaster>> GetAllSalesInvoiceMasterbyDealer(int? did)
        {
            return await _context.salesInvoiceMasters.Where(x=>x.dealerId==did).AsNoTracking().OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceMasterAndDetalis()
        {
            return await _context.salesInvoiceDetails
                .Include(x => x.salesInvoiceMaster)
                .Include(x => x.salesInvoiceMaster.salesVatType)
                .Include(x => x.salesInvoiceMaster.licenseInfo)
                .Include(x => x.itemSpecification.Item)
                .Include(x => x.itemSpecification.Item.unit)
                 .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceMasterAndDetalisByDealer(int? dId)
        {
            return await _context.salesInvoiceDetails
                .Include(x => x.salesInvoiceMaster)
                .Include(x => x.salesInvoiceMaster.salesVatType)
                .Include(x => x.salesInvoiceMaster.licenseInfo)
                .Include(x => x.itemSpecification.Item)
                .Include(x => x.itemSpecification.Item.unit)
                .Where(x=>x.salesInvoiceMaster.dealerId==dId).OrderByDescending(x => x.Id).AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceMasterAndDetalisByAllDealers()
        {
            return await _context.salesInvoiceDetails
                .Include(x => x.salesInvoiceMaster)
                .Include(x => x.salesInvoiceMaster.salesVatType)
                .Include(x => x.salesInvoiceMaster.licenseInfo)
                .Include(x=>x.salesInvoiceMaster.dealer)
                .Include(x => x.itemSpecification.Item)
                .Include(x => x.itemSpecification.Item.unit)
                .OrderByDescending(x => x.salesInvoiceMaster.dealerId).AsNoTracking().ToListAsync();
        }


        public async Task<IEnumerable<DashboardArmsTypeViewModel>> GetAllSalesInvoiceItemDetalis(int id)
        {
            try
            {
                var result = await _context.salesInvoiceDetails
               .Include(x => x.salesInvoiceMaster)
               .Include(x => x.salesInvoiceMaster.licenseInfo)
               .Include(x => x.salesInvoiceMaster.dealer)
               .Include(x => x.salesInvoiceMaster.licenseInfo.personalInfo)
               .Include(x => x.salesInvoiceMaster.licenseInfo.organizationInfo)
               .Include(x => x.itemSpecification.Item)
               .Include(x => x.itemSpecification.Item.ArmType)
               .Where(x => x.itemSpecification.Item.ArmTypeId == id)
               .AsNoTracking()
               .OrderByDescending
               (x => x.Id)
               .ToListAsync();

                List<DashboardArmsTypeViewModel> data = new List<DashboardArmsTypeViewModel>();

                foreach (var item in result)
                {
                    data.Add(new DashboardArmsTypeViewModel
                    {
                        salesmasterId = item.salesInvoiceMasterId,
                        salesdetailsId = item.Id,
                        itemName = item.itemSpecification.Item.itemName,
                        dealerName = item.salesInvoiceMaster.dealer.dealerName,
                        invoiceNumber = item.salesInvoiceMaster.invoiceNumber,
                        invoiceDate = item.salesInvoiceMaster.invoiceDate,
                        netTotal = item.lineTotal,
                        licenseNumber = item.salesInvoiceMaster.licenseInfo.licenseNumber,
                        armsType = item.itemSpecification.Item.ArmType.ArmTypeName,
                        supplierName = (item.salesInvoiceMaster.licenseInfo.organizationInfoId == null ? item.salesInvoiceMaster.licenseInfo.personalInfo.nameEnglish : item.salesInvoiceMaster.licenseInfo.organizationInfo.name)
                    });
                }

                return data;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
           
        }

   public async Task<IEnumerable<DashboardArmsTypeViewModel>> GetDealersSalesInvoiceItemDetalis(int id,int dealerid)
        {
            try
            {
                var result = await _context.salesInvoiceDetails
               .Include(x => x.salesInvoiceMaster)
               .Include(x => x.salesInvoiceMaster.licenseInfo)
               .Include(x => x.salesInvoiceMaster.dealer)
               .Include(x => x.salesInvoiceMaster.licenseInfo.personalInfo)
               .Include(x => x.salesInvoiceMaster.licenseInfo.organizationInfo)
               .Include(x => x.itemSpecification.Item)
               .Include(x => x.itemSpecification.Item.ArmType)            
               .Where(x => x.itemSpecification.Item.ArmTypeId == id && x.salesInvoiceMaster.dealerId==dealerid)
               .AsNoTracking()
               .OrderByDescending
               (x => x.Id)
               .ToListAsync();

                List<DashboardArmsTypeViewModel> data = new List<DashboardArmsTypeViewModel>();

                foreach (var item in result)
                {
                    data.Add(new DashboardArmsTypeViewModel
                    {
                        salesmasterId = item.salesInvoiceMasterId,
                        salesdetailsId = item.Id,
                        itemName = item.itemSpecification.Item.itemName,
                        dealerName = item.salesInvoiceMaster.dealer.dealerName,
                        invoiceNumber = item.salesInvoiceMaster.invoiceNumber,
                        invoiceDate = item.salesInvoiceMaster.invoiceDate,
                        netTotal = item.lineTotal,
                        licenseNumber = item.salesInvoiceMaster.licenseInfo.licenseNumber,
                        armsType = item.itemSpecification.Item.ArmType.ArmTypeName,
                        supplierName = (item.salesInvoiceMaster.licenseInfo.organizationInfoId == null ? item.salesInvoiceMaster.licenseInfo.personalInfo.nameEnglish : item.salesInvoiceMaster.licenseInfo.organizationInfo.name)
                    });
                }

                return data;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
           
        }


        public async Task<IEnumerable<DashboardArmsTypeViewModel>> GetDealerPurchaseItemDetalis(int id,int dealerid)
        {
            try
            {
                var result = await _context.purchaseOrderDetails
               .Include(x => x.purchase)
               .Include(x => x.purchase.dealer)
               .Include(x => x.purchase.supplier)
               //.Include(x => x.purchase.dealer.personalInfo)
               //.Include(x => x.purchase.licenseInfo.organizationInfo)
               .Include(x => x.itemSpecification.Item)
               .Include(x => x.itemSpecification.Item.ArmType)
               .Where(x => x.itemSpecification.Item.ArmTypeId == id && x.purchase.dealerId==dealerid)
               .AsNoTracking()
               .OrderByDescending
               (x => x.Id)
               .ToListAsync();

                List<DashboardArmsTypeViewModel> data = new List<DashboardArmsTypeViewModel>();

                foreach (var item in result)
                {
                    data.Add(new DashboardArmsTypeViewModel
                    {
                        purchasemasterId = item.purchaseId,
                        purchasedetailsId = item.Id,
                        itemName = item.itemSpecification.Item.itemName,
                        dealerName = item.purchase.dealer.dealerName,
                        lcDate = item.purchase.lcDate,
                        poNo = item.purchase.poNo,
                        subTotal = item.purchase.totalAmount,
                        armsType = item.itemSpecification.Item.ArmType.ArmTypeName,
                        supplierName=item.purchase.supplier.supplierName,
                       // supplierName = (item.purchase.licenseInfo.organizationInfoId == null ? item.salesInvoiceMaster.licenseInfo.personalInfo.nameEnglish : item.salesInvoiceMaster.licenseInfo.organizationInfo.name)
                    });
                }

                return data;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        
        public async Task<IEnumerable<DashboardArmsTypeViewModel>> GetAllPurchaseItemDetalis(int id)
        {
            try
            {
                var result = await _context.purchaseOrderDetails
               .Include(x => x.purchase)
               .Include(x => x.purchase.dealer)
               .Include(x => x.purchase.supplier)
               //.Include(x => x.purchase.dealer.personalInfo)
               //.Include(x => x.purchase.licenseInfo.organizationInfo)
               .Include(x => x.itemSpecification.Item)
               .Include(x => x.itemSpecification.Item.ArmType)
               .Where(x => x.itemSpecification.Item.ArmTypeId == id)
               .AsNoTracking()
               .OrderByDescending
               (x => x.Id)
               .ToListAsync();

                List<DashboardArmsTypeViewModel> data = new List<DashboardArmsTypeViewModel>();

                foreach (var item in result)
                {
                    data.Add(new DashboardArmsTypeViewModel
                    {
                        purchasemasterId = item.purchaseId,
                        purchasedetailsId = item.Id,
                        itemName = item.itemSpecification.Item.itemName,
                        dealerName = item.purchase.dealer.dealerName,
                        lcDate = item.purchase.lcDate,
                        poNo = item.purchase.poNo,
                        subTotal = item.purchase.totalAmount,
                        armsType = item.itemSpecification.Item.ArmType.ArmTypeName,
                        supplierName=item.purchase.supplier.supplierName,
                       // supplierName = (item.purchase.licenseInfo.organizationInfoId == null ? item.salesInvoiceMaster.licenseInfo.personalInfo.nameEnglish : item.salesInvoiceMaster.licenseInfo.organizationInfo.name)
                    });
                }

                return data;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        //public async Task<IEnumerable<Sp_LicenseTypeViewModel>> Sp_GetLicenseType(int Id)
        //{
        //    return _context.Sp_LicenseTypeViewModels.FromSql($"sp_vw_LicenseTypes {Id}");
        //}
        public async Task<SalesInvoiceMaster> GetSalesInvoiceMasterById(int id)
        {
            return await _context.salesInvoiceMasters.Include(x => x.licenseInfo).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteSalesInvoiceDetailByMasterId(int masterId)
        {
            _context.salesInvoiceDetails.RemoveRange(_context.salesInvoiceDetails.Where(x => x.salesInvoiceMasterId == masterId));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<int> SaveSalesInvoiceMaster(SalesInvoiceMaster salesInvoiceMaster)
        {
            if (salesInvoiceMaster.Id != 0)
                _context.salesInvoiceMasters.Update(salesInvoiceMaster);
            else
                _context.salesInvoiceMasters.Add(salesInvoiceMaster);
            await _context.SaveChangesAsync();
            return salesInvoiceMaster.Id;
        }
        public async Task<bool> SaveSalesInvoiceDetail(SalesInvoiceDetail salesInvoiceDetail)
        {
            if (salesInvoiceDetail.Id != 0)
                _context.salesInvoiceDetails.Update(salesInvoiceDetail);
            else
                _context.salesInvoiceDetails.Add(salesInvoiceDetail);
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceDetailByMasterId(int masterId)
        {
            return await _context.salesInvoiceDetails
                .Include(x => x.salesInvoiceMaster)
                .Include(x => x.itemSpecification)
                .Include(x => x.itemSpecification.Item)
                .Include(x => x.itemSpecification.Item.itemHsCode)
                .Include(x => x.itemSpecification.Item.unit)
                .AsNoTracking()
                .Where(x => x.salesInvoiceMasterId == masterId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesVatType>> GetAllSalesVatType()
        {
            var data= await _context.salesVatTypes.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<IEnumerable<LicenseInfo>> GetAllRelSupplierCustomerResourseByRoleId(int roletypeId)
        {
            return await _context.LicenseInfos.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Sp_LicenseInfoViewModel>> Sp_GetAllRelSupplierCustomer(int Id)
        {
            return _context.sp_LicenseInfoViewModels.FromSql($"Sp_GetAllRelSupplierCustomerResourseByRoleId");
            
        }
        public async Task<IEnumerable<Sp_LicenseInfoViewModel>> Sp_GetAllLicenseCustomer(int Id)
        {
            return _context.sp_LicenseInfoViewModels.FromSql($"sp_GetLicenseInfoByLiNumber  {Id}");
            
        }
         public async Task<IEnumerable<Sp_LicenseTypeViewModel>> Sp_GetLicenseType(int Id)
        {
            return _context.Sp_LicenseTypeViewModels.FromSql($"sp_vw_LicenseTypes {Id}");
            
        }
        public IQueryable<SpCheckLicenseInfoIdbyLicenseNum> GetLicenseIdByLiNo(string liNO)
        {
            return _context.spCheckLicenseInfoIdbyLicenseNum.FromSql($"sp_getLisenceInfoBySalesId {liNO}");
        }
        //public IQueryable <IEnumerable<SpCheckLicenseInfoIdbyLicenseNum>> GetLicenseIdByLiNo(string liNO)
        //{
        //   return _context.spCheckLicenseInfoIdbyLicenseNum.FromSql($"sp_getLisenceInfoBySalesId {liNO}");
        //    //var data = _context.spCheckLicenseInfoIdbyLicenseNum.FromSql($"sp_getLisenceInfoBySalesId {liNO}");
        //    //var data = await _context.Database.
        //    //return data;
        //    //return await _context.LicenseInfos.Where(x => x.licenseNumber == liNO).Select(x => x.Id).FirstOrDefaultAsync();
        //}

        public async Task<string> checkGunInfoByLiNumber(string licenseNumber)
        {

            //var isValid = await _context.LicenseInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).FirstOrDefaultAsync();
            var isValid = _context.spCheckLicenseandGun.FromSql($"sp_checkLicenseInfoByLiNumber {licenseNumber}");
            if (isValid == null)
            {
                return "notValid";
            }

            var Used = _context.spCheckLicenseandGun.FromSql($"sp_checkGunInfoByLiNumber {licenseNumber}");
            if (Used != null)
            {
                return "Used";
            }
            return "notUsed";
        }
        //public async Task<TransactionVM> GetLiInfoBynum(string number)
        //{
        //    var model = new TransactionVM();
        //    var name = await _context.LicenseInfos.Where(x => x.licenseNumber == number).Include(x => x.personalInfo).Include(x => x.organizationInfo).FirstOrDefaultAsync();
        //    if (name.organizationInfoId != null)
        //    {
        //        model.isOrg = 1;
        //        model.id = name.organizationInfoId;
        //        model.Name = name.organizationInfo.name;
        //        model.armsId = name.armTypeId;

        //    }
        //    else
        //    {
        //        model.isOrg = 2;
        //        model.id = name.personalInfoId;
        //        model.Name = name.personalInfo.nameEnglish;
        //        model.armsId = name.armTypeId;
        //    }
        //    return model;
        //}

    }
}
