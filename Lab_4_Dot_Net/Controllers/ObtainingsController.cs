using Lab_4_Dot_Net.Core;
using Lab_4_Dot_Net.Core.DTO;
using Lab_4_Dot_Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4_Dot_Net.Controllers
{
    public class ObtainingsController : Controller
    {
        private const string obtainingsTable = "ObtainingsTable";
        private const string obtainingForm = "ObtainingForm";
        private readonly IUnitOfWork _repository;
        public ObtainingsController(IUnitOfWork repository) => this._repository = repository;

        public ActionResult AddNewFinder() => RedirectToAction("Edit", "Finders");
        public ActionResult AddNewFinding() => RedirectToAction("Edit", "Findings");

        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (TempData.ContainsKey("Alert"))
                {
                    ViewBag.Alert = TempData["Alert"].ToString();
                    TempData.Remove("Alert");
                }
                var obtainings = _repository.Obtainings.GetObtainingsTableData();
                return View(obtainingsTable, obtainings);
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult Add()
        {
            try { return View(obtainingForm, _repository.Obtainings.GetObtainingFormDTO()); }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Delete(int WorkerId, int FindingId, int FinderId)
        {
            try
            {
                int result = _repository.Obtainings.Remove(_repository.Obtainings.Find(o=>o.FinderId == FinderId
                && o.FindingId == FindingId && o.WorkerId == WorkerId).FirstOrDefault());
                _repository.Complete();
                if (result > 0)
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Success, "Owner was successfully deleted");
                else
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Danger, "Unknown error happened while deleting the owner");
                return RedirectToAction("Index");
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Add(ObtainingFormDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) {
                    var newDto = _repository.Obtainings.GetObtainingFormDTO();
                    newDto.FinderName = dto.FinderName;
                    newDto.FindingName = dto.FindingName;
                    return View(obtainingForm, newDto);
                }
                int result = _repository.Obtainings.Add(dto, User.Identity.Name);
                if (result > 0)
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Success, "Operation was successfully performed");
                else
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Danger, "Unknown error happened while performing this operation");
                return RedirectToAction("Index");
            }
            catch (Exception e) { return Content(e.Message); }
        }
    }
}