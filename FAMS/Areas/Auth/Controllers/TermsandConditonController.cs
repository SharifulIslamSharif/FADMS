using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.Auth.Models;
using FADMS.DAL.AuthService.Interfaces;
using FADMS.Data.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.Auth.Controllers
{
    [Area("Auth")]
    [Authorize]
    public class TermsandConditonController : Controller
    {
        private readonly IUserInfoes userInfoes;

        public TermsandConditonController(IUserInfoes userInfoes)
        {
            this.userInfoes = userInfoes;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> TermsandConditions()
        {
            //var userName = HttpContext.User.Identity.Name;
            //if (userName == null)
            //{
            //    return RedirectToAction("Login", "Account", new { area = "Auth" });
            //}
            RegisterViewModel model = new RegisterViewModel
            {
                aspNetUsers = await userInfoes.GetUserInfoList()
            };
          
            return View();
        }
    }
}