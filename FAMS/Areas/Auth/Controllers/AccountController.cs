using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.Auth.Models;
using FADMS.Controllers;
using FADMS.DAL.AuthService.Interfaces;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity;
using FADMS.Data.Entity.Auth;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FADMS.Areas.Auth.Controllers
{
    [Authorize]
    [Area("Auth")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserInfoes userInfoes;
        private readonly IAddressService addressService;

        private readonly IRepository<Division> divisionRepository;
        private readonly IRepository<District> districtRepository;
        private readonly IRepository<UserType> userTypeRepository;
        //private readonly IDashboardService dashboardService;

        public AccountController(/*IDashboardService dashboardService,*/ IRepository<UserType> userTypeRepository, IRepository<Division> divisionRepository, IRepository<District> districtRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IUserInfoes userInfoes, IAddressService addressService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
            this.divisionRepository = divisionRepository;
            this.districtRepository = districtRepository;
            this.userTypeRepository = userTypeRepository;
            //this.dashboardService = dashboardService;
            this.addressService = addressService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var userInfos = await userInfoes.GetUserInfoByUser(model.Name);
                if (userInfos != null)
                {
                    if (userInfos.isActive == 1)
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: true);
                        if (result.Succeeded)
                        {
                            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                            var userAgent = Request.Headers["User-Agent"].ToString();
                            var mechineName = Environment.MachineName;

                            //var userRole = await userInfoes.GetUserRoleByUserName(model.Name);
                            var userRoleId = await userInfoes.GetUserRoleIdByUserName(model.Name);
                            //if (userRole == "General User")  //General User - Database
                            //if (userRoleId == "1d9b6cf4-f90b-4fcc-8849-214fba86b7de") // General User - Database
                            //{
                            //    var user = await userInfoes.GetUserInfoByUser(model.Name);
                            //    if (user.userType.userTypeName == "Personal")
                            //    {
                            //        int id = await userInfoes.GetPersonalIdByUserId(user.Id);
                            //        if (id != 0)
                            //        {
                            //            return RedirectToAction("PersonalMenu", "MenuforPersonal", new { @id = id, area = "FAMSDB" });
                            //        }
                            //        else
                            //        {
                            //            return RedirectToAction("TermsandConditions", "TermsandConditon", new { Areas = "Auth" });
                            //        }
                            //    }
                            //    else if (user.userType.userTypeName == "Organization")
                            //    {
                            //        int id = await userInfoes.GetOrganizationIdByUserId(user.Id);
                            //        if (id != 0)
                            //        {
                            //            return RedirectToAction("MenuOrg", "MenuforOrg", new { @id = id, area = "FAMSDB" });
                            //        }
                            //        else
                            //        {
                            //            return RedirectToAction("TermsandConditions", "TermsandConditon", new { Areas = "Auth" });
                            //        }

                            //    }
                            //    else if (user.userType.userTypeName == "FinancialOrganization")
                            //    {
                            //        int id = await userInfoes.GetOrganizationIdByUserId(user.Id);
                            //        if (id != 0)
                            //        {
                            //            return RedirectToAction("MenuOrg", "MenuforOrg", new { @id = id, area = "FAMSDB" });
                            //        }
                            //        else
                            //        {
                            //            return RedirectToAction("TermsandConditions", "TermsandConditon", new { Areas = "Auth" });
                            //        }
                            //    }

                            //}
                            //////else if (userRole == "Dealer Admin") 
                            if (userRoleId == "9ae09ccf-6fd3-4b36-aabb-95324e13485c")
                            {
                                return RedirectToAction("IndividualDash", "Dashboard", new { area = "FAMSDEALER" });
                            } 
                            //else if (userRole == "Dealer User") 
                            else if (userRoleId == "5774a0e1-f858-4d82-a29a-5b9b0e003afc")
                            {
                                return RedirectToAction("IndividualDash", "Dashboard", new { area = "FAMSDEALER" });
                            }
                            //else if (userRole == "Shooting Club") 
                            //else if (userRoleId == "9f7d3444-a94e-4634-8b44-5bdcf6b31ada")
                            //{
                            //    return RedirectToAction("ShooterMemberInfo", "ShootingClubInfo", new { area = "SHOOTINGCLUB" });
                            //}
                            //else if (userRole == "SbAdmin") 
                            //else if (userRoleId == "a3b6f86f-f910-4387-b579-041e4b8a1792")
                            //{
                            //    return RedirectToLocal(returnUrl);
                            //    // return RedirectToAction("Dashboard", "SpecialBrach", new { area = "FAMSDB" });
                            //}
                            //else if (userRoleId == "DC Admin") 
                            //else if (userRoleId == "ff3a9674-52d2-49ab-8250-9a372c66c464")
                            //{
                            //    return RedirectToAction("Dashboard", "DistrictCommissioner", new { area = "FAMSDB" });
                            //}
                            //else if (userRoleId == "Home Ministry") 
                            //else if (userRoleId == "9f76d74e-789b-4084-b5f4-fe882cc48c10")
                            //{
                            //    return RedirectToAction("Dashboard", "HomeMinistry", new { area = "FAMSDB" });
                            //}
                            //else if (userRoleId == "DistrictSbAdmin") 
                            //else if (userRoleId == "809f6aac-93dc-4407-a1f2-93be4f8f01f0" || userRoleId == "8211f581-a71e-4fc9-b5df-12b84d6aeec9")
                            //{
                            //    return RedirectToAction("DistrictDashboard", "License", new { area = "FAMSAPP" });
                            //}
                            //thana user
                            //else if (userRoleId == "95f288f0-a648-445a-8eb9-7c734257fab5")
                            //{
                            //    return RedirectToAction("ThanaDashboard", "License", new { area = "FAMSAPP" });
                            //}
                            //admin
                            //else if (userRoleId == "04AED4C4-EF8F-4704-9EC5-0B38CAAACBEB")
                            //{
                            //    return RedirectToLocal(returnUrl);
                            //}

                            //else
                            //{
                            //    return RedirectToLocal(returnUrl);
                            //}
                            //UserLogHistory userLog = new UserLogHistory
                            //{
                            //    userId = model.Name,
                            //    logTime = DateTime.Now,
                            //    status = 1,
                            //    ipAddress = ip,
                            //    pcName = mechineName,
                            //    browserName = userAgent
                            //};
                            //await dbChangeService.SaveUserLogHistory(userLog);
                            return RedirectToLocal(returnUrl);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }
            var model = new RegisterViewModel
            {
                userRoles = lstRole,
                //Designations = await _designationDepartmentService.GetDesignations(),
                //Ranks = await _rank.GetRanks(),
                //Sections = await _section.GetSections(),
                //Photographs = await _photograph.GetPhotographs(),
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = HttpContext.User.Identity.Name;
                //var userinfo = await userInfoes.GetUserInfoByUser(username);
                // var userinfo = await userInfoes.GetSbuIdByEmployeeEmail(model.Email);

                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    isActive = 1,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await _userManager.AddToRoleAsync(user, model.RoleId);
                    //IdentityUser temp = await _userManager.FindByNameAsync(model.Name);
                    //var emp = await personalInfoService.GetEmployeeInfoByCode(model.EmpCode);
                    //emp.ApplicationUserId = temp.Id;
                    //emp.rankId = model.RankName;
                    //emp.sectionId = model.SectionName;
                    //emp.designationsId = model.DesignationName;
                    //await personalInfoService.SaveEmployeeInfo(emp);
                    //return RedirectToLocal("/");
                }

                //string fileName;
                //string message = FileSave.SaveImage(out fileName, model.ImgeUrl);

                //if (model.EmpId != 0)
                //{
                //    if (message == "success")
                //    {
                //        Photograph data = new Photograph
                //        {
                //            Id = 0,
                //            employeeId = model.EmpId,
                //            url = fileName,
                //            type = "profile"
                //        };
                //        await _photograph.SavePhotograph(data);
                //    }
                //}


                AddErrors(result);
            }

            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }
            var formData = new RegisterViewModel
            {
                userRoles = lstRole,
                //Designations = await _designationDepartmentService.GetDesignations(),
                //Ranks = await _rank.GetRanks(),
                //Sections = await _section.GetSections(),
                //Photographs = await _photograph.GetPhotographs(),
            };
            return View(formData);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UserRoleCreate()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel model = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(model);
            }
            ApplicationRoleViewModel viewModel = new ApplicationRoleViewModel
            {
                fAMSModules = await userInfoes.GetAllFAMSModule(),
                roleViewModels = lstRole
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserIdentityRoleCreate([FromForm] ApplicationRoleViewModel model)
        {

            if (model.RoleId != null)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                role.Name = model.RoleName;
                IdentityResult result = await _roleManager.UpdateAsync(role);
            }
            else
            {
                var role = new ApplicationRole(model.RoleName);
                IdentityResult result = await _roleManager.CreateAsync(role);
            }
            return RedirectToAction(nameof(UserRoleCreate));
        }

        [HttpGet]
        public async Task<IActionResult> UserRoleAssign()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);

            }
            UserListViewModel model = new UserListViewModel
            {
                aspNetUsersViewModels = await userInfoes.GetUserInfoList(),
                userRoles = lstRole,
                modules = await userInfoes.GetAllMenu()
            };
            return View(model);
        }

        public async Task<IActionResult> DeleteRoles(string id)
        {
            try
            {
                await userInfoes.DeleteRoleById(id);
                return Json("Success");
            }
            catch
            {
                return Json("Roles is Already Assigned Someone!!");
            }
        }

        public async Task<IActionResult> DeleteMenu(string id)
        {
            try
            {
                //await userInfoes.DeleteMenuByRoleId(id);
                return RedirectToAction(nameof(UserRoleCreate));
            }
            catch
            {
                return RedirectToAction(nameof(UserRoleCreate));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteUserList()
        {
            UserListViewModel model = new UserListViewModel
            {
                // userBackUpViewModels = await userInfoes.GetUserBackupListWithEmp()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(string Id, int status)
        {
            await userInfoes.UpdateUserStatusByUserIdAndStatus(Id, status);
            string url = "";
            var userRoleId = await userInfoes.GetUserRoleIdByUserName(User.Identity.Name);
            //sbadmin & admin
            if (userRoleId == "9ae09ccf-6fd3-4b36-aabb-95324e13485c")
            {
                url = "/Auth/Account/UserList";
            }
           
            return Redirect(url);
            //return RedirectToAction(nameof(UserList));
        }

        [HttpGet]
        //public async Task<IActionResult> Delete(string Id)
        public async Task<IActionResult> Delete(string Id)
        {
            //string userName = HttpContext.User.Identity.Name;
            await userInfoes.DeleteUser(Id);
            return RedirectToAction(nameof(UserList));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> EditRole([FromForm] ApplicationRoleViewModel model)
        {
            var users = await userInfoes.GetUserInfoByUser(User.Identity.Name);
            ApplicationUser use = await _userManager.FindByNameAsync(model.userName);
            //var oldRoleId = _userManager.GetUsersInRoleAsync(model.userName);
            //var oldRoleName = _roleManager.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
            var user = new ApplicationUser
            {

                Id = (string)model.userId,
                isActive = 1,
                PersonName = model.personname,
                Email = model.email,
                bpNumbers = model.bpnumber,
                ranks = model.rank,
                PhoneNumber = model.phonenumber,
                //usersId = model.userId,
                //divisionId = divi,
                //districtId = dist,
                //thanaId = thna,
                createdAt = DateTime.Now
            };
            var result = await userInfoes.UpdateUserByUserid(user.Id, user.isActive, user.PersonName, user.Email, user.bpNumbers, user.ranks, user.PhoneNumber);
            //var result = await _userManager.UpdateAsync(user);


            if (model.PreRoleId != null)
            {
                await _userManager.RemoveFromRoleAsync(use, model.PreRoleId);
            }
            await _userManager.AddToRoleAsync(use, model.RoleId);

            string url = "";
            var userRoleId = await userInfoes.GetUserRoleIdByUserName(User.Identity.Name);
            //sbadmin & admin
            if (userRoleId == "9ae09ccf-6fd3-4b36-aabb-95324e13485c")
            {
                url = "/Auth/Account/UserList";
            }
           
            return Redirect(url);
            //return RedirectToAction(nameof(UserList));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            //var userinofs = await userInfoes.GetUserInfoByUser(HttpContext.User.Identity.Name);
            //var employeeinfo = await personalInfoService.GetEmployeeInfoByApplicationId(userinofs?.aspnetId);
            //UserLogHistory userLog = new UserLogHistory
            //{
            //    userId = HttpContext.User.Identity.Name,
            //    logTime = DateTime.Now,
            //    status = 0,
            //    ipAddress = ip
            //};
            //await dbChangeService.SaveUserLogHistory(userLog);
            //EmpAttendance empAttendance = new EmpAttendance
            //{
            //    punchCardNo = employeeinfo.employeeCode,
            //    startTime = DateTime.Now,
            //    summaryId = 1
            //};
            //await attendanceProcessService.SaveEmpAttendence(empAttendance);
            //_logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePsswordViewModel model)
        {
            string message = "Fail To Update Password";
            if (ModelState.IsValid)
            {
                var data = await _userManager.ChangePasswordAsync(await _userManager.FindByNameAsync(HttpContext.User.Identity.Name), model.OldPassword, model.Password);
                message = data.ToString();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home", new { Message = message });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword()
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel
            {
                //fLang = _lang.PerseLang("Auth/AuthEN.json", "Auth/AuthBN.json", Request.Cookies["lang"]),

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var userName = await personalInfoService.GetUserInfoByEmpCode(model.Name);
                    //var userName = await userInfoes.GetemployeebyempCode(model.Name);
                    ApplicationUser user = await _userManager.FindByNameAsync(model.Name);
                    var result = await _userManager.RemovePasswordAsync(user);
                    var results = await _userManager.AddPasswordAsync(user, model.Password);
                    string filter = model.Name;
                    if (results.Succeeded)
                    {
                        TempData["Success"] = "Password Changed Successfully!";
                    }
                    else
                    {
                        AddErrors(results);
                    }

                }
                //return View(model);
                //return Json("Password reset successfully");
                string url = "";
                var userRoleId = await userInfoes.GetUserRoleIdByUserName(User.Identity.Name);
                //sbadmin & admin
                if (userRoleId == "9ae09ccf-6fd3-4b36-aabb-95324e13485c")
                {
                    url = "/Auth/Account/UserList";
                }
               
                return Redirect(url);
                //return RedirectToAction("UserList");
            }
            catch (Exception ex)
            {
                return Json("Try again");
            }
        }

        [Authorize(Roles = "SuperAdmin, OPUSAdmin")]
        public async Task<IActionResult> UserProxyByAdmin()
        {
            string userName = HttpContext.User.Identity.Name;
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }
            UserListViewModel model = new UserListViewModel
            {
                userRoles = lstRole,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SwitchedUser(string userId, string securityCode)
        {
            string userName = HttpContext.User.Identity.Name;
            string returnUrl = "/";
            ApplicationUser user = await _userManager.FindByNameAsync(userId);
            if (user != null && securityCode == "BP.PSMS")
            {
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToLocal(returnUrl);

            }
            else
            {
                return RedirectToAction(nameof(UserProxyByAdmin));
            }
        }

        #region GeneralUser
        [AllowAnonymous]
        [HttpGet]
        public async Task<string> RestrictDuplicateUserName(string uName)
        {
            return await userInfoes.CheckUserName(uName);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<string> RestrictDuplicateEmail(string email)
        {
            return await userInfoes.CheckEmail(email);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GeneralRegister(string returnUrl = null)
        {
            var model = new RegisterViewModel
            {
                userTypes = userTypeRepository.GetAll(),
                //licenseTypes = await dashboardService.GetAllLicenseType(),
                divisions = divisionRepository.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GeneralRegister(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    isActive = 1,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    userTypeId = model.userTypeId,
                    divisionId = model.divisionId,
                    districtId = model.districtId,
                    thanaId = model.thanaId,
                    createdAt = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "General User");
                    var login = await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: true);
                    return RedirectToAction("TermsandConditions", "TermsandConditon", new { Area = "Auth" });
                }
                AddErrors(result);
            }

            return View();


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> NewGeneralRegister(string returnUrl = null)
        {
            var model = new RegisterViewModel
            {
                userTypes = userTypeRepository.GetAll(),
                //licenseTypes = await dashboardService.GetAllLicenseType(),
                divisions = divisionRepository.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> NewGeneralRegister(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    isActive = 1,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    userTypeId = model.userTypeId,
                    divisionId = model.divisionId,
                    districtId = model.districtId,
                    thanaId = model.thanaId,
                    createdAt = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "General User");
                    var login = await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: true);
                    return RedirectToAction("NewPersonEntry", "MenuforPersonal", new { Area = "FAMSDB" });
                }
                AddErrors(result);
            }

            return View();


        }
        #endregion

        #region User Management
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }

            UserListViewModel model = new UserListViewModel
            {
                aspNetUsersViewModels = await userInfoes.GetUserInfoList(),
                userRoles = lstRole,
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UserListForDistrict()
        {
            var us = await userInfoes.GetUserInfoByUser(User.Identity.Name);
            var users = await userInfoes.GetUserInfoByThana(User.Identity.Name);
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }

            UserListViewModel model = new UserListViewModel
            {
                applicationUser = users,
                aspNetUsersViewModels = await userInfoes.GetUserInfoListForDistrict(us.districtId),
                //userRoles = lstRole
                userRoles = lstRole.Where(x => x.RoleId == "95f288f0-a648-445a-8eb9-7c734257fab5" || x.RoleId == "8211f581-a71e-4fc9-b5df-12b84d6aeec9" || x.RoleId == "809f6aac-93dc-4407-a1f2-93be4f8f01f0"),
                divisions = divisionRepository.GetAll(),
                districts = districtRepository.GetAll(),
                thanas = await addressService.GetThanasByDistrictId((int)users.districtId),

            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }
            var model = new RegisterViewModel
            {
                userRoles = lstRole,
                //divisions = divisionRepository.GetAll(),
                vw_divisions = addressService.SpGetAllDivision(),
                dealers = await userInfoes.GetAllUncreatedDealers(),
               
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUserForDistrict(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            var users = await userInfoes.GetUserInfoByThana(User.Identity.Name);
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }
            var model = new RegisterViewModel

            {
                applicationUser = users,
                userRoles = lstRole.Where(x => x.RoleId == "95f288f0-a648-445a-8eb9-7c734257fab5" || x.RoleId == "8211f581-a71e-4fc9-b5df-12b84d6aeec9"),
                divisions = divisionRepository.GetAll(),
                districts = districtRepository.GetAll(),
                thanas = await addressService.GetThanasByDistrictId((int)users.districtId),
                dealers = await userInfoes.GetAllUncreatedDealers(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
        {
            try
            {
                var users = await userInfoes.GetUserInfoByUser(User.Identity.Name);
                if (ModelState.IsValid)
                {
                    // string username = HttpContext.User.Identity.Name;
                    int? dist;
                    int? divi;
                    int? thna;
                    if (model.districtId == 0)
                    {
                        dist = null;
                        divi = null;

                    }
                    else
                    {
                        dist = model.districtId;
                        divi = model.divisionId;

                    }
                    if (model.thanaId == 0)
                    {
                        thna = null;
                    }
                    else
                    {
                        thna = model.thanaId;
                    }
                    var user = new ApplicationUser
                    {
                        //Id=(string)model.EmpCode,
                        UserName = model.Name,
                        isActive = 1,
                        Email = model.Email,
                        bpNumbers = model.bpNumber,
                        ranks = model.rank,
                        PhoneNumber = model.PhoneNumber,
                        PersonName = model.personname,
                        divisionId = divi,
                        districtId = dist,
                        thanaId = thna,
                        createdAt = DateTime.Now
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {

                        await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (model.RoleName == "Dealer Admin" || model.RoleName == "Dealer User")
                        {
                            await userInfoes.UpdateDealerUserIdById(model.dealerId, user.Id);
                        }
                        


                        //IdentityUser temp = await _userManager.FindByNameAsync(model.Name);
                        //return RedirectToLocal(returnUrl);

                        //return RedirectToAction(nameof(UserList));
                        string url = "";
                        var userRoleId = await userInfoes.GetUserRoleIdByUserName(User.Identity.Name);
                        //sbadmin & admin
                        if (userRoleId == "9ae09ccf-6fd3-4b36-aabb-95324e13485c")
                        {
                            url = "/Auth/Account/UserList";
                        }
                        return Redirect(url);
                    }
                    AddErrors(result);
                }
                var roles = await _roleManager.Roles.ToListAsync();
                List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
                foreach (var data in roles)
                {
                    ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                    {
                        RoleId = data.Id,
                        RoleName = data.Name
                    };
                    lstRole.Add(modelr);
                }
                var formData = new RegisterViewModel
                {
                    userRoles = lstRole,
                    divisions = divisionRepository.GetAll()
                };
                return View(formData);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPost]
        public async Task<JsonResult> SaveUserMenuAccess(string UserTypeIds, int[] AllMenuIds)
        {
            await userInfoes.DeleteModuleAccesspageByUserTypeId(UserTypeIds);

            foreach (var app in AllMenuIds)
            {
                ModuleAccessPage UAP = new ModuleAccessPage();
                UAP.Id = 0;
                UAP.applicationRoleId = UserTypeIds;
                //UAP.isAccess = 1;
                //UAP.navbarId = Convert.ToInt32(app);
                UAP.eRPModuleId = Convert.ToInt32(app);

                await userInfoes.SaveUserAccessPage(UAP);
                UAP = new ModuleAccessPage();

            }
            return Json(new { result = "1" });
        }
        [HttpGet]
        public async Task<IActionResult> UserAssignPage(string userTypeId)
        {
            try
            {
                var data = await userInfoes.GetUserMenuAccessByUserType(userTypeId);
                return Json(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                //return Redirect(returnUrl);
                var userId = HttpContext.User.Identity.Name;

                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
            else
            {
                var userId = HttpContext.User.Identity.Name;

                return RedirectToAction(nameof(HomeController.Index), "Home");

            }
        }

        #endregion

      
    }
}