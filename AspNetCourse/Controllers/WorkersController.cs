using AspNetCourse.Core;
using AspNetCourse.Core.Domain;
using AspNetCourse.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetCourse.Controllers
{
    public class WorkersController : Controller
    {
        private IUnitOfWork _repository = null;

        public WorkersController()
        {
            _repository = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<Worker> workers = _repository.Workers.GetAll();
            return View("WorkersTable", workers);
        }
        public ActionResult Edit(int? id)
        {
            var worker = _repository.Workers.GetAll().Where(w => w.WorkerId == id).FirstOrDefault();
            return View("WorkersForm", worker);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Workers.Remove(new Worker() { WorkerId = id });
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        public ActionResult Update(Worker worker)
        {
            if (worker.WorkerId == 0)
                _repository.Workers.Add(worker);
            else
                _repository.Workers.Update(worker);
            return RedirectToAction("Index");
        }
    }
}