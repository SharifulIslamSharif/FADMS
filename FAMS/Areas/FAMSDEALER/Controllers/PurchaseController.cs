using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.FamsDealerService.Interface;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.AttachmentComment;
using FADMS.Data.Entity.Dealer.Purchase;
using FADMS.Data.Entity.Master;
using FADMS.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService purchaseService;
        private readonly IAddressService addressService;
        private readonly string rootPath;
        private readonly IConverter converter;
        private readonly IRepository<Dealer> _dealer;
        private readonly MyPDF myPDF;
        public string FileName;
        private readonly IItemsService ItemsService;

        private readonly IRepository<Country> _country;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IDealerService _dealerService;
        private readonly IITemService  _itemService;

        public PurchaseController(
            IDealerService dealerService,
            IITemService itemService,
            IPurchaseService purchaseService,
            IAddressService addressService,
            IItemsService ItemsService,
            IRepository<Country> country,
            IHostingEnvironment hostingEnvironment,
            IConverter converter,
            IRepository<Dealer> dealer
            )
        {
            this.purchaseService = purchaseService;
            this.addressService = addressService;
            this.ItemsService = ItemsService;
            this._dealerService = dealerService;
            this._itemService = itemService;
            _country = country;
            this._hostingEnvironment = hostingEnvironment;
            myPDF = new MyPDF(hostingEnvironment, converter);
            rootPath = hostingEnvironment.ContentRootPath;
            this.converter = converter;
            _dealer = dealer;
        }
        public async Task<IActionResult> PurchaseImportList()
        {
            var dealerId= await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var model = new PurchaseViewModel
            {
                purchaseOrderMasters = await purchaseService.GetPurchaseOrderMasterByPurchaseType(dealerId),
                countries = await addressService.GetAllContry()
            };
            return View(model);
        }


        public async Task<IActionResult> AllDealerPurchaseList()
        {
           
            var model = new PurchaseViewModel
            {
                purchaseOrderMasters = await purchaseService.GetImportedPurchaseOrderMaster(),
                countries = await addressService.GetAllContry()
            };
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.masterId = id;
            var purchase = await purchaseService.GetImportedPurchaseOrderMaster();
            int Cpurchase = 0;
            if (purchase != null)
            {
                Cpurchase = purchase.Count();
            }
            // Cpurchase = purchase.Where(x => Convert.ToDateTime(x.poDate).ToString("yyyyMMdd") == Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd")).Count();
            string idate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            string issueNo = "Import" + '-' + idate + '-' + (Cpurchase + 1);


            if (Convert.ToInt32(id) != 0)
            {
                var data = await purchaseService.GetPurchaseOrderMasterById(id);
                issueNo = data.poNo;
            }
            ViewBag.PurchaseNo = issueNo;
            PurchaseViewModel model = new PurchaseViewModel
            {
                purchaseVatTypes = await purchaseService.GetPurchaseVatType(),
                purchaseOrderMasters = await purchaseService.GetPurchaseOrderMaster(),
                specificationCategories = await ItemsService.GetAllSpecificationCategory(),
                countries = _country.GetAll(),
                dealers = _dealer.GetAll(),
            };
            return View(model);
        }
        
        [HttpPost]
        public async Task<JsonResult> Index([FromForm] PurchaseViewModel model)
        {

            string userName = User.Identity.Name;
            var purchase = await purchaseService.GetImportedPurchaseOrderMaster();
            int Cpurchase = 0;

            if (purchase != null)
            {
                Cpurchase = purchase.Count();
            }
            string idate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            string issueNo = "Import" + '-' + idate + '-' + (Cpurchase + 1);
            if (model.purchaseOrderMasterId > 0)
            {
                issueNo = model.poNo;
            }

            decimal vatAmount = 0;
            decimal taxAmount = 0;
            decimal cdAmount = 0;
            decimal sdAmount = 0;
            decimal atAmount = 0;
            decimal rdAmount = 0;
            decimal netAmount = 0;
            decimal assessableValue = 0;
            decimal totalAmount = 0;


            if (model.quantity != null)
            {
                if (model.quantity.Length > 0)
                {

                    for (int i = 0; i < model.quantity.Length; i++)
                    {

                        vatAmount += Convert.ToDecimal(model.vattotal[i]);
                        taxAmount += Convert.ToDecimal(model.taxtotal[i]);
                        cdAmount += Convert.ToDecimal(model.cdtotal[i]);
                        sdAmount += Convert.ToDecimal(model.sdtotal[i]);
                        atAmount += Convert.ToDecimal(model.attotal[i]);
                        rdAmount += Convert.ToDecimal(model.rdtotal[i]);
                        assessableValue = (Convert.ToDecimal(model.quantity[i]) * Convert.ToDecimal(model.rate[i]));
                        totalAmount += assessableValue + Convert.ToDecimal(model.cdtotal[i]) + Convert.ToDecimal(model.sdtotal[i]) + Convert.ToDecimal(model.rdtotal[i]);

                        netAmount += assessableValue + Convert.ToDecimal(model.vattotal[i]) + Convert.ToDecimal(model.taxtotal[i]) + Convert.ToDecimal(model.cdtotal[i]) + Convert.ToDecimal(model.sdtotal[i]) + Convert.ToDecimal(model.attotal[i]) + Convert.ToDecimal(model.rdtotal[i]);
                    }




                }
            }

            PurchaseOrderMaster purchaseOrderMaster = new PurchaseOrderMaster();
            purchaseOrderMaster.Id = Convert.ToInt32(model.purchaseOrderMasterId);
            purchaseOrderMaster.purchaseVatTypeId = model.purchaseVatTypeId;
            purchaseOrderMaster.poNo = issueNo; //model.poNo;
            purchaseOrderMaster.paymentDate = model.paymentDate;
            purchaseOrderMaster.poDate = model.poDate;
            purchaseOrderMaster.supplierId = model.supplierId;
            purchaseOrderMaster.dealerId = model.dealerId;
            purchaseOrderMaster.rfqRef = model.rfqRef;
            purchaseOrderMaster.remarks = model.remarks;
            purchaseOrderMaster.billToLocation = model.billToLocation;
            purchaseOrderMaster.taxPercent = model.taxPercent;
            purchaseOrderMaster.vatPercent = model.vatPercent;

            purchaseOrderMaster.totalAmount = totalAmount;
            purchaseOrderMaster.netTotal = netAmount;
            purchaseOrderMaster.taxAmount = taxAmount;
            purchaseOrderMaster.vatAmount = vatAmount;
            purchaseOrderMaster.cdAmount = cdAmount;
            purchaseOrderMaster.sdAmount = sdAmount;
            purchaseOrderMaster.atAmount = atAmount;
            purchaseOrderMaster.rdAmount = rdAmount;
            purchaseOrderMaster.vds = model.vds;
            purchaseOrderMaster.companyId = 1;
            purchaseOrderMaster.isClose = 0;
            purchaseOrderMaster.isStockClose = 0;
            purchaseOrderMaster.createdBy = userName;
            purchaseOrderMaster.billOfEntryNo = model.billOfEntryNo;

            purchaseOrderMaster.lcNo = model.lcNo;
            purchaseOrderMaster.lcDate = model.lcDate;
            purchaseOrderMaster.countryId = model.countryId;
            purchaseOrderMaster.purchaseType = 1;

            int PID = await purchaseService.SavePurchaseOrderMaster(purchaseOrderMaster);

            if (model.purchaseOrderMasterId > 0)
            {
                await purchaseService.DeletePurchaseOrderDetailByPOId(Convert.ToInt32(PID));
            }
            if (model.quantity != null)
            {
                if (model.quantity.Length > 0)
                {

                    for (int i = 0; i < model.quantity.Length; i++)
                    {
                        PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();

                        purchaseOrderDetail.Id = 0;
                        purchaseOrderDetail.purchaseId = PID;
                       // purchaseOrderDetail.itemSpecification.Item.itemHsCode
                        purchaseOrderDetail.itemSpecificationId = Convert.ToInt32(model.itemSpecification[i]);
                        purchaseOrderDetail.quantity = model.quantity[i];
                        purchaseOrderDetail.rate = model.rate[i];

                        purchaseOrderDetail.vatAmount = model.vattotal[i];
                        purchaseOrderDetail.taxAmount = model.taxtotal[i];
                        purchaseOrderDetail.cdAmount = model.cdtotal[i];
                        purchaseOrderDetail.sdAmount = model.sdtotal[i];
                        purchaseOrderDetail.atAmount = model.attotal[i];
                        purchaseOrderDetail.rdAmount = model.rdtotal[i];

                        purchaseOrderDetail.vatPercent = model.vatPercentage[i];
                        purchaseOrderDetail.taxPercent = model.taxPercentage[i];
                        purchaseOrderDetail.cdPercent = model.cdPercentage[i];
                        purchaseOrderDetail.sdPercent = model.sdPercentage[i];
                        purchaseOrderDetail.atPercent = model.atPercentage[i];
                        purchaseOrderDetail.rdPercent = model.rdPercentage[i];

                        //purchaseOrderDetail.currencyId = 1;
                        await purchaseService.SavePurchaseOrderDetail(purchaseOrderDetail);
                        purchaseOrderDetail = new PurchaseOrderDetail();
                    }

                }
            }

            return Json(PID);

        }

        [HttpGet]
        public async Task<IActionResult> DealerPurchase(int? id)
        {
            ViewBag.masterId = id;
            var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var totalPurchase = await purchaseService.GetPurchaseOrderMasterTotalByDealerId(dealerId);
            int Cpurchase = 0;
            if (totalPurchase >0)
            {
                Cpurchase = totalPurchase;
            }
            string idate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            string issueNo = "Import" + '-' + idate + '-' + (Cpurchase + 1);
            
            if (Convert.ToInt32(id) != 0)
            {
                var data = await purchaseService.GetPurchaseOrderMasterById((int)id);
                issueNo = await purchaseService.GetPoNoByPOMId(id);
            }
            ViewBag.PurchaseNo = issueNo;
            PurchaseViewModel model = new PurchaseViewModel
            {
                purchaseVatTypes = await purchaseService.GetPurchaseVatType(),
                purchaseOrderMasters = await purchaseService.GetPurchaseOrderMaster(),
                specificationCategories = await ItemsService.GetAllSpecificationCategory(),
                countries = _country.GetAll(),
                dealers = _dealer.GetAll(),
                dealerId = dealerId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DealerPurchase([FromForm] PurchaseViewModel model)
        {
            var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var totalPurchase = await purchaseService.GetPurchaseOrderMasterTotalByDealerId(dealerId);
            int Cpurchase = 0;
            if (totalPurchase > 0)
            {
                Cpurchase = totalPurchase;
            }
            string idate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            string issueNo = "Import"   + idate +  (Cpurchase + 1);
            if (model.purchaseOrderMasterId > 0)
            {
                issueNo = model.poNo;
            }

            decimal vatAmount = 0;
            decimal taxAmount = 0;
            //decimal cdAmount = 0;
            //decimal sdAmount = 0;
            //decimal atAmount = 0;
           // decimal rdAmount = 0;
            decimal netAmount = 0;
            decimal assessableValue = 0;
            decimal totalAmount = 0;

            if (model.quantity != null)
            {
                if (model.quantity.Length > 0)
                {
                    for (int i = 0; i < model.quantity.Length; i++)
                    {
                        vatAmount += Convert.ToDecimal(model.vattotal[i]);
                        taxAmount += Convert.ToDecimal(model.taxtotal[i]);
                        //cdAmount += Convert.ToDecimal(model.cdtotal[i]);
                        //sdAmount += Convert.ToDecimal(model.sdtotal[i]);
                        //atAmount += Convert.ToDecimal(model.attotal[i]);
                        //rdAmount += Convert.ToDecimal(model.rdtotal[i]);
                        assessableValue = (Convert.ToDecimal(model.quantity[i]) * Convert.ToDecimal(model.rate[i]));
                        //totalAmount += assessableValue + Convert.ToDecimal(model.cdtotal[i]) + Convert.ToDecimal(model.sdtotal[i]) + Convert.ToDecimal(model.rdtotal[i]);
                        totalAmount += assessableValue;
                        //netAmount += assessableValue + Convert.ToDecimal(model.vattotal[i]) + Convert.ToDecimal(model.taxtotal[i]) + Convert.ToDecimal(model.cdtotal[i]) 
                           //+ Convert.ToDecimal(model.sdtotal[i]) + Convert.ToDecimal(model.attotal[i]) + Convert.ToDecimal(model.rdtotal[i]);
                        netAmount += assessableValue + Convert.ToDecimal(model.vattotal[i]) + Convert.ToDecimal(model.taxtotal[i]);
                    }
                }
            }

            PurchaseOrderMaster purchaseOrderMaster = new PurchaseOrderMaster
            {
                Id= Convert.ToInt32(model.purchaseOrderMasterId),
                purchaseVatTypeId = model.purchaseVatTypeId,
                poNo= issueNo,
                paymentDate = model.paymentDate,
                poDate = model.poDate,
                supplierId = model.supplierId,
                dealerId = dealerId,
                rfqRef = model.rfqRef,
                remarks = model.remarks,
                billToLocation = model.billToLocation,
                taxPercent = model.taxPercent,
                vatPercent = model.vatPercent,
                totalAmount = totalAmount,
                netTotal = netAmount,
                taxAmount = taxAmount,
                vatAmount = vatAmount,
                //cdAmount = cdAmount,
                //sdAmount = sdAmount,
                //atAmount = atAmount,
                //rdAmount = rdAmount,
                vds = model.vds,
                companyId = 1,
                isClose = 0,
                isStockClose = 0,
                billOfEntryNo = model.billOfEntryNo,
                lcNo = model.lcNo,
                lcDate = model.lcDate,
                countryId = model.countryId,
                purchaseType = 1
            };
            int PID = await purchaseService.SavePurchaseOrderMaster(purchaseOrderMaster);

            if (model.purchaseOrderMasterId > 0)
            {
                await purchaseService.DeletePurchaseOrderDetailByPOId(Convert.ToInt32(PID));
            }
            if (model.quantity != null)
            {
                if (model.quantity.Length > 0)
                {
                    for (int i = 0; i < model.quantity.Length; i++)
                    {
                        PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail
                        {
                            Id = 0,
                            purchaseId = PID,
                            itemSpecificationId = Convert.ToInt32(model.itemId[i]),
                            quantity = model.quantity[i],
                            rate = model.rate[i],
                            vatAmount = model.vattotal[i],
                            taxAmount = model.taxtotal[i],
                            //cdAmount = model.cdtotal[i],
                            //sdAmount = model.sdtotal[i],
                            //atAmount = model.attotal[i],
                            //rdAmount = model.rdtotal[i],
                            vatPercent = model.vatPercentage[i],
                            taxPercent = model.taxPercentage[i],
                            //cdPercent = model.cdPercentage[i],
                            //sdPercent = model.sdPercentage[i],
                            //atPercent = model.atPercentage[i],
                            //rdPercent = model.rdPercentage[i]
                        };
                        await purchaseService.SavePurchaseOrderDetail(purchaseOrderDetail);
                    }
                }
            }
            return Json(PID);
        }

        public async Task<IActionResult> PurchaseDetail(int Id)
        {
            try
            {
                ViewBag.masterId = Id;

                var CommentInfo = new List<Comment>();

                //var photoInfo = new List<DocumentAttachment>();

                //var docInfo = new List<DocumentAttachment>();

                var model = new PurchaseViewModel
                {
                    GetPurchaseOrderMasterById = await purchaseService.GetPurchaseOrderMasterById(Id),
                    purchaseOrderDetails = purchaseService.GetPurchaseOrderDetailByPOId(Id),

                    comments = CommentInfo,
                    //photoes = photoInfo,
                    //documents = docInfo,
                };
                string Val = model.GetPurchaseOrderMasterById.netTotal.ToString();
                ViewBag.InWord = AmountInWord.ConvertToWords(Val);
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        
        #region PDF
        [AllowAnonymous]
        public IActionResult PurchaseOrderPdfAction(int MasterId)
        {
            string userName = HttpContext.User.Identity.Name;
            string scheme = Request.Scheme;
            var host = Request.Host;

            string url = scheme + "://" + host + "/FAMSDEALER/Purchase/PurchaseInvoicePDF?MasterId=" + MasterId + "&userName=" + userName;

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
        public async Task<IActionResult> PurchaseInvoicePDF(int MasterId)
        {

            ViewBag.masterId = MasterId;
            var model = new PurchaseViewModel
            {
                GetPurchaseOrderMasterById = await purchaseService.GetPurchaseOrderMasterById(MasterId),
                purchaseOrderDetails = purchaseService.GetPurchaseOrderDetailByPOId(MasterId),
            };
            string Val = model.GetPurchaseOrderMasterById.netTotal.ToString();
            ViewBag.InWord = AmountInWord.ConvertToWords(Val);

            return PartialView(model);
        }
        #endregion

        public async Task<JsonResult> GetPurchaseOrderMasterById(int id)
        {
            var data = await purchaseService.GetPurchaseOrderMasterById(id);
            return Json(data);
        }

        public JsonResult GetPurchaseOrderDetailByPOId(int id)
        {
            var data = purchaseService.GetPurchaseOrderDetailByPOId(id);
            return Json(data);
        }

        #region Api
        [Route("global/api/GetAllItemForPurchase")]
        [HttpGet]
        public async Task<IActionResult> GetAllItemForRequisition()
        {
            var id = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            return Json(await _itemService.GetAllItemSpecByDealer(id));
        }
        #endregion
    }
}