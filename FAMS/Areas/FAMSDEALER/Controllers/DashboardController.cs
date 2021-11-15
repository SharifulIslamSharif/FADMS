using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.AuthService;
using FADMS.DAL.AuthService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class DashboardController : Controller
    {
        private readonly FADMSDbContext _context;
        private readonly ISalesService _salesService;
        private readonly IUserInfoes userInfoes;
        private readonly IDealerService  dealerService;

        public DashboardController(
            FADMSDbContext context,
            ISalesService salesService,
            IUserInfoes userInfoes,
            IDealerService dealerService
            )
        {
            _context = context;
            _salesService= salesService;
            this.userInfoes= userInfoes;
            this.dealerService= dealerService;
        }
        public IActionResult Index(int id)
        {
            ViewBag.masterId = id;
            var data = new DashboardViewModel
            {
                spSalesViewmodels = _context.spSalesViewmodels.FromSql($"SP_ItemCountForSalse"),
                spPurchases = _context.spPurchases.FromSql($"SP_PurchaseItemCount"),
            };
            return View(data);
        }

        public async Task<IActionResult> IndividualDash()
        {
            //var user = await userInfoes.GetUserInfoByUser(HttpContext.User.Identity.Name);
            var dealerId = await dealerService.GetDealerIdByUserName(HttpContext.User.Identity.Name);
            var data = new DashboardViewModel
            {
                //armTypes = armtyperepo.GetAll(),
                spSalesViewmodels =  dealerService.GetTotalSalesByArmsType(dealerId),
                spPurchases=  dealerService.GetTotalPurchaseByArmsType(dealerId)
            };
            return View(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllSalesInvoiceItemDetalis(int id)
        {
            var data = new DashboardViewModel
            {
                dashboardArmsTypeViewModels = await _salesService.GetAllSalesInvoiceItemDetalis(id),
            };
            return Json(data); 
        }
        [HttpGet]
        public async Task<JsonResult> GetDealerSalesInvoiceItemDetalis(int id)
        {
            var dealerId = await dealerService.GetDealerIdByUserName(HttpContext.User.Identity.Name);
            var data = new DashboardViewModel
            {
                dashboardArmsTypeViewModels = await _salesService.GetDealersSalesInvoiceItemDetalis(id ,dealerId),
            };
            return Json(data); 
        }

        [HttpGet]
        public async Task<JsonResult> GetAllPurchaseItemDetalis(int id)
        {
            var data = new DashboardViewModel
            {
                dashboardPurchaseViewModels = await _salesService.GetAllPurchaseItemDetalis(id),
            };
            return Json(data); 
        }
        [HttpGet]
        public async Task<JsonResult> GetDealerPurchaseItemDetalis(int id)
        {
            var dealerId = await dealerService.GetDealerIdByUserName(HttpContext.User.Identity.Name);

            var data = new DashboardViewModel
            {
                dashboardPurchaseViewModels = await _salesService.GetDealerPurchaseItemDetalis(id, dealerId),
            };
            return Json(data); 
        }
    }
}