using FADMS.Areas.FAMSDEALER.Models;
using FADMS.Data.Entity;
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Attachment;
using FADMS.Data.Entity.Auth;
using FADMS.Data.Entity.DbQuery_Model;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.AttachmentComment;
using FADMS.Data.Entity.Dealer.Purchase;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using FADMS.Data.Entity.Route;
using FADMS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADMS.Data
{
    public class FADMSDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FADMSDbContext(DbContextOptions<FADMSDbContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        #region ItemHsCode
        public DbSet<ItemHsCode> itemHsCodes { get; set; }
        public DbSet<TaxYear> taxYears { get; set; }
        public DbSet<VatCategory>  vatCategories { get; set; }
        public DbSet<VATSchedule>  vATSchedules { get; set; }
        public DbSet<VatTable>  vatTables { get; set; }
        public DbSet<Unit> units { get; set; }
        public DbSet<ItemSpecification> itemSpecifications { get; set; }
        public DbSet<ProductionType> productionTypes { get; set; }
        public DbSet<Item> items { get; set; }
        //public DbSet<DocumentAttachment> documentAttachments { get; set; }
        public DbSet<SpecificationCategory> specificationCategories { get; set; }
        public DbSet<SpecificationDetail> specificationDetails { get; set; }
        public DbQuery<ItemCodeViewModel> itemCodeViewModels { get; set; }

        #endregion

        #region Auth
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<ModuleAccessPage> ModuleAccessPages { get; set; }
        public DbSet<FAMSModule> FAMSModules { get; set; }
        public DbSet<Navbar> Navbars { get; set; }
        #endregion

        #region Arms Info
        public DbSet<ArmType> ArmTypes { get; set; }
        #endregion

      

        #region Attachment
        public DbSet<PersonalAttachment> personalAttachments { get; set; }
        public DbSet<OrganizationAttachment>  organizationAttachments { get; set; }
        public DbSet<GunRepairAttachment>  gunRepairAttachments { get; set; }
        #endregion

        #region License
        public DbSet<LicenseInfo> LicenseInfos { get; set; }
        public DbSet<LicenseSourseType> LicenseSourseTypes { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Photograph> Photographs { get; set; }
        public DbSet<OrganizationInfo> organizationInfos { get; set; }
        public DbSet<OrganizationType> organizationTypes { get; set; }

        public DbSet<Address> addresses { get; set; }
        public DbSet<GunRepair> gunRepairs { get; set; }
        #endregion

        #region Dashboard
        public DbQuery<TotalsArmsByType> armsInfoDashboards { get; set; }
        public DbQuery<TotalsArmsByTypeWithId> armsTotalByType { get; set; }
        public DbQuery<ArmsInfoVM> armsInfoWithIdDashboards { get; set; }
        public DbQuery<ArmsInfoDashboardDivDetail> armsInfoDashboardDivDetails { get; set; }

        #endregion

        #region Route
        public DbSet<ApplicationRoute> applicationRoutes { get; set; }
        public DbSet<AppllicationRouteLog> appllicationRouteLogs { get; set; }
        public DbSet<ApplicationAttachment> applicationAttachments { get; set; }
        public DbSet<ApplicationEnquireInfo> applicationEnquireInfos { get; set; }
        #endregion
        
        #region Master Data
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<RangeMetro> RangeMetros { get; set; }
        public DbSet<DivisionDistrict> DivisionDistricts { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OccupationStatus> OccupationStatuses { get; set; }
        public DbSet<PoliticalParty> PoliticalParties { get; set; }
        #endregion

        #region Settings Configs
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {

            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
                ? _httpContextAccessor.HttpContext.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Base)entity.Entity).createdAt = DateTime.Now;
                    ((Base)entity.Entity).createdBy = currentUsername;
                }
                else
                {
                    entity.Property("createdAt").IsModified = false;
                    entity.Property("createdBy").IsModified = false;
                    ((Base)entity.Entity).updatedAt = DateTime.Now;
                    ((Base)entity.Entity).updatedBy = currentUsername;
                }
                
            }
        }
        #endregion
        
        #region Supplier
        public DbSet<Comment> comments { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Currency> currencies { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<SupplierAddress> supplierAddress { get; set; }
        public DbSet<SupplierAddressCategory> supplierAddressCategories { get; set; }
        public DbSet<SupplierType> supplierTypes { get; set; }
        #endregion
        
        #region Dealer
        public DbSet<Dealer> dealers { get; set; }
        public DbSet<DealerAddress> dealerAddresss { get; set; }
        public DbSet<DealerAddressCategory> dealerAddressCategories { get; set; }
        public DbSet<DealerType> dealerTypes { get; set; }
        public DbSet<DealerItems> dealerItems { get; set; }

        public DbQuery<SpSalesViewmodel> spSalesViewmodels { get; set; }
        public DbQuery<SpGetAllThanaViewModel> spGetAllThanaViewModel { get; set; }
        public DbQuery<SpCheckLicenseandGun> spCheckLicenseandGun { get; set; }
        public DbQuery<SpGetAllDistrictViewModel> spGetAllDistrictViewModel { get; set; }
        public DbQuery<vw_getAllDivisionViewModel> vw_getAllDivision { get; set; }
        public DbQuery<SpPurchase> spPurchases { get; set; }
        public DbQuery<Sp_LicenseInfoViewModel> sp_LicenseInfoViewModels { get; set; }
        public DbQuery<Sp_LicenseTypeViewModel> Sp_LicenseTypeViewModels { get; set; }
        public DbQuery<SpCheckLicenseInfoIdbyLicenseNum> spCheckLicenseInfoIdbyLicenseNum { get; set; }

        
        #endregion

        #region Purchase
        public DbSet<PaymentType> paymentTypes { get; set; }
        public DbSet<PurchaseOrderDetail> purchaseOrderDetails { get; set; }
        public DbSet<PurchaseOrderMaster> purchaseOrderMasters { get; set; }
        public DbSet<PurchaseReturnDetail> purchaseReturnDetails { get; set; }
        public DbSet<PurchaseReturnMaster> purchaseReturnMasters { get; set; }
        public DbSet<PurchaseVatType> purchaseVatTypes { get; set; }
        #endregion

        #region Sales
        public DbSet<SalesInvoiceDetail> salesInvoiceDetails { get; set; }
        public DbSet<SalesInvoiceMaster> salesInvoiceMasters { get; set; }
        public DbSet<SalesReturnInvoiceDetail> salesReturnInvoiceDetails { get; set; }
        public DbSet<SalesReturnInvoiceMaster> salesReturnInvoiceMasters { get; set; }
        public DbSet<SalesVatType> salesVatTypes { get; set; }
        #endregion
    }
}
