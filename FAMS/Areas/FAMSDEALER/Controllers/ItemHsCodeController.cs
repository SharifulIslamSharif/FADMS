using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSAPP.Models;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.Data.Entity.Dealer;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class ItemHsCodeController : Controller
    {
        private readonly IRepository<ItemHsCode> _itemHsCode;
        private readonly IRepository<TaxYear> _taxYear;
        private readonly IRepository<VatCategory> _vatCategory;
        private readonly IRepository<VATSchedule> _vatShedule;
        private readonly IRepository<VatTable> _vatTable;

        public ItemHsCodeController(
            
            IRepository<ItemHsCode> itemHsCode,
            IRepository<TaxYear> taxYear,
            IRepository<VatCategory> vatCategory,
            IRepository<VATSchedule> vatShedule,
            IRepository<VatTable> vatTable
            
            )
        {
            _itemHsCode = itemHsCode;
            _taxYear = taxYear;
            _vatCategory = vatCategory;
            _vatShedule = vatShedule;
            _vatTable = vatTable;
        }
        public IActionResult ItemHsCode()
        {
            var data = new ItemHsCodeViewModel
            {
                itemHsCodes = _itemHsCode.GetAll(),
                taxYears = _taxYear.GetAll(),
                vatCategories = _vatCategory.GetAll(),
                vatTables = _vatTable.GetAll(),
                vATSchedules = _vatShedule.GetAll(),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult ItemHsCode([FromForm] ItemHsCodeViewModel model)
        {
            var data = new ItemHsCode
            {
                Id=model.itemHsCodeId,
                vatCategoryId=model.vatCategoriesId,
                vATScheduleId=model.vatScheduleId,
                vatTableId=model.vatTableId,
                taxYearId=model.taxYearId,
                hsCode=model.hsCode,
                CD=model.CD,
                SD=model.SD,
                VAT=model.VAT,
                AIT=model.AIT,
                AT=model.AT,
                RD=model.RD,
                EXD=model.EXD,
                TTI=model.TTI,
                hsDescription=model.hsDescription

            };
            if (model.itemHsCodeId>0)
            {
                _itemHsCode.Update(data);
            }
            else
            {
                _itemHsCode.Insert(data);
            }
            return RedirectToAction(nameof(ItemHsCode));
        }

        [HttpGet]
        public IActionResult ItemHsFileUpload(int id)
        {
            ViewBag.personalInfoId = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ItemHsFileUpload([FromForm] UploadExcelViewModel model)
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
                var taxYears = _taxYear.GetAll();
                var vatCategories = _vatCategory.GetAll();
                var vatSchedules = _vatShedule.GetAll();
                var vatTables = _vatTable.GetAll();

                if (taxYears.Count() <= 0)
                {
                    return Json("There are no tax year found");
                }
                if (vatCategories.Count() <= 0)
                {
                    return Json("There are no vat category found");
                }
                if (vatSchedules.Count() <= 0)
                {
                    return Json("There are no vat schedule found");
                }
                if (vatTables.Count() <= 0)
                {
                    return Json("There are no vat table found");
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
                            else if (worksheet.Cells[row, 12].Value == null) continue;
                            else if (worksheet.Cells[row, 13].Value == null) continue;
                            else if (worksheet.Cells[row, 14].Value == null) continue;
                            else if (worksheet.Cells[row, 15].Value == null) continue;


                            string hsCode = worksheet.Cells[row, 1].Value == null ? "" : worksheet.Cells[row, 1].Value.ToString().Trim();
                            string validFromDate = worksheet.Cells[row, 2].Value == null ? "" : worksheet.Cells[row, 2].Value.ToString().Trim();
                            string vatCategory = worksheet.Cells[row, 3].Value == null ? "" : worksheet.Cells[row, 3].Value.ToString().Trim();
                            string vatSchedule = worksheet.Cells[row, 4].Value == null ? "" : worksheet.Cells[row, 4].Value.ToString().Trim();
                            string vatTable = worksheet.Cells[row, 5].Value == null ? "" : worksheet.Cells[row, 5].Value.ToString().Trim();
                            string taxYear = worksheet.Cells[row, 6].Value == null ? "" : worksheet.Cells[row, 6].Value.ToString().Trim();
                            string cd = worksheet.Cells[row, 7].Value == null ? "" : worksheet.Cells[row, 7].Value.ToString().Trim();
                            string sd = worksheet.Cells[row, 8].Value == null ? "" : worksheet.Cells[row, 8].Value.ToString().Trim();
                            string vat = worksheet.Cells[row, 9].Value == null ? "" : worksheet.Cells[row, 9].Value.ToString().Trim();
                            string ait = worksheet.Cells[row, 10].Value == null ? "" : worksheet.Cells[row, 10].Value.ToString().Trim();
                            string at = worksheet.Cells[row, 11].Value == null ? "" : worksheet.Cells[row, 11].Value.ToString().Trim();
                            string rd = worksheet.Cells[row, 12].Value == null ? "" : worksheet.Cells[row, 12].Value.ToString().Trim();
                            string exd = worksheet.Cells[row, 13].Value == null ? "" : worksheet.Cells[row, 13].Value.ToString().Trim();
                            string tti = worksheet.Cells[row, 14].Value == null ? "" : worksheet.Cells[row, 14].Value.ToString().Trim();
                            string hsDescription = worksheet.Cells[row, 15].Value == null ? "" : worksheet.Cells[row, 15].Value.ToString().Trim();


                            var taxYearInfo = taxYears.Where(a => a.taxYearName.Contains(taxYear)).FirstOrDefault();

                            if (taxYearInfo == null)
                            {
                                continue;
                            }

                            var vatCategoryInfo = vatCategories.Where(a => a.vatCategoryName.Contains(vatCategory)).FirstOrDefault();

                            if (vatCategoryInfo == null)
                            {
                                continue;
                            }

                            var vatScheduleInfo = vatSchedules.Where(a => a.vatScheduleName.Contains(vatSchedule)).FirstOrDefault();

                            if (vatScheduleInfo == null)
                            {
                                continue;
                            }
                            var vatTableInfo = vatTables.Where(a => a.tableName.Contains(vatTable)).FirstOrDefault();

                            if (vatTableInfo == null)
                            {
                                continue;
                            }

                            var data = new ItemHsCode()
                            {
                                createdAt = DateTime.Now,
                                hsCode = hsCode,
                                validFrom=Convert.ToDateTime(validFromDate),
                                vatCategoryId =vatCategoryInfo.Id,
                                vATScheduleId = vatScheduleInfo.Id,
                                vatTableId = vatTableInfo.Id,
                                taxYearId = taxYearInfo.Id,
                                CD = Convert.ToDecimal(cd),
                                SD = Convert.ToDecimal(sd),
                                VAT = Convert.ToDecimal(vat),
                                AIT = Convert.ToDecimal(ait),
                                AT = Convert.ToDecimal(at),
                                RD = Convert.ToDecimal(rd),
                                EXD = Convert.ToDecimal(exd),
                                TTI = Convert.ToDecimal(tti),
                                hsDescription = hsDescription

                            };

                            _itemHsCode.Insert(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Redirect("/FAMSDEALER/ItemHsCode/ItemHsCode");
        }



        public IActionResult Delete(ItemHsCode itemHsCode)
        {
            _itemHsCode.Delete(itemHsCode);
            return RedirectToAction(nameof(ItemHsCode));
        }
    }
}
