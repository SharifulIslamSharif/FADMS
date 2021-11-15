using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class SalesInvoiceController : Controller
    {
        //private readonly IDashboardService dashboardService;
        private readonly ISalesService _salesService;
        private readonly IDealerService  _dealerService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string rootPath;
        private readonly IConverter converter;
        private readonly IRepository<Dealer> _dealer;
        private readonly MyPDF myPDF;
        public string FileName;

        public SalesInvoiceController(

            ISalesService salesService,
            IDealerService dealerService,
            IHostingEnvironment hostingEnvironment,
            IConverter converter,
            IRepository<Dealer> dealer          
            )
        {
            _salesService = salesService;
            _dealerService = dealerService;
            this._hostingEnvironment = hostingEnvironment;
            myPDF = new MyPDF(hostingEnvironment, converter);
            rootPath = hostingEnvironment.ContentRootPath;
            this.converter = converter;
            _dealer = dealer;
        }
        public async Task<IActionResult> InvoiceList()
        {
            var dId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            SalesInvoiceViewModel model = new SalesInvoiceViewModel
            {
                salesInvoiceMastersDetails = await _salesService.GetAllSalesInvoiceMasterAndDetalisByDealer(dId),
            };
            if (model.salesInvoiceMastersDetails.Count() > 0)
            {
                model.salesInvoiceMastersDetails = model.salesInvoiceMastersDetails.Where(x => x.salesInvoiceMaster?.salesType == 0);
            }
            return View(model);
        }

        public async Task<IActionResult> InvoiceListOfDealers()
        {
            
            SalesInvoiceViewModel model = new SalesInvoiceViewModel
            {
                salesInvoiceMastersDetails = await _salesService.GetAllSalesInvoiceMasterAndDetalisByAllDealers(),
            };
        
            return View(model);
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.mastersalseId = id;
            var sale = await _salesService.GetAllSalesInvoiceMaster();
            int Cpurchase = 0;
            if (sale != null)
            {
                Cpurchase = sale.Where(x => x.salesType == 0).Count();
            }
            string idate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            string issueNo = "Sale" + '-' + idate + '-' + (Cpurchase + 1);
            ViewBag.SaleNo = issueNo;

            var MasterInfo = await _salesService.GetSalesInvoiceMasterById(id);
            if (MasterInfo == null)
            {
                MasterInfo = new SalesInvoiceMaster();
            }
            string user = HttpContext.User.Identity.Name;
            SalesInvoiceViewModel model = new SalesInvoiceViewModel
            {
                masterId = id,
            
                salesInvoiceMaster = MasterInfo,
                salesVatTypes = await _salesService.GetAllSalesVatType(),
                dealers = _dealer.GetAll(),
            
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] SalesInvoiceViewModel model)
        {

            var sale = await _salesService.GetAllSalesInvoiceMaster();

            int Cpurchase = 0;
            Cpurchase = sale.Where(x => Convert.ToDateTime(x.invoiceDate).ToString("yyyyMMdd") == Convert.ToDateTime(model.invoiceDate).ToString("yyyyMMdd")).Count();
            string idate = Convert.ToDateTime(model.invoiceDate).ToString("yyyy-MM-dd");
            string issueNo = "Sale" + '-' + idate + '-' + (Cpurchase + 1);
            if (model.masterId > 0)
            {
                issueNo = model.salesInvoiceNo;
            }
            if (model.masterId > 0)
            {
                try
                {
                    await _salesService.DeleteSalesInvoiceDetailByMasterId(Convert.ToInt32(model.masterId));
                }
                catch
                {
                    return RedirectToAction(nameof(InvoiceDetails), new { id = model.masterId });
                }
            }
            
            decimal vatAmount = 0;
            decimal taxAmount = 0;
            decimal netAmount = 0;
            decimal assessableValue = 0;
            decimal grossTotalAmount = 0;

            if (model.tblQuantity != null)
            {
                if (model.tblQuantity.Length > 0)
                {

                    for (int i = 0; i < model.tblQuantity.Length; i++)
                    {

                        vatAmount += Convert.ToDecimal(model.vattotal[i]);
                        taxAmount += Convert.ToDecimal(model.taxtotal[i]);
                        assessableValue = (Convert.ToDecimal(model.tblQuantity[i]) * Convert.ToDecimal(model.rate[i]));
                        grossTotalAmount += assessableValue;
                        netAmount += assessableValue + Convert.ToDecimal(model.vattotal[i]) + Convert.ToDecimal(model.taxtotal[i]);
                    }
                }
            }

            SalesInvoiceMaster data = new SalesInvoiceMaster
            {
                Id = Convert.ToInt32(model.masterId),
                salesVatTypeId = model.salesVatTypeId,
                licenseInfoId = model.licenseId,
                invoiceDate = model.invoiceDate,
                paymentDate = model.paymentDate,
                invoiceNumber = issueNo,
                shiftTo = model.shiftTo,
                VATOnTotal = vatAmount,
                TAXOnTotal = taxAmount,
                totalAmount = grossTotalAmount,
                NetTotal = netAmount,
                dealerId=model.dearId,
                DiscountOnTotal = model.grossDiscount,
                vds = model.vds,
                isClose = 0,
                isStockClose = 0,
                salesType = 0
            };
            var masterId = await _salesService.SaveSalesInvoiceMaster(data);
   
                    for (int i = 0; i < model.itemSpecId.Length; i++)
                    {
                        SalesInvoiceDetail data1 = new SalesInvoiceDetail
                        {
                            Id = 0,
                            salesInvoiceMasterId = masterId,
                            itemSpecificationId = model.itemSpecId[i],
                            quantity = model.tblQuantity[i],
                            rate = model.rate[i],
                            vatPercentage = model.vatPercentage[i],
                            taxPercentage = model.taxPercentage[i],
                            vatAmount = model.vattotal[i],
                            taxAmount = model.taxtotal[i],
                            lineTotal = model.lineTotal[i]
                        };
                        await _salesService.SaveSalesInvoiceDetail(data1);
                    }
 
            return RedirectToAction(nameof(InvoiceDetails), new { id = masterId });
        }
        [HttpGet]
        public async Task<IActionResult> DealerSales(int id)
        {
            var dId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            ViewBag.mastersalseId = id;
            var sale = await _salesService.GetAllSalesInvoiceMasterbyDealer(dId);
            int Cpurchase = 0;
            if (sale != null)
            {
                Cpurchase = sale.Where(x => x.salesType == 0).Count();
            }
            string idate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            string issueNo = "Sale"  + idate +  (Cpurchase + 1);
            ViewBag.SaleNo = issueNo;

            var licenseType = await _salesService.Sp_GetLicenseType(id);
            var MasterInfo = await _salesService.GetSalesInvoiceMasterById(id);
            if (MasterInfo == null)
            {
                MasterInfo = new SalesInvoiceMaster();
            }
            
            SalesInvoiceViewModel model = new SalesInvoiceViewModel
            {
                masterId = id,
                salesInvoiceMaster = MasterInfo,
                salesVatTypes = await _salesService.GetAllSalesVatType(),
                LicensenumberLiNo = await _salesService.Sp_GetAllLicenseCustomer(id),
                //Sp_LicenseTypeViewModels = licenseType,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DealerSales([FromForm] SalesInvoiceViewModel model)
        {
            var dId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var a = _salesService.GetLicenseIdByLiNo(model.lcNo);
            //int b = a.;
            var sale = await _salesService.GetAllSalesInvoiceMasterbyDealer(dId);
            int Cpurchase = 0;
            Cpurchase = sale.Where(x => Convert.ToDateTime(x.invoiceDate).ToString("yyyyMMdd") == Convert.ToDateTime(model.invoiceDate).ToString("yyyyMMdd")).Count();
            string idate = Convert.ToDateTime(model.invoiceDate).ToString("yyyy-MM-dd");
            string issueNo = "Sale" + idate +  (Cpurchase + 1);
            if (model.masterId > 0)
            {
                issueNo = model.salesInvoiceNo;
            }
            if (model.masterId > 0)
            {
                try
                {
                    await _salesService.DeleteSalesInvoiceDetailByMasterId(Convert.ToInt32(model.masterId));
                }
                catch
                {
                    return RedirectToAction(nameof(InvoiceDetails), new { id = model.masterId });
                }
            }

            decimal vatAmount = 0;
            decimal taxAmount = 0;
            decimal netAmount = 0;
            decimal assessableValue = 0;
            decimal grossTotalAmount = 0;

            if (model.tblQuantity != null)
            {
                if (model.tblQuantity.Length > 0)
                {

                    for (int i = 0; i < model.tblQuantity.Length; i++)
                    {

                        vatAmount += Convert.ToDecimal(model.vattotal[i]);
                        taxAmount += Convert.ToDecimal(model.taxtotal[i]);
                        assessableValue = (Convert.ToDecimal(model.tblQuantity[i]) * Convert.ToDecimal(model.rate[i]));
                        grossTotalAmount += assessableValue;
                        netAmount += assessableValue + Convert.ToDecimal(model.vattotal[i]) + Convert.ToDecimal(model.taxtotal[i]);
                    }
                }
            }
            
            SalesInvoiceMaster data = new SalesInvoiceMaster
            {
                Id = Convert.ToInt32(model.masterId),
                salesVatTypeId = model.salesVatTypeId,
                //liInfoId = a,
                //liInfoId = await _salesService.GetLicenseIdByLiNo(model.lcNo),
                liInfoId =model.licenseId,
                invoiceDate = model.invoiceDate,
                paymentDate = model.paymentDate,
                invoiceNumber = issueNo,
                shiftTo = model.shiftTo,
                VATOnTotal = vatAmount,
                TAXOnTotal = taxAmount,
                totalAmount = grossTotalAmount,
                NetTotal = netAmount,
                dealerId = dId,
                DiscountOnTotal = model.grossDiscount,
                vds = model.vds,
                isClose = 0,
                isStockClose = 0,
                salesType = 0
            };
            var masterId = await _salesService.SaveSalesInvoiceMaster(data);

            for (int i = 0; i < model.itemSpecId.Length; i++)
            {
                SalesInvoiceDetail data1 = new SalesInvoiceDetail
                {
                    Id = 0,
                    salesInvoiceMasterId = masterId,
                    itemSpecificationId = model.itemSpecId[i],
                    quantity = model.tblQuantity[i],
                    rate = model.rate[i],
                    vatPercentage = model.vatPercentage[i],
                    taxPercentage = model.taxPercentage[i],
                    vatAmount = model.vattotal[i],
                    taxAmount = model.taxtotal[i],
                    lineTotal = model.lineTotal[i]
                };
                await _salesService.SaveSalesInvoiceDetail(data1);
            }

            //return RedirectToAction(nameof(InvoiceDetails), new { id = masterId });
            return RedirectToAction(nameof(InvoiceList));
        }


        public async Task<IActionResult> InvoiceDetails(int id)
        {
            ViewBag.masterId = id;

            SalesInvoiceViewModel model = new SalesInvoiceViewModel
            {
                salesInvoiceMaster = await _salesService.GetSalesInvoiceMasterById(id),
                salesInvoiceDetails = await _salesService.GetAllSalesInvoiceDetailByMasterId(id),
            };

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRelSupplierCustomerResourseByRoleId()
        {
            return Json(await _salesService.Sp_GetAllRelSupplierCustomer(2));
            //return Json(await _salesService.GetAllRelSupplierCustomerResourseByRoleId(2));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalesInvoiceDetailByMasterId(int masterId)
        {
            return Json(await _salesService.GetAllSalesInvoiceDetailByMasterId(masterId));
        }
        
        #region PDF
        [AllowAnonymous]
        public IActionResult InvoicePDFAction(int id)
        {
            string userName = HttpContext.User.Identity.Name;
            string scheme = Request.Scheme;
            var host = Request.Host;

            string url = scheme + "://" + host + "/FAMSDEALER/SalesInvoice/InvoicePDF?id=" + id + "&userName=" + userName;

            string fileName;
            string status = myPDF.GeneratePDF(out fileName, url);

            FileName = fileName;
            if (status != "done")
            {
                return Content("<h1>" + status + "</h1>");
            }

            var stream = new FileStream(rootPath + "/wwwroot/pdf/" + fileName, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> InvoicePDF(int id, string userName)
        {
            ViewBag.masterId = id;

            SalesInvoiceViewModel model = new SalesInvoiceViewModel
            {
                salesInvoiceMaster = await _salesService.GetSalesInvoiceMasterById(id),
                salesInvoiceDetails = await _salesService.GetAllSalesInvoiceDetailByMasterId(id),

            };
            ViewBag.InWord = AmountInWord.ConvertToWords(model.salesInvoiceMaster.NetTotal.ToString());

            return View(model);
        }
        [HttpGet("global/api/GetLicenseInfobyLicense/{liNumber}")]
        public async Task<IActionResult> GetLicenseInfobyLicense(string liNumber)
        {
            var unuse = await _salesService.checkGunInfoByLiNumber(liNumber);
            if (unuse == "notValid")
            {
                return Json("notValid");
            }
            else if (unuse == "Used")
            {
                return Json("Used");
            }
            //else if (unuse == "notUsed")
            //{
            //    var id = await _salesService.GetLiInfoBynum(liNumber);
            //    return Json(id);
            //}
            return Json("not Match");

        }
        #endregion

    }
}