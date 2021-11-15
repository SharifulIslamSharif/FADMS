using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.DAL.Services.Interfaces;
using FADMS.Helpers;
using FADMS.Models;
using FADMS.Models.Lang;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly LangGenerate<DashBoardLN> _lang;
        //private readonly IDashboardService _dashboardService;

        public DashBoardController(IHostingEnvironment hostingEnvironment /*IDashboardService dashboardService*/)
        {
            _lang = new LangGenerate<DashBoardLN>(hostingEnvironment.ContentRootPath);
            //_dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DCDashboard()
        {
            ViewBag.UserTypeID = 6;
            var data = new DCDashboardViewModel
            { 
            fLang = _lang.PerseLang("Dashboard/DashboardEN.json", "Dashboard/DashboardBN.json", Request.Cookies["lang"]),
                //countries = _repoArm.GetAll(),
            };
            return View(data);
            
           
        }
        public IActionResult SBDashboard()
        {
            return View();
        }
        public IActionResult HomeMinistryDashboard()
        {
            var data = new HMDashboardViewModel
            {
                fLang = _lang.PerseLang("Dashboard/DashboardEN.json", "Dashboard/DashboardBN.json", Request.Cookies["lang"]),
                //countries = _repoArm.GetAll(),
            };
            return View(data);
        }
        public IActionResult SBAppDashboard()
        {
            var data = new SBAppDashboardViewModel
            {
                fLang = _lang.PerseLang("Dashboard/DashboardEN.json", "Dashboard/DashboardBN.json", Request.Cookies["lang"]),
                //countries = _repoArm.GetAll(),
            };
            return View(data);
        }


    }
}