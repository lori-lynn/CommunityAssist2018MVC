using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2018MVC.Models;

namespace CommunityAssist2018MVC.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            var ukey = System.Web.HttpContext.Current.Session["ukey"] as int?;
            if (ukey != null)
                return View();
            else
            {
                var resultMessage = new Message();

                resultMessage.MessageText = "Please log in to make a donation.";

                return View("Result", resultMessage);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "DonationAmount")]Donation dn)
        {
            var resultMessage = new Message();
            if (ModelState.IsValid)
            {
                CommunityAssist2017Entities db = new CommunityAssist2017Entities();
                var donator = db.People.Find(System.Web.HttpContext.Current.Session["ukey"] as int? ?? 0);

                dn.DonationConfirmationCode = Guid.NewGuid();
                dn.DonationDate = DateTime.Now;
                donator.Donations.Add(dn);
                db.SaveChanges();
                resultMessage.MessageText = "Thank you for your donation! Your confirmation code is " + dn.DonationConfirmationCode;
            }
            else
            {
                resultMessage.MessageText = "We're so sorry, something seems to have gone wrong. Please call us to make a donation.";
            }
            return View("Result", resultMessage);
        }
    }
}