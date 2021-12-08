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
    public class OwnersController : Controller
    {
        private const string ownersTable = "OwnersTable";
        private const string ownerForm = "OwnerForm";
        private readonly IUnitOfWork _repository;
        public OwnersController(IUnitOfWork repository) => this._repository = repository;

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
                var owners = _repository.Owners.GetOwnersTableData();
                return View(ownersTable, owners);
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try { return View(ownerForm, _repository.Owners.GetOwnerFormDTO(id)); }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Delete(int id)
        {
            try
            {
                int result = _repository.Owners.Remove(_repository.Owners.Get(id));
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
        public ActionResult Update(OwnerFormDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(ownerForm, dto);
                int result = _repository.Owners.AddOrUpdate(dto);
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