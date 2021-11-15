using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSDEALER.Models;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.Data.Entity.ArmsInfo;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class ArmsTypeController : Controller
    {
        private readonly IRepository<ArmType> _armsType;

        public ArmsTypeController(IRepository<ArmType> armsType )
        {
            _armsType = armsType;
        }
        public IActionResult ArmsType()
        {
            var data = new ArmsTypeViewModel
            {
                armTypes = _armsType.GetAll(),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult ArmsType([FromForm] ArmsTypeViewModel model)
        {
            var data = new ArmType { 
                Id=model.armsTypeId,
                ArmTypeName=model.ArmTypeName,
                ArmTypeNameBn=model.ArmTypeNameBn
            };
            if (model.armsTypeId>0)
            {
                _armsType.Update(data);
            }
            else
            {
                _armsType.Insert(data);
            }
            return RedirectToAction(nameof(ArmsType));
        }

        public IActionResult Delete(ArmType armType)
        {
            _armsType.Delete(armType);
            return RedirectToAction(nameof(ArmsType));
        }
    }
}