using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018MVC.Models;

namespace CommunityAssist2018MVC.Controllers
{
    public class RegistrationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "PersonUsername, PersonLastName, PersonFirstName, PersonEmail, PersonPrimaryPhone, PersonAddressApt, PersonAddressStreet, PersonAddressCity, PersonAddressState, PersonAddressPostal, PersonPlainPassword")]NewPerson np)
        {
            int result = db.usp_Register(np.PersonUserName, np.PersonLastName, np.PersonFirstName, np.PersonEmail, np.PersonPrimaryPhone, np.PersonAddressApt, np.PersonAddressStreet, np.PersonAddressCity, np.PersonAddressState, np.PersonAddressPostal, np.PersonPlainPassword);

            if (result != -1)
            {
                return RedirectToAction("Message");
            }
            return View();
        }

    }
}