using Lab3_Dot_Net.Core;
using Lab3_Dot_Net.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lab3_Dot_Net.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUnitOfWork _repository = null;
        private const string loginView = "Login";

        public AccountsController(IUnitOfWork repository) => this._repository = repository;
        [HttpGet]
        public ActionResult Login() => View(loginView);

        [HttpPost]
        public ActionResult Login(LoginDTO dto)
        {
            var worker = _repository.Workers.GetAll().Where(w => w.Login == dto.Login && w.Password == dto.Password);
            if(worker != null)
            {
                FormsAuthentication.SetAuthCookie(dto.Login, false);
                return RedirectToAction("Index", "Workers");
            }
            ModelState.AddModelError("", "invalid login or password");
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(loginView);
        }
    }
}