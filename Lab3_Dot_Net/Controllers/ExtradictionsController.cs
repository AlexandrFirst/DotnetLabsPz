using Lab3_Dot_Net.Core;
using Lab3_Dot_Net.Core.DTO;
using Lab3_Dot_Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3_Dot_Net.Controllers
{
    public class ExtradictionsController : Controller
    {
        private const string extradictionsTable = "ExtradictionsTable";
        private const string extradictionForm = "ExtradictionForm";
        private readonly IUnitOfWork _repository;
        public ExtradictionsController(IUnitOfWork repository) => this._repository = repository;
        public ActionResult AddNewOwner() => RedirectToAction("Edit", "Owners");
        public ActionResult AddNewObtaining() => RedirectToAction("Add", "Obtainings");

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
                var extradictions = _repository.Extradictions.GetExtradictionsTableData();
                return View(extradictionsTable, extradictions);
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult Add()
        {
            try { return View(extradictionForm, _repository.Extradictions.GetExtradictionFormDTO()); }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Delete(int WorkerId, int FindingId, int OwnerId)
        {
            try
            {
                int result = _repository.Extradictions.Remove(_repository.Extradictions.GetAll().Where(e => e.OwnerId == OwnerId
                && e.FindingId == FindingId && e.WorkerId == WorkerId).FirstOrDefault());
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
        public ActionResult Add(ExtradictionFormDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var newDto = _repository.Extradictions.GetExtradictionFormDTO();
                    newDto.OwnerName = dto.OwnerName;
                    newDto.FindingName = dto.FindingName;
                    return View(extradictionForm, newDto);
                }
                int result = _repository.Extradictions.AddExtradiction(dto, User.Identity.Name);
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