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
    public class FindersController : Controller
    {
        private const string findersTable = "FindersTable";
        private const string findersForm = "FinderForm";
        private readonly IUnitOfWork _repository;
        public FindersController(IUnitOfWork repository) => this._repository = repository;

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
                var finders = _repository.Finders.GetFindersTableData();
                return View(findersTable, finders);
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try { return View(findersForm, _repository.Finders.GetFinderFormDTO(id)); }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Delete(int id)
        {
            try
            {
                int result = _repository.Finders.Remove(_repository.Finders.Get(id));
                _repository.Complete();
                if (result > 0)
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Success, "Finder was successfully deleted");
                else
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Danger, "Unknown error happened while deleting the finder");
                return RedirectToAction("Index");
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Update(FinderFormDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(findersForm, dto);
                int result = _repository.Finders.AddOrUpdate(dto);
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