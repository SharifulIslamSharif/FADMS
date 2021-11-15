using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSAPP.Models;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.AuthService.Interfaces;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class DealerController : Controller
    {
        private readonly IRepository<Division> _division;
        private readonly IRepository<District> _district;
        private readonly IRepository<Thana> _thana;
        private readonly IRepository<Dealer> _dealer;
        private readonly IRepository<Supplier> _supplier;
        private readonly IRepository<DealerAddress> _dealerAddress;
        private readonly IRepository<DealerType> _dealerType;
        private readonly IRepository<Contact> _contact;
        private readonly IRepository<DealerAddressCategory> _dealerAddressCategory;
        private readonly IDealerService _dealerService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserInfoes userInfoes;
        
        public DealerController(
            IRepository<Division> division,
            IRepository<District> district,
            IRepository<Thana> thana,

            IRepository<Dealer> dealer,
            IRepository<Supplier> supplier,
            IRepository<Contact> contact,
            IRepository<DealerAddress> dealerAddress,
            IRepository<DealerType> dealerType,
            IRepository<DealerAddressCategory> dealerAddressCategory,
            IDealerService dealerService,
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<ApplicationRole> roleManager, 
            IUserInfoes userInfoes
            )
        {
            _division = division;
            _district = district;
            _thana = thana; 
            _dealer = dealer;
            _supplier = supplier;
            _dealerAddress = dealerAddress;
            _dealerType = dealerType;
            _contact = contact;
            _dealerAddressCategory = dealerAddressCategory;
            _dealerService = dealerService;

            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
        }

        public IActionResult DealerList()
        {
            var supplier = new DealerViewModel
            {
                dealers = _dealer.GetAll(),
            };
            return View(supplier);
        }


        public IActionResult DealerMenu(int id)
        {
            var data = new DealerMenuViewModel
            {
                dealer = _dealer.Get(id),
            };
            return View(data);
        }

        #region Add Dealer
        public IActionResult AddDealer(int id)
        {
            ViewBag.DealerId = id;
            var data = new DealerViewModel
            {
                dealer = _dealer.Get(id),
                dealers = _dealer.GetAll(),
                dealerTypes = _dealerType.GetAll(),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult AddDealer([FromForm] DealerViewModel model)
        {
            var data = new Dealer
            {
                Id = model.dealerId,
                dealerName = model.dealerName,
                dealerNameBn = model.dealerNameBn,
                LicenseNumber = model.LicenseNumber,
                registeredAddress = model.registeredAddress,
                eTinNumber = model.eTinNumber,
                binNumber = model.binNumber,
                VATNumber = model.VATNumber,
                email = model.email,
                alternativeEmail = model.alternativeEmail,
                mobile = model.mobile,
                phone = model.phone,

            };
            if (model.dealerId > 0)
            {
                _dealer.Update(data);
            }
            else
            {
                _dealer.Insert(data);
            }
            return Json(data.Id);
            //return RedirectToAction(nameof(DealerList));
        }

        public async Task<IActionResult> CheckUniqueLicenseNo(string lino)
        {
            var result = await _dealerService.CheckDealerUniqueLiByLiNumber(lino);
            return Json(result);
        }

        [HttpGet]
        public IActionResult DealerFileUpload(int id)
        {
            //ViewBag.personalInfoId = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DealerFileUpload([FromForm] UploadExcelViewModel model)
        {


            if (model.file == null || model.file.Length <= 0)
            {
                return Json("formfile is empty");
            }

            if (!Path.GetExtension(model.file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return Json("Not Support file extension");
            }
            try
            {
               
                var dealerTypes = _dealerType.GetAll();

               
                if (dealerTypes.Count() <= 0)
                {
                    return Json("There are no dealer type found");
                }
         
                Random r = new Random();
                var x = r.Next(0, 10000000);
                string fileNo = "FU_" + DateTime.Now.ToString("MMddyyyyHHmmss");



                using (var stream = new MemoryStream())
                {
                    await model.file.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            if (worksheet.Cells[row, 1].Value == null) continue;
                            else if (worksheet.Cells[row, 2].Value == null) continue;
                            else if (worksheet.Cells[row, 3].Value == null) continue;
                            else if (worksheet.Cells[row, 4].Value == null) continue;
                            else if (worksheet.Cells[row, 5].Value == null) continue;
                            else if (worksheet.Cells[row, 6].Value == null) continue;
                            else if (worksheet.Cells[row, 7].Value == null) continue;
                            else if (worksheet.Cells[row, 8].Value == null) continue;
                            else if (worksheet.Cells[row, 9].Value == null) continue;
                            else if (worksheet.Cells[row, 10].Value == null) continue;
                            else if (worksheet.Cells[row, 11].Value == null) continue;

                            string dealername = worksheet.Cells[row, 1].Value == null ? "" : worksheet.Cells[row, 1].Value.ToString().Trim();
                            string licenseNumber = worksheet.Cells[row, 2].Value == null ? "" : worksheet.Cells[row, 2].Value.ToString().Trim();
                            string address = worksheet.Cells[row, 3].Value == null ? "" : worksheet.Cells[row, 3].Value.ToString().Trim();
                            string tin = worksheet.Cells[row, 4].Value == null ? "" : worksheet.Cells[row, 4].Value.ToString().Trim();
                            string binNumber = worksheet.Cells[row, 5].Value == null ? "" : worksheet.Cells[row, 5].Value.ToString().Trim();
                            string vatNo = worksheet.Cells[row, 6].Value == null ? "" : worksheet.Cells[row, 6].Value.ToString().Trim();
                            string email = worksheet.Cells[row, 7].Value == null ? "" : worksheet.Cells[row, 7].Value.ToString().Trim();
                            string alternativeEmail = worksheet.Cells[row, 8].Value == null ? "" : worksheet.Cells[row, 8].Value.ToString().Trim();
                            string mobile = worksheet.Cells[row, 9].Value == null ? "" : worksheet.Cells[row, 9].Value.ToString().Trim();
                            string phone = worksheet.Cells[row, 10].Value == null ? "" : worksheet.Cells[row, 10].Value.ToString().Trim();
                            string dealerType = worksheet.Cells[row, 11].Value == null ? "" : worksheet.Cells[row, 11].Value.ToString().Trim();


                            var dealerInfo = dealerTypes.Where(a => a.dealerTypeName.Contains(dealerType)).FirstOrDefault();

                            if (dealerInfo == null)
                            {
                                continue;
                            }

                            var data = new Dealer()
                            {
                                createdAt = DateTime.Now,
                                Id = Convert.ToInt32(model.dealerId),
                                dealerName = dealername,
                                LicenseNumber = licenseNumber,
                                registeredAddress = address,
                                eTinNumber = tin,
                                binNumber = binNumber,
                                VATNumber = vatNo,
                                email = email,
                                alternativeEmail = alternativeEmail,
                                mobile = mobile,
                                phone = phone,
                                dealerTypeId = dealerInfo.Id,
                            };

                            _dealer.Insert(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/FAMSDEALER/Dealer/DealerList/" + model.dealerId);
        }

        #endregion


        [HttpGet]
        public JsonResult DivisionInfoList(int id)
        {
            var data = new DealerViewModel
            {
                divisions = _division.GetAll().Where(x => x.countryId == id),
            };
            return Json(data);
        }

        [HttpGet]
        public JsonResult DistrictInfoList(int id)
        {
            var data = new DealerViewModel
            {
                districts = _district.GetAll().Where(x => x.divisionId == id),
            };
            return Json(data);
        }
        public JsonResult ThanaInfoList(int id)
        {
            var data = new DealerViewModel
            {
                thanas = _thana.GetAll().Where(x => x.districtId == id),
            };
            return Json(data);
        }

        #region Address
        public async Task<IActionResult> Address(int id)
        {
            ViewBag.DealerId = id;
            var data = new DealerViewModel
            {
                divisions = _division.GetAll(),
                dealerAddresses = await _dealerService.GetDealerAddresses(),

            };
            return View(data);
        }
        [HttpPost]
        public IActionResult Address([FromForm] DealerViewModel model)
        {
            var data = new DealerAddress
            {
                Id = model.dealerIdAddressId,
                dealerId = model.dealerId,
                countryId = model.countryId,
                divisionId = model.divisionId,
                districtId = model.districtId,
                thanaId = model.thanaId,
                union = model.union,
                postCode = model.postCode,
                postOffice = model.postOffice,
                blockSector = model.blockSector,
                houseVillage = model.houseVillage,
                type = model.type,
            };
            if (model.dealerIdAddressId > 0)
            {
                _dealerAddress.Update(data);
            }
            else
            {
                _dealerAddress.Insert(data);
            }
            return RedirectToAction(nameof(Address));
        }


        [HttpGet]
        public IActionResult AddressFileUpload(int id)
        {
            ViewBag.dealerId = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddressFileUpload([FromForm] UploadExcelViewModel model)
        {


            if (model.file == null || model.file.Length <= 0)
            {
                return Json("formfile is empty");
            }

            if (!Path.GetExtension(model.file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return Json("Not Support file extension");
            }
            try
            {
                var divisions = _division.GetAll();
                var districts = _district.GetAll();
                var thanas = _thana.GetAll();

                if (divisions.Count() <= 0)
                {
                    return Json("There are no division found");
                }
                if (districts.Count() <= 0)
                {
                    return Json("There are no district found");
                }
                if (thanas.Count() <= 0)
                {
                    return Json("There are no thana found");
                }

                Random r = new Random();
                var x = r.Next(0, 10000000);
                string fileNo = "FU_" + DateTime.Now.ToString("MMddyyyyHHmmss");



                using (var stream = new MemoryStream())
                {
                    await model.file.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            if (worksheet.Cells[row, 1].Value == null) continue;
                            else if (worksheet.Cells[row, 2].Value == null) continue;
                            else if (worksheet.Cells[row, 3].Value == null) continue;
                            else if (worksheet.Cells[row, 4].Value == null) continue;
                            else if (worksheet.Cells[row, 5].Value == null) continue;
                            else if (worksheet.Cells[row, 6].Value == null) continue;
                            else if (worksheet.Cells[row, 7].Value == null) continue;
                            else if (worksheet.Cells[row, 8].Value == null) continue;
                            else if (worksheet.Cells[row, 9].Value == null) continue;


                            string addresstype = worksheet.Cells[row, 1].Value == null ? "" : worksheet.Cells[row, 1].Value.ToString().Trim();
                            string houseVillage = worksheet.Cells[row, 2].Value == null ? "" : worksheet.Cells[row, 2].Value.ToString().Trim();
                            string blockSector = worksheet.Cells[row, 3].Value == null ? "" : worksheet.Cells[row, 3].Value.ToString().Trim();
                            string union = worksheet.Cells[row, 4].Value == null ? "" : worksheet.Cells[row, 4].Value.ToString().Trim();
                            string postCode = worksheet.Cells[row, 5].Value == null ? "" : worksheet.Cells[row, 5].Value.ToString().Trim();
                            string postOffice = worksheet.Cells[row, 6].Value == null ? "" : worksheet.Cells[row, 6].Value.ToString().Trim();
                            string division = worksheet.Cells[row, 7].Value == null ? "" : worksheet.Cells[row, 7].Value.ToString().Trim();
                            string district = worksheet.Cells[row, 8].Value == null ? "" : worksheet.Cells[row, 8].Value.ToString().Trim();
                            string thana = worksheet.Cells[row, 9].Value == null ? "" : worksheet.Cells[row, 9].Value.ToString().Trim();

                            var divisionInfo = divisions.Where(a => a.divisionName.Contains(division)).FirstOrDefault();

                            if (divisionInfo == null)
                            {
                                continue;
                            }

                            var districtinfo = districts.Where(a => a.districtName.Contains(district)).FirstOrDefault();

                            if (districtinfo == null)
                            {
                                continue;
                            }

                            var thanaInfo = thanas.Where(a => a.thanaName.Contains(thana)).FirstOrDefault();

                            if (thanaInfo == null)
                            {
                                continue;
                            }

                            var data = new DealerAddress()
                            {
                                createdAt = DateTime.Now,
                                dealerId = model.dealerId,
                                type = addresstype,
                                houseVillage = houseVillage,
                                blockSector = blockSector,
                                union = union,
                                postCode = postCode,
                                postOffice = postOffice,
                                divisionId = divisionInfo.Id,
                                districtId = districtinfo.Id,
                                thanaId = thanaInfo.Id,

                            };

                            _dealerAddress.Insert(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/FAMSDEALER/Dealer/Address/" + model.dealerId);
        }

        #endregion

        #region Contact
        public IActionResult Contact(int id)
        {
            ViewBag.DealerId = id;
            var data = new DealerViewModel
            {
                contacts = _contact.GetAll().Where(x=>x.dealerId==id),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult Contact([FromForm] DealerViewModel model)
        {
            var data = new Contact
            {
                Id = model.contactId,
                dealerId = model.dealerId,
                Department = model.Department,
                Designation = model.Designation,
                personName = model.personName,
                phoneNumber = model.phoneNumber,
                mobileNumber = model.mobileNumber,
            };
            if (model.contactId > 0)
            {
                _contact.Update(data);
            }
            else
            {
                _contact.Insert(data);
            }
            return RedirectToAction(nameof(Contact));
        }



        [HttpGet]
        public IActionResult ContactFileUpload(int id)
        {
            ViewBag.dealerId = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ContactFileUpload([FromForm] UploadExcelViewModel model)
        {


            if (model.file == null || model.file.Length <= 0)
            {
                return Json("formfile is empty");
            }

            if (!Path.GetExtension(model.file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return Json("Not Support file extension");
            }
            try
            {
          
                Random r = new Random();
                var x = r.Next(0, 10000000);
                string fileNo = "FU_" + DateTime.Now.ToString("MMddyyyyHHmmss");



                using (var stream = new MemoryStream())
                {
                    await model.file.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            if (worksheet.Cells[row, 1].Value == null) continue;
                            else if (worksheet.Cells[row, 2].Value == null) continue;
                            else if (worksheet.Cells[row, 3].Value == null) continue;
                            else if (worksheet.Cells[row, 4].Value == null) continue;
                            else if (worksheet.Cells[row, 5].Value == null) continue;
                       


                            string personName = worksheet.Cells[row, 1].Value == null ? "" : worksheet.Cells[row, 1].Value.ToString().Trim();
                            string department = worksheet.Cells[row, 2].Value == null ? "" : worksheet.Cells[row, 2].Value.ToString().Trim();
                            string designation = worksheet.Cells[row, 3].Value == null ? "" : worksheet.Cells[row, 3].Value.ToString().Trim();
                            string phoneNumber = worksheet.Cells[row, 4].Value == null ? "" : worksheet.Cells[row, 4].Value.ToString().Trim();
                            string mobileNumber = worksheet.Cells[row, 5].Value == null ? "" : worksheet.Cells[row, 5].Value.ToString().Trim();


                       
                            var data = new Contact()
                            {
                                createdAt = DateTime.Now,
                                dealerId = model.dealerId,
                                personName = personName,
                                Department = department,
                                Designation = designation,
                                phoneNumber = phoneNumber,
                                mobileNumber = mobileNumber

                            };

                            _contact.Insert(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/FAMSDEALER/Dealer/Contact/" + model.dealerId);
        }
        #endregion
        #region Dealer Service
        public async Task<IActionResult> DepositeList()
        {
            var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var data = new GunDepositeViewModel
            {
               
            };
            return View(data);
            
        }
        public async Task<IActionResult> RepairList()
        {
            var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var data = new GunRepairViewModel
            {

            };
            return View(data);
        }
        #endregion
    }
}