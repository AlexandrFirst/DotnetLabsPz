using AspNetCourse.Core.Domain;
using AspNetCourse.Core.Repositories;
using AspNetCourse.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetCourse.Controllers
{
    public class OwnersController : Controller
    {

        private readonly IOwnerRepository _repository;

        public OwnersController()
        {
            _repository = new OwnersRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<Owner> owners = _repository.GetAll();
            return View("OwnersTable", owners);
        }

        public ActionResult Edit(int? id)
        {
            var owner = _repository.GetAll().Where(o => o.OwnerId == id).FirstOrDefault();
            return View("OwnersForm", owner);
        }
        public ActionResult Update(Owner owner)
        {
            if (owner.OwnerId == 0)
                _repository.Add(owner);
            else
                _repository.Update(owner);
            return RedirectToAction("Index");
        }
    }
}