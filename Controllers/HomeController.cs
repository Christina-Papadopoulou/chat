using System.Web.Mvc;
using UniversityChat.Models;
using UniversityChat.Repository;

namespace UniversityChat.Controllers
{

    public class HomeController : Controller
    {
        DummyRepository dummyRepository = new DummyRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            bool isRegistered;

            isRegistered = dummyRepository.findUserByName(user);

            if (isRegistered) {
                Session["session_username"] = user.username;
                Session["session_role"] = user.role;

                return RedirectToAction("Index", "Message", new { user.role });
            }

            return RedirectToAction("Index");
        }
    }
}