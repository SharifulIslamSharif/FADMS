using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.DAL.Services.Interfaces
{
   public interface ISalesService
    {
        Task<IEnumerable<Sp_LicenseInfoViewModel>> Sp_GetAllLicenseCustomer(int Id);
        Task<IEnumerable<Sp_LicenseTypeViewModel>> Sp_GetLicenseType(int Id);
        Task<IEnumerable<Sp_LicenseInfoViewModel>> Sp_GetAllRelSupplierCustomer(int Id);
        Task<string> checkGunInfoByLiNumber(string licenseNumber);
        Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceMasterAndDetalisByAllDealers();
        Task<IEnumerable<SalesInvoiceMaster>> GetAllSalesInvoiceMaster();
        Task<IEnumerable<SalesInvoiceMaster>> GetAllSalesInvoiceMasterbyDealer(int? did);
        Task<SalesInvoiceMaster> GetSalesInvoiceMasterById(int id);
        Task<bool> DeleteSalesInvoiceDetailByMasterId(int masterId);
        Task<int> SaveSalesInvoiceMaster(SalesInvoiceMaster salesInvoiceMaster);
        Task<bool> SaveSalesInvoiceDetail(SalesInvoiceDetail salesInvoiceDetail);
        Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceDetailByMasterId(int masterId);

        Task<IEnumerable<SalesVatType>> GetAllSalesVatType();
        Task<IEnumerable<LicenseInfo>> GetAllRelSupplierCustomerResourseByRoleId(int roletypeId);
        Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceMasterAndDetalis();
        Task<IEnumerable<SalesInvoiceDetail>> GetAllSalesInvoiceMasterAndDetalisByDealer(int? dId);

        Task<IEnumerable<DashboardArmsTypeViewModel>> GetAllSalesInvoiceItemDetalis(int id);

        Task<IEnumerable<DashboardArmsTypeViewModel>> GetAllPurchaseItemDetalis(int id);

        //Task<IEnumerable<SpCheckLicenseInfoIdbyLicenseNum>> GetLicenseIdByLiNo(string liNO);
        IQueryable<SpCheckLicenseInfoIdbyLicenseNum> GetLicenseIdByLiNo(string liNO);

        Task<IEnumerable<DashboardArmsTypeViewModel>> GetDealersSalesInvoiceItemDetalis(int id, int dealerid);
        Task<IEnumerable<DashboardArmsTypeViewModel>> GetDealerPurchaseItemDetalis(int id, int dealerid);
    }
}
