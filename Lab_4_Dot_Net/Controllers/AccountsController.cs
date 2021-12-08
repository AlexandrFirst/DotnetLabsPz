 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_4_Dot_Net.Core;
using Lab_4_Dot_Net.Core.DTO;
using System.Web.Security;

namespace Lab_4_Dot_Net.Controllers
{
    public class AccountsController : Controller
    {
        private const string loginView = "Login";
        private readonly IUnitOfWork _repository;
        public AccountsController(IUnitOfWork repository) => this._repository = repository;

        [HttpGet]
        public ActionResult Login() => View(loginView, new LoginDTO());
        [HttpPost]
        public ActionResult Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return View(loginView, dto);
            var worker = _repository.Workers.SingleOrDefault(w=>w.Login == dto.Login && w.Password == dto.Passsword);
            if(worker != null)
            {
                FormsAuthentication.SetAuthCookie(dto.Login, false);
                return RedirectToAction("Index", "Workers");
            }
            ModelState.AddModelError("", "invalid login or password");
            return View(loginView, dto);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}