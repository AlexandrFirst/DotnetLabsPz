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
    public class FindingsController : Controller
    {
        private const string findingsTable = "FindingsTable";
        private const string findingForm = "FindingForm";
        private readonly IUnitOfWork _repository;

        public FindingsController(IUnitOfWork repository) => this._repository = repository;

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
                var findings = _repository.Findings.GetFindingsTableData();
                return View(findingsTable, findings);
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try { return View(findingForm, _repository.Findings.GetFindingFormDTO(id)); }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Delete(int id)
        {
            try
            {
                int result = _repository.Findings.Remove(_repository.Findings.GetAll().Where(f=>f.FindingId == id).SingleOrDefault());
                if (result > 0)
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Success, "Finding was successfully deleted");
                else
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Danger, "Unknown error happened while deleting the finding");
                return RedirectToAction("Index");
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Update(FindingFormDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(findingForm, dto);
                int result = _repository.Findings.AddOrUpdate(dto);
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
