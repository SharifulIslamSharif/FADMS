using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DinkToPdf.Contracts;
using FADMS.Areas.FAMSDB.Models;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.FamsDealerService.Interface;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Models;
using FADMS.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Authorize]
    [Area("FAMSDEALER")]
    public class ReportController : Controller
    {

        private readonly MyPDF myPDF;
        private readonly string rootPath;
        public string FileName;

        private readonly ISupplierService _supplierService;      
        private readonly IRepository<PersonalInfo> _personalInfo;
        private readonly ISalesService _salesService;
        private readonly IPurchaseService _purchaseService;
        private readonly IDealerService _dealerService;
        private readonly IRepository<Dealer> _dealer;
        private readonly IITemService _itemService;
        private readonly IRepository<ArmType> _armTypes;
        private readonly IRepository<Item> _item;

        public ReportController(
            IHostingEnvironment hostingEnvironment,
            IConverter converter,

            ISupplierService supplierService,     
            IRepository<PersonalInfo> personalInfo,
            IRepository<Item> item,
            IRepository<ArmType> armTypes,
            IRepository<Dealer> dealer,
            ISalesService salesService,
            IPurchaseService purchaseService,
            IDealerService dealerService,
            IITemService itemService
            )
        {
            this.myPDF = new MyPDF(hostingEnvironment, converter);
            rootPath = hostingEnvironment.ContentRootPath;

            _supplierService = supplierService;
          
            _personalInfo = personalInfo;
            _salesService = salesService;
            _purchaseService = purchaseService;
            _dealerService = dealerService;
            _dealer = dealer;
            _itemService = itemService;
            _armTypes = armTypes;
            _item = item;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var data = new DealerReportViewModel
            {
                suppliers = await _supplierService.GetSuppliers(),
                personalInfos = _personalInfo.GetAll(),
         
                //purchaseOrderDetails = await _salesService.GetAllPurchaseItemDetalis((int)id),
                //salesInvoiceDetails = await _salesService.GetAllSalesInvoiceItemDetalis((int)id),
                dealers = _dealer.GetAll(),
                //dealer = _dealer.Get(id),
                armTypes = _armTypes.GetAll(),
                items = _item.GetAll(),

            };
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> DealerReport(DealerReportViewModel model)
        {
           
            var data = new DealerReportViewModel
            {
                suppliers = await _supplierService.GetSuppliers(),
                personalInfos = _personalInfo.GetAll(),
         
                dealers = _dealer.GetAll(),
                armTypes = _armTypes.GetAll(),
                items = _item.GetAll(),
            };
            return View(data);
        }


        #region Api
        [HttpGet]
        public async Task<IActionResult> GetDealerSales(ReportVm report)
        {
            var vm = new DealerReportViewModel();
            //for purchase
            if (report.DealerId>0 && report.Type == 1)
            {
                 vm.purchaseDetailReport = await _dealerService.GetDealerWisePurchaseRepo(report);
            }

            //for Sales
            if (report.DealerId >0 && report.Type == 2)
            {
                vm.salesInvoiceDetailReport = await _dealerService.GetDealerSalseRepo(report);
            }

            //for purchase
            if (report.SupplierId > 0)
            {
                  vm.purchaseDetailReport = await _dealerService.GetDealerWisePurchaseRepo(report);
            }

            //for Sales
            if (report.PersonalInfosId > 0)
            {
                vm.salesInvoiceDetailReport = await _dealerService.GetDealerSalseRepo(report);
            }

            //for Sales
            if (report.OrganizationInfosId > 0)
            {
                vm.salesInvoiceDetailReport = await _dealerService.GetDealerSalseRepo(report);
            }

            //for purchase
            if (report.ItemId >0 && report.Type == 6)
            {
                   vm.purchaseDetailReport = await _dealerService.GetDealerWisePurchaseRepo(report);
            }

            //for Sales
            if (report.ItemId > 0 && report.Type == 7)
            {
                vm.salesInvoiceDetailReport = await _dealerService.GetDealerSalseRepo(report);
            }

            //for purchase
            if (report.ItemCategoryId >0 && report.Type == 8)
            {
                 vm.purchaseDetailReport = await _dealerService.GetDealerWisePurchaseRepo(report);
            }

            //for Sales
            if (report.ItemCategoryId > 0 && report.Type == 9)
            {
                vm.salesInvoiceDetailReport = await _dealerService.GetDealerSalseRepo(report);
            }

            vm.fromDdate = report.FromDate;
            vm.toDate = report.ToDate;
            return View(vm);
        }
        
        [AllowAnonymous]
        public IActionResult ReportForsalesPDf(ReportVm report)
        {
            string fileName;
            string host = HttpContext.Request.Host.ToString();
            string scheme = Request.Scheme;
            string url = string.Empty;
            
            var properties = from p in report.GetType().GetProperties()
                             where p.GetValue(report, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(report, null).ToString());

            string queryString = String.Join("&", properties.ToArray());
            
            url = $"" + scheme + "://" + host + "/FAMSDEALER/Report/GetDealerSales?"+ queryString;
            string status = myPDF.GenerateLandscapePDF(out fileName, url);
            if (status != "done")
            {
                return Content("<h1>Something Went Wrong</h1>");
            }
            var stream = new FileStream(rootPath + "/wwwroot/pdf/" + fileName, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }
        #endregion
    }
}