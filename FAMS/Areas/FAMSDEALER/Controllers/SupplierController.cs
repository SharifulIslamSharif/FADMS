using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSAPP.Models;
using FADMS.Areas.FAMSDEALER.Models;

using FADMS.DAL.FamsDealerService.Interface;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class SupplierController : Controller
    {
        private readonly IRepository<Division> _division;
        private readonly IRepository<District> _district;
        private readonly IRepository<Thana> _thana;
        private readonly IRepository<Supplier> _supplier;
        private readonly IRepository<Dealer>  _dealer;
        private readonly IRepository<SupplierAddress> _supplierAddress;
        private readonly IRepository<SupplierType> _supplierType;
        private readonly IRepository<SupplierAddressCategory> _supplierAddressCategory;
        private readonly ISupplierService _supplierService;
        private readonly IRepository<Contact> _contact;
        private readonly IDealerService _dealerService;

        public SupplierController(
            IRepository<Division> division,
            IRepository<District> district,
            IRepository<Thana> thana,
            IRepository<Supplier> supplier,
            IRepository<Dealer> dealer,
            IRepository<Contact> contact,
            IRepository<SupplierAddress> supplierAddress,
            IRepository<SupplierType> supplierType,
            IRepository<SupplierAddressCategory> supplierAddressCategory,
            ISupplierService supplierService,
            IDealerService dealerService
            )
        {
            _division = division;
            _district = district;
            _thana = thana;
            _supplier = supplier;
            _dealer = dealer;
            _supplierAddress = supplierAddress;
            _supplierType = supplierType;
            _supplierAddressCategory = supplierAddressCategory;
            _supplierService = supplierService;
            _contact = contact;
            this._dealerService = dealerService;
        }
        public async Task<IActionResult> SupplierList()
        {
            var supplier = new SupplierViewModel
            {
                suppliers = await _supplierService.GetSuppliers(),
            };
            return View(supplier);
        }


        public IActionResult SupplierMenu(int id)
        {
            var data = new SupplierMenuViewModel
            {
                supplier = _supplier.Get(id),
            };
            return View(data);
        }

        #region Add Supplier
        [HttpGet]
        public async Task<IActionResult> DealerSupplier(int id)
        {
            ViewBag.SupplierId = id;
            var data = new SupplierViewModel
            {
                supplier = _supplier.Get(id),
                suppliers = _supplier.GetAll(),
                supplierTypes = _supplierType.GetAll(),
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> DealerSupplier([FromForm] SupplierViewModel model)
        {
            var data = new Supplier
            {
                Id = model.supplierId,
                supplierName = model.supplierName,
                supplierNameBn = model.supplierNameBn,
                LicenseNumber = model.LicenseNumber,
                registeredAddress = model.registeredAddress,
                eTinNumber = model.eTinNumber,
                binNumber = model.binNumber,
                VATNumber = model.VATNumber,
                email = model.email,
                alternativeEmail = model.alternativeEmail,
                mobile = model.mobile,
                phone = model.phone,
                supplierTypeId = model.supplierTypeId,
                DealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name)
            };
            if (model.supplierId > 0)
            {
                _supplier.Update(data);
            }
            else
            {
                _supplier.Insert(data);
            }
            return RedirectToAction("SupplierListForDealer");
        }

        [HttpGet]
        public async Task<IActionResult> SupplierListForDealer()
        {
            var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var supplier = new SupplierViewModel
            {
                suppliers = await _supplierService.GetSuppliersbyDealer(dealerId),
            };
            return View(supplier);
        }
        [HttpGet]
        public IActionResult AddSupplier(int id)
        {
            ViewBag.SupplierId = id;
            var data = new SupplierViewModel
            {
                supplier = _supplier.Get(id),
                suppliers = _supplier.GetAll(),
                dealers=_dealer.GetAll(),
                supplierTypes = _supplierType.GetAll(),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult AddSupplier([FromForm] SupplierViewModel model)
        {
            var data = new Supplier
            {
                Id = model.supplierId,
                supplierName = model.supplierName,
                supplierNameBn = model.supplierNameBn,
                LicenseNumber = model.LicenseNumber,
                registeredAddress = model.registeredAddress,
                eTinNumber = model.eTinNumber,
                binNumber = model.binNumber,
                VATNumber = model.VATNumber,
                email = model.email,
                alternativeEmail = model.alternativeEmail,
                mobile = model.mobile,
                phone = model.phone,
                supplierTypeId = model.supplierTypeId,
                DealerId = model.DealerId,
            };
            if (model.supplierId > 0)
            {
                _supplier.Update(data);
            }
            else
            {
                _supplier.Insert(data);
            }
            return RedirectToAction(nameof(SupplierList));
        }

        [HttpGet]
        public IActionResult SupplierTypeAdd(int id)
        {
            ViewBag.SupplierTypeId = id;
            var data = new SupplierViewModel
            {
                supplierType = _supplierType.Get(id),
                supplierTypes = _supplierType.GetAll(),
            };
            return View(data);
        }
         [HttpPost]
        public IActionResult SupplierTypeAdd([FromForm] SupplierViewModel model)
        {
            var data = new SupplierType
            {
                Id=model.supplierId,
                supplierTypeName = model.supplierName, 
            };
            if (model.supplierId > 0)
            {
                _supplierType.Update(data);
            }
            else
            {
                _supplierType.Insert(data);
            }
            return View(data);   
        }
         [HttpGet]
        public IActionResult SupplierFileUpload(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SupplierFileUpload([FromForm] UploadExcelViewModel model)
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

                var supplierTypes = _supplierType.GetAll();


                if (supplierTypes.Count() <= 0)
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

                            string supplierName = worksheet.Cells[row, 1].Value == null ? "" : worksheet.Cells[row, 1].Value.ToString().Trim();
                            string licenseNumber = worksheet.Cells[row, 2].Value == null ? "" : worksheet.Cells[row, 2].Value.ToString().Trim();
                            string address = worksheet.Cells[row, 3].Value == null ? "" : worksheet.Cells[row, 3].Value.ToString().Trim();
                            string tin = worksheet.Cells[row, 4].Value == null ? "" : worksheet.Cells[row, 4].Value.ToString().Trim();
                            string binNumber = worksheet.Cells[row, 5].Value == null ? "" : worksheet.Cells[row, 5].Value.ToString().Trim();
                            string vatNo = worksheet.Cells[row, 6].Value == null ? "" : worksheet.Cells[row, 6].Value.ToString().Trim();
                            string email = worksheet.Cells[row, 7].Value == null ? "" : worksheet.Cells[row, 7].Value.ToString().Trim();
                            string alternativeEmail = worksheet.Cells[row, 8].Value == null ? "" : worksheet.Cells[row, 8].Value.ToString().Trim();
                            string mobile = worksheet.Cells[row, 9].Value == null ? "" : worksheet.Cells[row, 9].Value.ToString().Trim();
                            string phone = worksheet.Cells[row, 10].Value == null ? "" : worksheet.Cells[row, 10].Value.ToString().Trim();
                            string suppliertype = worksheet.Cells[row, 11].Value == null ? "" : worksheet.Cells[row, 11].Value.ToString().Trim();


                            var supplierInfo = supplierTypes.Where(a => a.supplierTypeName.Contains(suppliertype)).FirstOrDefault();

                            if (supplierInfo == null)
                            {
                                continue;
                            }

                            var data = new Supplier()
                            {
                                createdAt = DateTime.Now,
                                Id = Convert.ToInt32(model.dealerId),
                                supplierName = supplierName,
                                LicenseNumber = licenseNumber,
                                registeredAddress = address,
                                eTinNumber = tin,
                                binNumber = binNumber,
                                VATNumber = vatNo,
                                email = email,
                                alternativeEmail = alternativeEmail,
                                mobile = mobile,
                                phone = phone,
                                supplierTypeId = supplierInfo.Id,
                            };

                            _supplier.Insert(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/FAMSDEALER/Supplier/SupplierList/" + model.dealerId);
        }
        #endregion


        #region Api

        [HttpGet]
        public JsonResult DivisionInfoList(int id)
        {
            var data = new SupplierViewModel
            {
                divisions = _division.GetAll().Where(x => x.countryId == id),
            };
            return Json(data);
        }

        [HttpGet]
        public JsonResult DistrictInfoList(int id)
        {
            var data = new SupplierViewModel
            {
                districts = _district.GetAll().Where(x => x.divisionId == id),
            };
            return Json(data);
        }
        public JsonResult ThanaInfoList(int id)
        {
            var data = new SupplierViewModel
            {
                thanas = _thana.GetAll().Where(x => x.districtId == id),
            };
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetGetSupplierForPurchaseByRoleId()
        {
            var id = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var suppliers = await _supplierService.GetSuppliersbyDealer(id);
            return Json(suppliers);
        }
        #endregion

        #region Address
        [HttpGet]
        public async Task<IActionResult> Address(int id)
        {
            ViewBag.supplierId = id;
            var data = new SupplierViewModel
            {
                divisions = _division.GetAll(),
                supplierAddresses = await _supplierService.GetSupplierAddresses(),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult Address([FromForm] SupplierViewModel model)
        {
            var data = new SupplierAddress
            {
                Id = model.supplierAddressId,
                supplierId = model.supplierId,
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
            if (model.supplierAddressId > 0)
            {
                _supplierAddress.Update(data);
            }
            else
            {
                _supplierAddress.Insert(data);
            }
            return RedirectToAction(nameof(Address));
        }



        [HttpGet]
        public IActionResult AddressFileUpload(int id)
        {
            ViewBag.supplierId = id;
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

                            var data = new SupplierAddress()
                            {
                                createdAt = DateTime.Now,
                                supplierId = model.supplierId,
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

                            _supplierAddress.Insert(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/FAMSDEALER/Supplier/Address/" + model.supplierId);
        }

        #endregion

        #region Contact
        public IActionResult Contact(int id)
        {
            ViewBag.supplierId = id;
            var data = new SupplierViewModel
            {
                contacts = _contact.GetAll().Where(x => x.supplierId == id),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult Contact([FromForm] SupplierViewModel model)
        {
            var data = new Contact
            {
                Id = model.contactId,
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
            ViewBag.supplierId = id;
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
                                supplierId = model.supplierId,
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
            return Redirect("/FAMSDEALER/Supplier/Contact/" + model.supplierId);
        }

        #endregion


        
    }
}