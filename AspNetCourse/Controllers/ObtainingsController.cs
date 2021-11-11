using AspNetCourse.Core;
using AspNetCourse.Core.Domain;
using AspNetCourse.Core.DTO_s;
using AspNetCourse.Core.Repositories;
using AspNetCourse.Persistence;
using AspNetCourse.Persistence.Repositories;
using AspNetCourse.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetCourse.Controllers
{
    public class ObtainingsController : Controller
    {
        private readonly IUnitOfWork _repository = null;

        public ObtainingsController()
        {
            _repository = new UnitOfWork();
        }
        public ActionResult Index()
        {
            IEnumerable<ObtainingDTO> obtainings = _repository.Obtainings.GetAll().Select(o => new ObtainingDTO()
            {
                Finder = _repository.Finders.GetAll().Where(f => f.FinderId == o.FinderId).Select(f => f.Name + " " + f.Surname).FirstOrDefault(),
                Finding = _repository.Findings.GetAll().Where(f => f.FindingId == o.FindingId).Select(f => f.Name).FirstOrDefault(),
                Worker = _repository.Workers.GetAll().Where(w => w.WorkerId == o.WorkerId).Select(w => w.Name + " " + w.Surname).FirstOrDefault(),
                WorkerId = o.WorkerId,
                FinderId = o.FinderId,
                FindingId = o.FindingId
            }) ;
            return View("ObtainingsTable", obtainings);
        }
        public ActionResult GetForm()
        {
            ObtainingViewModel vm = new ObtainingViewModel()
            {
                Finders = _repository.Finders.GetAll().Select(f => f.Name + " " + f.Surname),
                Workers = _repository.Workers.GetAll().Select(w => w.Name + " " + w.Surname),
                Findings = _repository.Findings.GetAll().Select(f => f.Name)
            };
            return View("ObtainingForm", vm);
        }
        public ActionResult Delete(int WorkerId, int FinderId, int FindingId)
        {
            try
            {
                _repository.Obtainings.Remove(new Obtaining() { WorkerId = WorkerId, FinderId = FinderId, FindingId = FindingId });
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return Content(e.Message);         
            }
        }
        public ActionResult Create(ObtainingViewModel vm)
        {
            try
            {
                var workerId = _repository.Workers.GetAll().Where(w => w.Name + " " + w.Surname == vm.Obtaining.Worker).Select(w => w.WorkerId).FirstOrDefault();
                var finderId = _repository.Finders.GetAll().Where(f => f.Name + " " + f.Surname == vm.Obtaining.Finder).Select(f => f.FinderId).FirstOrDefault();
                var findingId = _repository.Findings.GetAll().Where(f => f.Name == vm.Obtaining.Finding).Select(f => f.FindingId).FirstOrDefault();
                _repository.Obtainings.Add(new Obtaining() { WorkerId = workerId, FinderId = finderId, FindingId = findingId });
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Something wen wrong");
            }
        }
    }
}