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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonLastName, PersonFirstName, PersonEmail, PersonPrimaryPhone, PersonAddressApt, PersonAddressStreet, PersonAddressCity, PersonAddressState, PersonAddressPostal, PersonPlainPassword")]NewPerson np)
        {
            int result = db.usp_Register(np.PersonLastName, np.PersonFirstName, np.PersonEmail, np.PersonPlainPassword, np.PersonAddressApt, np.PersonAddressStreet, np.PersonAddressCity, np.PersonAddressState, np.PersonAddressPostal, np.PersonPrimaryPhone);

            var resultMessage = new Message();
            if (result != -1)
            {
                resultMessage.MessageText = "Thanks for registering.";

            } else {
                resultMessage.MessageText = "Sorry, but something seems to have gone wrong with the registration.";
            }
            return View("Result",resultMessage);
        }

    }
}