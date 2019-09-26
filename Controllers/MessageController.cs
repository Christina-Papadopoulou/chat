using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityChat.Models;
using UniversityChat.Repository;

namespace UniversityChat.Controllers
{
    public class MessageController : Controller
    {
        DummyRepository dummyRepository = new DummyRepository();

        public ActionResult Index(string role)
        {
            IList messageList = dummyRepository.findMessageByRole(role);

            ViewData["message_list"] = messageList;

            return View();
        }

        [HttpPost]
        public ActionResult sendMessage(string messageText)
        {
            string userName = (string)Session["session_username"];
            string role = (string)Session["session_role"];

            MessageModel messageModel = new MessageModel();
            messageModel.messageText = messageText.Trim();
            messageModel.dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            messageModel.username = userName.Trim();
            dummyRepository.insertMessage(messageModel);

            return RedirectToAction("index", new { role }); ;
        }
    }
}