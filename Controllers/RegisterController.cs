using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityChat.Models;
using UniversityChat.Repository;

namespace UniversityChat.Controllers
{
    public class RegisterController : Controller
    {

        DummyRepository dummyRepository = new DummyRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            dummyRepository.insertUser(user);
            return RedirectToAction("Index","Home");
        }

    }
}