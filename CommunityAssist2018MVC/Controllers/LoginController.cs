using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018MVC.Models;

namespace CommunityAssist2018MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email, Password")]LoginClass lgc)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            lgc.PersonKey = 0;
            int result = db.usp_Login(lgc.Email, lgc.Password);

            if (result != -1)
            {
                var ukey = (from p in db.People
                            where p.PersonEmail.Equals(lgc.Email)
                            select p.PersonKey).FirstOrDefault();
                lgc.PersonKey = ukey;
                System.Web.HttpContext.Current.Session["ukey"] = ukey;
            }

            var resultMessage = new Message();
            if (result != -1)
            {
                resultMessage.MessageText = "Thank you for loggin in. You may now Donate or apply for assistance.";

            }
            else
            {
                resultMessage.MessageText = "Login failed. Please check your credentials, or Register if you have not yet done so.";
            }
            return View("Result", resultMessage);
        }
    }
}