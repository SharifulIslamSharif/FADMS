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
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class ItemController : Controller
    {
        private readonly IRepository<ArmType> _armsType;
        private readonly IRepository<Unit> _unit;
        private readonly IRepository<Item> _item;
        private readonly IItemCodeService _itemCodeService;
        private readonly IRepository<SpecificationCategory> _specoficationCategory;
        private readonly IITemService _itemService;

        public ItemController(
            IRepository<ArmType> armsType,
            IRepository<Unit> unit,
            IRepository<Item> item,
            IRepository<SpecificationCategory> specoficationCategory,
            IItemCodeService itemCodeService,
            IITemService itemService
            )
        {
            _armsType = armsType;
            _unit = unit;
            _item = item;
            _itemCodeService = itemCodeService;
            _specoficationCategory = specoficationCategory;
            _itemService = itemService;

        }

        //[HttpGet]
        //public async Task<IActionResult> ItemInfoList()
        //{
        //    var data = new ItemViewModel
        //    {
        //        items = await _itemService.GetAllItem(),

        //        armTypes = _armsType.GetAll(),
        //        units = _unit.GetAll(),
        //        specificationCategories = _specoficationCategory.GetAll(),

        //    };
        //    return View(data);
        //}



        [HttpGet]

        public async Task<IActionResult> ItemList()
        {
            var data = new ItemViewModel
            {
                items = await _itemService.GetAllItem(),

                armTypes = _armsType.GetAll(),
                units = _unit.GetAll(),
                specificationCategories = _specoficationCategory.GetAll(),

            };
            return View(data);
        }

        [HttpPost]
        public async Task<JsonResult> ItemList([FromForm] ItemViewModel model)
        {
            //string itemCode = "";
            //if (model.itemId == 0)
            //{
            //    itemCode = await ItemsService.GetItemCode();
            //}
            //else
            //{
            //    itemCode = model.itemCode;
            //}
            Item item = new Item
            {
                Id =(int) model.itemId,
                parentId = model.parentId,
                unitId = model.unitId,
                itemName = model.itemName,
                //itemCode = itemCode,
                itemDescription = model.itemDescription,
                isDelete = 0,
                itemCode = model.itemCode,
                itemHsCodeId = model.itemHsCodeId,
                productionTypeId = model.productionTypeId,
                reorderQty = model.reorderQty,
                costingMethod = model.costingMethod,
                //  accountLedgerId = model.accountLedgerId,
                // reOrderLevel = model.reOrderLevel,
                createdBy = HttpContext.User.Identity.Name,
                createdAt = DateTime.Now
            };

            int instId = await _itemService.SaveItem(item);
            int itemspecid = 0;
            if (model.specificationCategoryId != null)
            {
                if (model.specificationCategoryId.Length > 0)
                {

                    for (int i = 0; i < model.specificationCategoryId.Length; i++)
                    {
                        #region ItemSpecification
                        if (model.itemSpecificationName[i] != null)
                        {
                            var Itemspec = await _itemService.GetAllItemSpecificationByitemIdandspec(instId, model.itemSpecificationName[i]);

                            if (Itemspec.Count() > 0)
                            {
                                itemspecid = Itemspec.FirstOrDefault().Id;
                                await _itemService.DeleteSpecificationDetailBySpecId(Convert.ToInt32(itemspecid));
                            }
                            else
                            {
                                ItemSpecification itemspec = new ItemSpecification
                                {
                                    Id = 0,
                                    itemId = Convert.ToInt32(instId),
                                    specificationName = model.itemSpecificationName[i],
                                    isDelete = 0,
                                    createdBy = HttpContext.User.Identity.Name,
                                    createdAt = DateTime.Now
                                };
                                itemspecid = await _itemService.SaveItemSpecification(itemspec);
                            }
                        }

                        #endregion
                        SpecificationDetail specificationDetail = new SpecificationDetail();
                        specificationDetail.Id = 0;
                        specificationDetail.itemSpecificationId = itemspecid;
                        specificationDetail.specificationCategoryId = model.specificationCategoryId[i];
                        specificationDetail.value = model.CategoryValue[i];

                        await _itemService.SaveSpecificationDetail(specificationDetail);
                        specificationDetail = new SpecificationDetail();
                    }

                }

            }
            if (model.itemId == 0)
            {
                ItemSpecification itemspec = new ItemSpecification
                {
                    Id = 0,
                    itemId = Convert.ToInt32(instId),
                    specificationName = model.itemName,
                    isDelete = 0,
                    createdBy = HttpContext.User.Identity.Name,
                    createdAt = DateTime.Now
                };
                itemspecid = await _itemService.SaveItemSpecification(itemspec);

            }

            #region Spec banned
            //var Itemspec = await ItemsService.GetAllItemSpecificationByitemIdandspec(instId, model.itemspecification);
            //int itemspecid = 0;
            //if (Itemspec.Count() > 0)
            //{
            //    itemspecid = Itemspec.FirstOrDefault().Id;
            //}
            //if (model.speclist.Count() > 0)
            //{
            //    foreach (var data in model.speclist)
            //    {
            //        Itemspec = await ItemsService.GetAllItemSpecificationByitemIdandspec(instId, data);
            //        if (Itemspec.Count() > 0)
            //        {
            //            itemspecid = Itemspec.FirstOrDefault().Id;
            //        }
            //        else
            //        {
            //            itemspecid = 0;
            //        }
            //        ItemSpecification itemspec = new ItemSpecification
            //        {
            //            Id = itemspecid,
            //            itemId = instId,
            //            specificationName = data,
            //            isDelete = 0,
            //            createdBy = HttpContext.User.Identity.Name,
            //            createdAt = DateTime.Now
            //        };
            //        await ItemsService.SaveItemSpecification(itemspec);
            //    }
            //}
            //else
            //{
            //    if (model.itemspecification != "")
            //    {
            //        ItemSpecification itemspec = new ItemSpecification
            //        {
            //            Id = itemspecid,
            //            itemId = instId,
            //            specificationName = model.itemspecification,
            //            isDelete = 0,
            //            createdBy = HttpContext.User.Identity.Name,
            //            createdAt = DateTime.Now
            //        };
            //        await ItemsService.SaveItemSpecification(itemspec);

            //    }
            //}
            //----
            //#region ItemSpecification
            //if (model.itemspecification != null)
            //{
            //    ItemSpecification itemspec = new ItemSpecification
            //    {
            //        Id = model.itemSpecificationId,
            //        itemId = Convert.ToInt32(instId),
            //        specificationName = model.itemspecification,
            //        isDelete = 0,
            //        createdBy = HttpContext.User.Identity.Name,
            //        createdAt = DateTime.Now
            //    };
            //    itemspecid = await ItemsService.SaveItemSpecification(itemspec);
            //}

            //#endregion
            //if (model.itemSpecificationId > 0)
            //{
            //    await ItemsService.DeleteSpecificationDetailBySpecId(Convert.ToInt32(itemspecid));
            //}
            //if (model.specificationCategoryId != null)
            //{
            //    if (model.specificationCategoryId.Length > 0)
            //    {

            //        for (int i = 0; i < model.specificationCategoryId.Length; i++)
            //        {
            //            SpecificationDetail specificationDetail = new SpecificationDetail();

            //            specificationDetail.Id = 0;
            //            specificationDetail.itemSpecificationId = itemspecid;
            //            specificationDetail.specificationCategoryId = model.specificationCategoryId[i];
            //            specificationDetail.value = model.CategoryValue[i];

            //            await ItemsService.SaveSpecificationDetail(specificationDetail);
            //            specificationDetail = new SpecificationDetail();
            //        }

            //    }
            //}
            #endregion
            return Json(instId);

            //return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public async Task<JsonResult> UploadAttachment(string id, string[] arrayFileAtach)
        //{
        //    string userName = HttpContext.User.Identity.Name;

        //    if (Request.Form.Files.Count > 0)
        //    {
        //        for (int i = 0; i < Request.Form.Files.Count; i++)
        //        {
        //            int _min = 10000;
        //            int _max = 99999;
        //            Random _rdm = new Random();
        //            int rnd = _rdm.Next(_min, _max);

        //            string filePath = string.Empty;
        //            string fileName = string.Empty;
        //            string fileType = string.Empty;

        //            IFormFile file = Request.Form.Files[i];
        //            fileType = file.ContentType;
        //            fileName = rnd + file.FileName;
        //            filePath = "wwwroot/Upload/" + fileName;
        //            var fileD = Path.Combine(Directory.GetCurrentDirectory(), filePath);
        //            using (var fileSrteam = new FileStream(fileD, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileSrteam);
        //            }
        //            DocumentAttachment data = new DocumentAttachment
        //            {
        //                Id = 0,
        //                actionType = "Item",
        //                actionTypeId = Convert.ToInt32(id),
        //                subject = arrayFileAtach[i],
        //                fileName = fileName,
        //                filePath = filePath,
        //                fileType = fileType,
        //                description = "",
        //                documentType = "photo",
        //                createdBy = userName
        //            };
        //            await attachmentCommentService.SaveDocumentAttachment(data);


        //        }
        //    }
        //    return Json(true);
        //}

        [HttpGet]
        public JsonResult GetItemList()
        {
            var data = new ItemViewModel
            {
                armTypes = _armsType.GetAll(),
            };
            return Json(data);
        }


        public async Task<IActionResult> GetItemCode()
        {
            return Json(await _itemCodeService.GetItemCode());
        }

        public async Task<IActionResult> GetItemHSCode()
        {
            return Json(await _itemCodeService.GetAllItemHsCode());
        }

        [Route("global/api/GetAllItemForRequisition")]
        [HttpGet]
        public async Task<IActionResult> GetAllItemForRequisition()
        {
            return Json(await _itemService.GetAllItemForRequisition());
        }


        public async Task<IActionResult> GetAllItemForRequisitionForSales()
        {
            return Json(await _itemService.GetAllItemForRequisition());
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSpecificationDetailByitemId(int itemId)
        {
            var data = await _itemService.GetAllSpecificationDetailByitemId(itemId);
            return Json(data);
        }

        public async Task<IActionResult> GetItemHSCodeByHsCode(string hscode)
        {
            return Json(await _itemService.GetAllItemHsCodeByHsCode(hscode));
        }


        public async Task<JsonResult> GetItemSpecNamebyItem(int id)
        {

            var result = await _itemService.GetItemSpecNamebyItem(id);
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetItemSpecificationByitemId(int itemId)
        {
            var result = await _itemService.GetItemSpecificationByitemId(itemId);
            return Json(result);
        }
    }
}