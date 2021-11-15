using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.ArmsInfo.Models;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.Data.Entity.ArmsInfo;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.ArmsInfo.Controllers
{
    [Area("ArmsInfo")]
    public class ArmsTypeEntryController : Controller
    {
        private IRepository<ArmType> repoArm;

        public ArmsTypeEntryController(IRepository<ArmType> repoArm)
        {
            this.repoArm = repoArm;
        }

        public IActionResult Index()
        {
            ArmsTypeEntryViewModel model = new ArmsTypeEntryViewModel
            {
                GetArmTypes = repoArm.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] ArmsTypeEntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GetArmTypes = repoArm.GetAll();
            }
            ArmType data = new ArmType
            {
                Id = model.id,
                ArmTypeName = model.armsTypeName
            };
            repoArm.Insert(data);

            return RedirectToAction(nameof(Index));
        }
    }
}