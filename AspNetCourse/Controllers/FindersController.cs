using AspNetCourse.Core;
using AspNetCourse.Core.Domain;
using AspNetCourse.Core.Repositories;
using AspNetCourse.Persistence;
using AspNetCourse.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetCourse.Controllers
{
    public class FindersController : Controller
    {
        private readonly IUnitOfWork _repository = null;
        public FindersController()
        {
            _repository = new UnitOfWork();
        }
        public ActionResult Index()
        {
            IEnumerable<Finder> finders = _repository.Finders.GetAll();
            return View("FindersTable", finders);
        }
        public ActionResult Edit(int? id)
        {
            IEnumerable<Finder> finders = _repository.Finders.GetAll();
            Finder finder = finders.Where(fin => fin.FinderId == id).FirstOrDefault();
            return View("FinderForm", finder);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Finders.Remove(new Finder() { FinderId = id });
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Something went wrong");
            }
        }

        [HttpPost]
        public ActionResult Update(Finder finder)
        {
            if (finder.FinderId == 0)
                _repository.Finders.Add(finder);
            else
               _repository.Finders.Update(finder);
            return RedirectToAction("Index");
        }
    }
}