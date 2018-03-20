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
            }

            return View("Result", lgc);
        }
    }
}