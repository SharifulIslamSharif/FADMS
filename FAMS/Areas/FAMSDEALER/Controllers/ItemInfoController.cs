using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.FamsDealerService.Interface;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Dealer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    [Authorize]
    public class ItemInfoController : Controller
    {
        private readonly IRepository<ArmType> _armsType;
        private readonly IRepository<Unit> _unit;
        private readonly IRepository<Item> _item;
        private readonly IRepository<ItemSpecification>  _itemSpec;
        private readonly IItemCodeService _itemCodeService;
        private readonly IRepository<SpecificationCategory> _specoficationCategory;
        private readonly IITemService _itemService;
        private readonly IDealerService _dealerService;
        public ItemInfoController(
             IRepository<ArmType> armsType,
            IRepository<Unit> unit,
            IRepository<Item> item,
            IRepository<ItemSpecification> itemSpec,
            IRepository<SpecificationCategory> specoficationCategory,
            IItemCodeService itemCodeService,
            IITemService itemService,
            IDealerService dealerService

            )
        {
            _armsType = armsType;
            _unit = unit;
            _item = item;
            _itemSpec = itemSpec;
            _itemCodeService = itemCodeService;
            _specoficationCategory = specoficationCategory;
            _itemService = itemService;
            this._dealerService = dealerService;
        }
        public async Task<IActionResult> GetItemSpecById(int? id)
        {
            var spec = await _itemService.GetItemSpecificationById(id);
            return Json(spec);
        }

        [HttpGet]
        public async Task<IActionResult> AddItem(int? itemid)
        {
            ViewBag.masterId = itemid;
            var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var data = new ItemViewModel
            {
                
                armTypes = _armsType.GetAll(),
            };
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemViewModel model)
        {
            try
            {
                var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
                var data = new ItemViewModel
                {
                    armTypes = _armsType.GetAll(),
                };
                if (!ModelState.IsValid)
                {
                    //ModelState.AddModelError();
                    var er = ModelState.Values;
                    return View(data);
                }
                Item item = new Item
                {
                    Id = (int)model.itemId,
                    itemName = model.itemName,
                    itemCode = model.itemCode,
                    ArmTypeId = model.armsTypeId,
                    itemDescription = model.itemDescription,
                    costingMethod = model.costingMethod,
                    DealerId=dealerId
                };
                //if (model.itemId > 0)
                //{
                //    _item.Update(item);
                //}
                //else { _item.Insert(item); };
                int instId = await _itemService.SaveItem(item);

                ItemSpecification itemspec = new ItemSpecification
                {
                    Id = (int)model.itemSpecificationId,
                    itemId = instId,
                    specificationName = model.itemName,
                    itemCode = model.itemCode,
                    ArmTypeId = model.armsTypeId,
                    itemDescription = model.itemDescription,
                    costingMethod = model.costingMethod,
                    DealerId = dealerId
                };
                //if (model.itemId > 0)
                //{
                //    _item.Update(item);
                //}
                //else { _item.Insert(item); };
                await _itemService.SaveItemSpecification(itemspec);
                return RedirectToAction("ItemListByDealer");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        public async Task<IActionResult> ItemListByDealer()
        {
            var dealerId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            var data = new ItemViewModel
            {
                itemSpecifications = await _itemService.GetAllItemSpecByDealer(dealerId),
            };
            return View(data);
        }
        public async Task<IActionResult> DeleteItems(int? Id)
        {
            var result = await _itemService.DeleteItemSpecById(Id);
            return Json(result);
        }

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

            Item item = new Item
            {
                Id =(int)model.itemId,
                parentId = model.parentId,
                ArmTypeId = model.armsTypeId,
                unitId = model.unitId,
                itemName = model.itemName,
                itemDescription = model.itemDescription,
                isDelete = 0,
                itemCode = model.itemCode,
                itemHsCodeId = model.itemHsCodeId,
                productionTypeId = model.productionTypeId,
                reorderQty = model.reorderQty,
                costingMethod = model.costingMethod,

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

            return Json(instId);
        }


        [HttpGet]
        public JsonResult GetItemList()
        {
            var data = new ItemViewModel
            {
                armTypes = _armsType.GetAll(),
            };
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemCode()
        {
            return Json(await _itemCodeService.GetItemCode());
        }
        [HttpGet]
        public async Task<IActionResult> GetItemHSCode()
        {
            return Json(await _itemCodeService.GetAllItemHsCode());
        }
        [HttpGet]
        //  [Route("/global/api/GetAllItemForRequisition")]
        public async Task<IActionResult> GetAllItemForRequisition()
        {
            return Json(await _itemService.GetAllItemForRequisition());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemForRequisitionForSales()
        {
            
            return Json(await _itemService.GetAllItemForRequisition());
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItemForDealer()
        {
            var dId = await _dealerService.GetDealerIdByUserName(User.Identity.Name);
            return Json(await _itemService.GetAllItemSpecByDealer(dId));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSpecificationDetailByitemId(int itemId)
        {
            var data = await _itemService.GetAllSpecificationDetailByitemId(itemId);
            return Json(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetItemHSCodeByHsCode(string hscode)
        {
            return Json(await _itemService.GetAllItemHsCodeByHsCode(hscode));
        }

        [HttpGet]
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