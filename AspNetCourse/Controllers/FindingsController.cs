using AspNetCourse.Core;
using AspNetCourse.Core.Domain;
using AspNetCourse.Persistence;
using AspNetCourse.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetCourse.Controllers
{
    public class FindingsController : Controller
    {
        private readonly IUnitOfWork _repository = null;
        public FindingsController()
        {
            _repository = new UnitOfWork();
        }

        public ActionResult Index()
        {
            List<Finding> findings = (List<Finding>)_repository.Findings.GetAll();
            return View("FindingsTable", findings);
        }

        public ActionResult Edit(int? id)
        {
            var finding = _repository.Findings.GetAll().Where(f => f.FindingId == id).FirstOrDefault();
            return View("FindingForm", finding);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Findings.Remove(new Finding() { FindingId = id });
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
        public ActionResult Update(Finding finding)
        {
            if (finding.FindingId == 0)
                _repository.Findings.Add(finding);
            else
                _repository.Findings.Update(finding);
            return RedirectToAction("Index");
        }
    }
}