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
    [Authorize]
    public class WorkersController : Controller
    {
        private const string workersTable = "WorkersTable";
        private const string workerForm = "WorkerForm";
        private readonly IUnitOfWork _repository;
        public WorkersController(IUnitOfWork repository) => this._repository = repository;

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
                var workersDictionary = _repository.Workers.GetWorkersTableData();
                return View(workersTable, workersDictionary);
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [Authorize(Roles = "Admin,Worker")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try { return View(workerForm, _repository.Workers.GetWorkerFormDTO(id)); }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                int result = _repository.Workers.Remove(_repository.Workers.GetAll().Where(w => w.WorkerId == id).SingleOrDefault());
                if (result > 0)
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Success, "Worker was successfully deleted");
                else
                    TempData["Alert"] = AlertsService.ShowAlert(Alerts.Danger, "Unknown error happened while deleting the worker");
                return RedirectToAction("Index");
            }
            catch (Exception e) { return Content(e.Message); }
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Worker")]
        public ActionResult Update(WorkerFormDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(workerForm, dto);
                else if (_repository.Workers.GetAll().Where(w => w.Login == dto.Login && dto.WorkerId == 0).Count() > 0)
                {
                    ModelState.AddModelError("Login", "There is already a user with such login");
                    return View(workerForm, dto);
                }
                int result = _repository.Workers.AddOrUpdate(dto);
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